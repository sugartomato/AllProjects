Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports ZS.Common

Namespace DB

    Public Class CommonSqlDAL

        Private m_TableName As String = String.Empty
        Private m_ConnectionString As String = String.Empty

        ''' <summary>
        ''' 通过连接字符串与表名构造一个SQL Server数据库的DAL操作
        ''' </summary>
        ''' <param name="v_TableName"></param>
        ''' <param name="v_ConnectionString"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal v_TableName As String, ByVal v_ConnectionString As String)

            ' 验证
            If v_TableName.Length = 0 Then Throw New ApplicationException("必须指定表名")
            If v_ConnectionString.Length = 0 Then Throw New ApplicationException("必须指定连接字符串")

            m_TableName = v_TableName
            m_ConnectionString = v_ConnectionString

        End Sub


#Region "添加"

        ''' <summary>
        ''' 根据字典向数据表添加数据。
        ''' </summary>
        ''' <param name="v_Fields"></param>
        ''' <param name="v_Tran"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AddByFields(ByVal v_Fields As Dictionary(Of String, Object), ByVal v_Tran As SqlTransaction) As Boolean

            If (v_Fields Is Nothing OrElse v_Fields.Count = 0) Then
                Return False
            End If

            Dim listPara As List(Of SqlParameter) = Nothing     ' 参数集合
            Dim strSQL As String = String.Empty                 ' SQL语句
            Dim strFields As String = String.Empty              ' 字段部分SQL语句
            Dim strValues As String = String.Empty              ' 值部分SQL语句
            Dim strTempFieldName As String = String.Empty

            strSQL = " INSERT INTO [" & m_TableName & "] ({0}) VALUES ({1})"

            Dim keys As Dictionary(Of String, Object).KeyCollection = v_Fields.Keys
            For Each key As String In keys
                strTempFieldName = key.Trim("[").Trim("]")
                strFields &= "[" & strTempFieldName & "],"
                strValues &= "@" & strTempFieldName & ","
                listPara.Add(CreateSQLParameter("@" & strTempFieldName, v_Fields(key)))
            Next

            ' 去除末尾的逗号
            strFields = strFields.Trim(",")
            strValues = strValues.Trim(",")

            ' 合并SQL
            strSQL = String.Format(strSQL, strFields, strValues)

            Try
                Dim intExCount As Int32 = 0
                ' 执行SQL语句
                If v_Tran Is Nothing Then
                    intExCount = SQLHelper.ExecuteNonQuery(m_ConnectionString, CommandType.Text, strSQL, listPara.ToArray())
                Else
                    intExCount = SQLHelper.ExecuteNonQuery(v_Tran, CommandType.Text, strSQL, listPara.ToArray())
                End If

                Return intExCount > 0

            Catch ex As Exception
                Throw New ApplicationException("按字段向表【" & m_TableName & "】添加数据失败。", ex)
            End Try

        End Function


#End Region

#Region "查询 - Table"

        ''' <summary>
        ''' 查询表中指定查询条件、指定排序条件、指定字段的数据，返回DataTable
        ''' </summary>
        ''' <param name="v_Filter">查询条件。如果为空，则表示查询所有。</param>
        ''' <param name="v_Order">排序条件。如果为空，则表示按照默认排序。</param>
        ''' <param name="v_Fields">要查询的字段。如果为空，表示查询所有字段。</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetTable(ByVal v_Filter As String, ByVal v_Order As String, ByVal v_Fields As List(Of String)) As DataTable

            Dim strSQL As String = String.Empty                 ' SQL语句
            Dim strFields As String = "*"

            If (Not v_Fields Is Nothing AndAlso v_Fields.Count > 0) Then
                strFields = v_Fields.Join(",")
            End If
            strSQL = " SELECT " & strFields & " FROM [" & m_TableName & "] "

            ' 查询条件
            If (v_Filter.Length > 0) Then
                strSQL &= " WHERE " & v_Filter
            End If

            ' 排序条件
            If (v_Order.Length > 0) Then
                strSQL &= " ORDER BY " & v_Order
            End If

            Try

                Dim ds As DataSet = SQLHelper.ExecuteDataset(m_ConnectionString, CommandType.Text, strSQL)
                If (Not ds Is Nothing AndAlso ds.Tables.Count > 0) Then
                    Return ds.Tables(0)
                End If
                Return Nothing

            Catch ex As Exception
                Throw New ApplicationException("从表【" & m_TableName & "】查询条件为【" & v_Filter & "】，排序条件为【" & v_Order & "】,查询字段为【" & strFields & "】的数据失败。", ex)
            End Try
        End Function



#End Region

#Region "查询 - 泛型集合"


        Public Function GetList(Of T)() As List(Of T)

        End Function


#End Region


        ''' <summary>
        ''' 创建SQL参数
        ''' </summary>
        ''' <param name="v_Name">参数名</param>
        ''' <param name="v_Value">值</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CreateSQLParameter(ByVal v_Name As String, ByVal v_Value As Object) As SqlParameter
            Dim para As SqlParameter = New SqlParameter()
            para.ParameterName = v_Name
            If (Not v_Value Is Nothing) Then
                para.Value = v_Value
                If (v_Value.GetType().FullName = "System.String") Then
                    If (v_Value.ToString().Length = 0) Then para.Value = DBNull.Value
                End If
            Else
                para.Value = DBNull.Value
            End If
            Return para
        End Function

    End Class


End Namespace

