Imports System.IO


Public Class ImageHelper

#Region "图片尺寸与压缩"

    ''' <summary>
    ''' 获取指定路径的图片的尺寸。
    ''' </summary>
    ''' <param name="path">图片的本地路径</param>
    ''' <returns></returns>
    Public Shared Function GetSize(ByVal path As String) As System.Drawing.Size
        If (Not System.IO.File.Exists(path)) Then
            Throw New Exception("指定的图片文件[ " & path & "]不存在！")
        End If

        Dim img As System.Drawing.Image = Nothing
        Dim imgSize As System.Drawing.Size = Nothing
        Try
            img = System.Drawing.Image.FromFile(path)
            imgSize = New System.Drawing.Size(img.Width, img.Height)
        Catch ex As Exception
            Throw New Exception("不能打开的图片文件。", ex)
        Finally
            img = Nothing
        End Try

    End Function

    ''' <summary>
    ''' 图片修改尺寸设置
    ''' </summary>
    Public Class ResizeSetting

        Private _propTargetWidth As Int32
        ''' <summary>目标尺寸宽度</summary>
        Public Property TargetWidht() As Int32
            Get
                Return _propTargetWidth
            End Get
            Set(ByVal value As Int32)
                _propTargetWidth = value
            End Set
        End Property

        Private _propTargetHeight As Int32
        ''' <summary>目标尺寸高度</summary>
        Public Property TargetHeight() As Int32
            Get
                Return _propTargetHeight
            End Get
            Set(ByVal value As Int32)
                _propTargetHeight = value
            End Set
        End Property

        Private _propTargetNamePrefix As String = String.Empty
        ''' <summary>目标文件名前缀</summary>
        Public Property TargetNamePrefix() As String
            Get
                Return _propTargetNamePrefix
            End Get
            Set(ByVal value As String)
                _propTargetNamePrefix = value
            End Set
        End Property

        Private _propTargetNameSuffix As String = String.Empty
        ''' <summary>目标文件名后缀</summary>
        Public Property TargetNameSuffix() As String
            Get
                Return _propTargetNameSuffix
            End Get
            Set(ByVal value As String)
                _propTargetNameSuffix = value
            End Set
        End Property

        Private _propCompressionLevel As Long
        ''' <summary>压缩级别。范围1-100</summary>
        Public Property CompressionLevel() As Long
            Get
                Return _propCompressionLevel
            End Get
            Set(ByVal value As Long)
                If value > 100 OrElse value < 1 Then
                    value = 100
                End If
                _propCompressionLevel = value
            End Set
        End Property

        Private _propResizeMode As ResizeType = ResizeType.Auto
        ''' <summary>获取或设置尺寸修改模式</summary>
        Public Property ResizeMode() As ResizeType
            Get
                Return _propResizeMode
            End Get
            Set(ByVal value As ResizeType)
                _propResizeMode = value
            End Set
        End Property

        Private _propSavedPath As String = String.Empty
        ''' <summary>
        ''' 获取图片保存之后的路径
        ''' </summary>
        ''' <returns></returns>
        Public Property SavedPath() As String
            Get
                Return _propSavedPath
            End Get
            Friend Set(ByVal value As String)
                _propSavedPath = value
            End Set
        End Property

    End Class

    ''' <summary>
    ''' 修改指定目录下的所有图片的尺寸
    ''' </summary>
    ''' <param name="folderPath"></param>
    ''' <param name="saveFolder"></param>
    ''' <param name="setting"></param>
    ''' <returns></returns>
    Public Shared Function ResizeImagesInFolder(ByVal folderPath As String, ByVal saveFolder As String, ByVal setting As ResizeSetting)

    End Function


    ''' <summary>
    ''' 重新设定图片的尺寸。如果指定的保存路径是目录，则使用原文件名保存。
    ''' </summary>
    ''' <param name="imgPath">图片路径</param>
    ''' <param name="savePath">保存路径。如果是以\结尾，则表示保存路径为目录，否则保存路径为完整的保存文件名。</param>
    ''' <param name="setting">尺寸修改配置</param>
    ''' <returns></returns>
    Public Shared Function Resize(ByVal imgPath As String, ByVal savePath As String, ByVal setting As ResizeSetting)
        Return DoImageResize(imgPath, savePath, setting)
    End Function

    ''' <summary>
    ''' 压缩图片，并保存到源文件所在目录。如果未指定文件名前缀或者后缀，则自动添加后缀。
    ''' </summary>
    ''' <param name="imgPath">图片路径</param>
    ''' <param name="setting">尺寸修改配置</param>
    ''' <returns></returns>
    Public Shared Function Resize(ByVal imgPath As String, ByVal setting As ResizeSetting)
        Return DoImageResize(imgPath, "", setting)
    End Function


    Private Shared Function DoImageResize(ByVal imgPath As String,
                                          ByVal savePath As String,
                                          ByVal setting As ResizeSetting)

        ' 修改图片尺寸
        Dim _imgSource As System.Drawing.Image = Nothing
        Dim _imgFormat As System.Drawing.Imaging.ImageFormat = Nothing
        Dim _targetSize As System.Drawing.Size = Nothing

        If setting Is Nothing Then
            Throw New ArgumentNullException("必须指定修改设置", "setting")
        End If
        If Not System.IO.File.Exists(imgPath) Then
            Throw New ArgumentNullException("要修改的图片【" & imgPath & "】不存在。", "imgPath")
        End If

        'If setting.TargetWidht <= 0 AndAlso setting.TargetHeight <= 0 Then
        '    Throw New ApplicationException("必须指定目标尺寸的宽度或者长度")
        'End If

        If setting.ResizeMode = ResizeType.FixedWidth AndAlso setting.TargetWidht <= 0 Then
            Throw New ApplicationException("固定宽度模式，必须指定目标宽度")
        End If

        If setting.ResizeMode = ResizeType.FixedHeight AndAlso setting.TargetHeight <= 0 Then
            Throw New ApplicationException("固定高度模式，必须指定目标高度")
        End If


        ' /////////////////
        ' 处理保存路径
        ' /////////////////
        ' 如果没有设置保存路径，则保存目录为图片所在目录，文件名加后缀
        Dim tmpFileExt As String = System.IO.Path.GetExtension(imgPath)
        Dim tmpFileName As String = System.IO.Path.GetFileNameWithoutExtension(imgPath)
        Dim tmpFileFolder As String = System.IO.Path.GetDirectoryName(imgPath) & "\"
        If String.IsNullOrEmpty(savePath) Then
            If String.IsNullOrEmpty(setting.TargetNamePrefix) AndAlso String.IsNullOrEmpty(setting.TargetNameSuffix) Then
                savePath = tmpFileFolder & tmpFileName & "_[RESIZE" & DateTime.Now.ToString("yyyyMMddHHmmss") & "]" & tmpFileExt
            Else
                savePath = tmpFileFolder & setting.TargetNamePrefix & tmpFileName & setting.TargetNameSuffix & tmpFileExt
            End If
        Else
            ' 如果保存目录是以\结尾，则视为目录，否则视为文件。
            If savePath.EndsWith("\") Then
                If savePath <> tmpFileFolder Then
                    If Not System.IO.Directory.Exists(savePath) Then
                        System.IO.Directory.CreateDirectory(savePath)
                    End If
                    savePath = savePath & setting.TargetNamePrefix & tmpFileName & setting.TargetNameSuffix & tmpFileExt
                Else
                    If String.IsNullOrEmpty(setting.TargetNamePrefix) AndAlso String.IsNullOrEmpty(setting.TargetNameSuffix) Then
                        savePath = tmpFileFolder & tmpFileName & "_[RESIZE" & DateTime.Now.ToString("yyyyMMddHHmmss") & "]" & tmpFileExt
                    Else
                        savePath = tmpFileFolder & setting.TargetNamePrefix & tmpFileName & setting.TargetNameSuffix & tmpFileExt
                    End If
                End If
            Else
                tmpFileFolder = System.IO.Path.GetDirectoryName(savePath) & "\"
                If Not System.IO.Directory.Exists(tmpFileFolder) Then
                    System.IO.Directory.CreateDirectory(tmpFileFolder)
                End If
                savePath = tmpFileFolder & System.IO.Path.GetFileName(savePath)
            End If
        End If



        ' 尝试打开图片
        Try
            _imgSource = System.Drawing.Image.FromFile(imgPath)
        Catch ex As Exception
            Throw New ApplicationException("文件【" & imgPath & "】为无效的图片！")
        End Try
        ' 获取图片格式
        _imgFormat = _imgSource.RawFormat
        _targetSize = New System.Drawing.Size(_imgSource.Width, _imgSource.Height)

        Dim tmpWidht As Int32 = setting.TargetWidht
        Dim tmpHeight As Int32 = setting.TargetHeight
        ' 计算目标尺寸
        Select Case setting.ResizeMode
            Case ResizeType.FixedWidth '固定宽度压缩
                ' 先判断目标宽度与原尺寸宽度。如果目标宽度小于原始宽度，处理成新尺寸
                If setting.TargetWidht < _imgSource.Width Then
                    tmpHeight = (setting.TargetWidht * _imgSource.Height) / _imgSource.Width
                Else
                    setting.TargetWidht = _imgSource.Width
                    tmpHeight = (setting.TargetWidht * _imgSource.Height) / _imgSource.Width
                End If

            Case ResizeType.FixedHeight
                If setting.TargetHeight < _imgSource.Height Then
                    tmpWidht = (_imgSource.Width * setting.TargetHeight) / _imgSource.Height
                Else
                    setting.TargetHeight = _imgSource.Height
                    tmpWidht = (_imgSource.Width * setting.TargetHeight) / _imgSource.Height
                End If
            Case Else
                tmpWidht = _imgSource.Width
                tmpHeight = _imgSource.Height
        End Select

        _targetSize = New System.Drawing.Size(tmpWidht, tmpHeight)

        ' 按照新尺寸绘制新图片
        Dim b As System.Drawing.Bitmap = New System.Drawing.Bitmap(_targetSize.Width, _targetSize.Height)
        Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(b)
        g.Clear(System.Drawing.Color.Transparent)
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic


        g.DrawImage(_imgSource, 0, 0, _targetSize.Width, _targetSize.Height)

        g.Dispose()

        Dim newImgStream As System.IO.Stream = Compress(b, setting.CompressionLevel)

        Dim result As System.Drawing.Image = System.Drawing.Image.FromStream(newImgStream)

        result.Save(savePath, _imgFormat)

        setting.SavedPath = savePath

        Return True
    End Function


    Public Shared Function Resize(ByVal imgPath As String,
                                  ByVal savePath As String,
                                  ByVal targetWidth As Int32,
                                  ByVal targetHeight As Int32,
                                  ByVal mode As ResizeType,
                                  ByVal compressionLevel As Long)

        ' 修改图片尺寸
        Dim _imgSource As System.Drawing.Image = Nothing
        Dim _imgFormat As System.Drawing.Imaging.ImageFormat = Nothing
        Dim _targetSize As New System.Drawing.Size(targetWidth, targetHeight)

        If targetWidth <= 0 AndAlso targetHeight <= 0 Then
            Throw New ApplicationException("必须指定目标尺寸的宽度或者长度。")
        End If

        If mode = ResizeType.FixedHeight AndAlso targetHeight <= 0 Then
            Throw New ApplicationException("固定高度模式，必须指定修改的高度")
        End If

        If mode = ResizeType.FixedWidth AndAlso targetWidth <= 0 Then
            Throw New ApplicationException("固定宽度模式，必须指定修改的高度")
        End If

        ' 尝试打开图片
        Try
            _imgSource = System.Drawing.Image.FromFile(imgPath)
        Catch ex As Exception
            Throw New ApplicationException("文件【" & imgPath & "】为无效的图片！")
        End Try
        ' 获取图片格式
        _imgFormat = _imgSource.RawFormat

        Dim tmpWidht As Int32 = targetWidth
        Dim tmpHeight As Int32 = targetHeight
        ' 计算目标尺寸
        Select Case mode
            Case ResizeType.FixedWidth '固定宽度压缩
                ' 先判断目标宽度与原尺寸宽度。如果目标宽度小于原始宽度，处理成新尺寸
                If targetWidth < _imgSource.Width Then
                    tmpHeight = (targetWidth * _imgSource.Height) / _imgSource.Width
                Else
                    targetWidth = _imgSource.Width
                    tmpHeight = (targetWidth * _imgSource.Height) / _imgSource.Width
                End If

            Case ResizeType.FixedHeight
                If targetHeight < _imgSource.Height Then
                    targetWidth = (_imgSource.Width * targetHeight) / _imgSource.Height
                Else
                    targetHeight = _imgSource.Height
                    targetWidth = (_imgSource.Width * targetHeight) / _imgSource.Height
                End If
        End Select

        _targetSize = New System.Drawing.Size(tmpWidht, tmpHeight)
        ' 按照新尺寸绘制新图片
        Dim b As System.Drawing.Bitmap = New System.Drawing.Bitmap(_targetSize.Width, _targetSize.Height)
        Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(b)
        g.Clear(System.Drawing.Color.Transparent)
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic


        g.DrawImage(_imgSource, 0, 0, _targetSize.Width, _targetSize.Height)

        g.Dispose()

        Dim newImgStream As System.IO.Stream = Compress(b, compressionLevel)

        Dim result As System.Drawing.Image = System.Drawing.Image.FromStream(newImgStream)

        result.Save(savePath, _imgFormat)

        Return True
    End Function

    ''' <summary>
    ''' 图片重置大小的方式
    ''' </summary>
    Public Enum ResizeType
        ''' <summary>自动处理。</summary>
        Auto
        ''' <summary>
        ''' 高度固定模式，缩小或者放大图片。按照指定的高度，根据原图尺寸计算新的宽度。
        ''' </summary>
        FixedHeight
        ''' <summary>
        ''' 宽固定模式，缩小或者放大图片。按照指定的宽度，根据原图尺寸计算新的高度。
        ''' </summary>
        FixedWidth
        BothHeightAndWidth

    End Enum


    ''' <summary>
    ''' 将指定路径图片进行压缩，并保存到同目录下。
    ''' </summary>
    ''' <param name="imgPath"></param>
    ''' <param name="level"></param>
    ''' <returns></returns>
    Public Shared Function Compress(ByVal imgPath As String, ByVal level As Long) As Boolean
        Return Compress(imgPath, "", level)
    End Function

    ''' <summary>
    ''' 将图片按照指定级别进行压缩并保存到指定目录里。保存的文件名将添加压缩标记
    ''' </summary>
    ''' <param name="imgPath"></param>
    ''' <param name="savePath"></param>
    ''' <param name="level"></param>
    ''' <returns></returns>
    Public Shared Function Compress(ByVal imgPath As String, ByVal savePath As String, ByVal level As Long) As Boolean

        Return DoImageCompressOfFile(imgPath, savePath, level, True)

        Dim _imgBitmap As System.Drawing.Bitmap = Nothing
        Dim _encPara As System.Drawing.Imaging.EncoderParameter
        Dim _encParas As System.Drawing.Imaging.EncoderParameters
        Dim _imgEncoder As System.Drawing.Imaging.ImageCodecInfo = Nothing
        Dim _myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
        Dim _imgSaveName As String = String.Empty
        Dim _imgExt As String = String.Empty


        ' 验证图片是否存在
        If Not System.IO.File.Exists(imgPath) Then
            Throw New ApplicationException("要处理的图片【" & imgPath & "】不存在！")
        End If

        ' 指定了保存目录，则验证目录有效性，没有指定，则使用与文件相同的目录
        If Not String.IsNullOrEmpty(savePath) Then
            If Not System.IO.Directory.Exists(savePath) Then
                Throw New ApplicationException("保存目录【" & savePath & "】不存在！")
            End If
        Else
            savePath = System.IO.Path.GetDirectoryName(imgPath) & "\"
        End If

        ' 打开图片并验证图片有效性
        Try
            _imgBitmap = New System.Drawing.Bitmap(imgPath)
        Catch ex As Exception
            Throw New ApplicationException("文件【" + imgPath + "】不是有效的图片文件(" & ex.Message & ")")
        End Try

        _imgExt = System.IO.Path.GetExtension(imgPath)
        _imgSaveName = System.IO.Path.GetFileNameWithoutExtension(imgPath) & "_Compress" & DateTime.Now.ToString("yyyyMMddHHmmss") & _imgExt

        _imgEncoder = GetEncoder(System.Drawing.Imaging.ImageFormat.Jpeg)
        _encParas = New System.Drawing.Imaging.EncoderParameters(1)
        _encPara = New System.Drawing.Imaging.EncoderParameter(_myEncoder, level)
        _encParas.Param(0) = _encPara

        _imgBitmap.Save(savePath & _imgSaveName, _imgEncoder, _encParas)

        If (System.IO.File.Exists(savePath & _imgSaveName)) Then
            Return True
        End If

        Return False
    End Function

    ''' <summary>
    ''' 如果保存目录与原始目录不同，根据addSign确定是否添加标记到文件名。如果相同，则始终添加标记。
    ''' </summary>
    ''' <param name="imgPath"></param>
    ''' <param name="saveFolder"></param>
    ''' <param name="level"></param>
    ''' <param name="addSign"></param>
    ''' <returns></returns>
    Private Shared Function DoImageCompressOfFile(ByVal imgPath As String,
                                                  ByVal saveFolder As String,
                                                  ByVal level As Long,
                                                  ByVal addSign As Boolean)
        Dim _imgBitmap As System.Drawing.Bitmap = Nothing
        Dim _encPara As System.Drawing.Imaging.EncoderParameter
        Dim _encParas As System.Drawing.Imaging.EncoderParameters
        Dim _imgEncoder As System.Drawing.Imaging.ImageCodecInfo = Nothing
        Dim _myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
        Dim _imgSaveName As String = String.Empty
        Dim _imgExt As String = String.Empty
        Dim _imgSaveFullPath As String = String.Empty


        ' 验证图片是否存在
        If Not System.IO.File.Exists(imgPath) Then
            Throw New ApplicationException("要处理的图片【" & imgPath & "】不存在！")
        End If

        ' 指定了保存目录，则验证目录有效性，没有指定，则使用与文件相同的目录
        If Not String.IsNullOrEmpty(saveFolder) Then
            If Not System.IO.Directory.Exists(saveFolder) Then
                Throw New ApplicationException("保存目录【" & saveFolder & "】不存在！")
            End If
        Else
            saveFolder = System.IO.Path.GetDirectoryName(imgPath) & "\"
        End If

        ' 打开图片并验证图片有效性
        Try
            _imgBitmap = New System.Drawing.Bitmap(imgPath)
        Catch ex As Exception
            Throw New ApplicationException("文件【" + imgPath + "】不是有效的图片文件(" & ex.Message & ")")
        End Try

        _imgExt = System.IO.Path.GetExtension(imgPath)
        ' 指定添加标记或者保存目录与原文件目录相同的情况下，向文件名添加区别标识。
        If addSign OrElse String.IsNullOrEmpty(saveFolder) Then
            _imgSaveName = System.IO.Path.GetFileNameWithoutExtension(imgPath) & "_[CRS" & DateTime.Now.ToString("yyyyMMddHHmmss") & "]" & _imgExt
        Else
            _imgSaveName = System.IO.Path.GetFileName(imgPath)
        End If
        _imgSaveFullPath = saveFolder & _imgSaveName

        _imgEncoder = GetEncoder(System.Drawing.Imaging.ImageFormat.Jpeg)
        _encParas = New System.Drawing.Imaging.EncoderParameters(1)
        _encPara = New System.Drawing.Imaging.EncoderParameter(_myEncoder, level)
        _encParas.Param(0) = _encPara

        _imgBitmap.Save(_imgSaveFullPath, _imgEncoder, _encParas)

        If (System.IO.File.Exists(_imgSaveFullPath)) Then
            Return True
        End If

        Return False
    End Function


    ''' <summary>
    ''' 压缩图片，返回压缩之后的内存流文件。使用Jpeg图片编码压缩
    ''' </summary>
    ''' <param name="sourceImg">原图片</param>
    ''' <param name="level">压缩级别</param>
    ''' <returns></returns>
    Public Shared Function Compress(ByVal sourceImg As System.Drawing.Bitmap, ByVal level As Long) As Stream

        Return DoImageCompress(sourceImg, level, System.Drawing.Imaging.ImageFormat.Jpeg)

    End Function

    ''' <summary>
    ''' 按照指定的图片编码压缩图片，返回压缩之后的内存流文件
    ''' </summary>
    ''' <param name="sourceImg">原图片</param>
    ''' <param name="level">压缩级别</param>
    ''' <param name="imgFormat">图片格式</param>
    ''' <returns></returns>
    Public Shared Function Compress(ByVal sourceImg As System.Drawing.Bitmap, ByVal level As Long, ByVal imgFormat As System.Drawing.Imaging.ImageFormat) As Stream

        Return DoImageCompress(sourceImg, level, imgFormat)

    End Function

    Private Shared Function DoImageCompress(ByVal sourceImg As System.Drawing.Bitmap, ByVal level As Long, ByVal imgFormat As System.Drawing.Imaging.ImageFormat)
        If sourceImg Is Nothing Then
            Throw New ArgumentNullException("未指定要处理的图像", "sourceImg")
        End If

        If imgFormat Is Nothing Then
            Throw New ArgumentNullException("未指定图片处理的格式", "imgFormat")
        End If

        ' 如果压缩级别设置不正确，按照50处理
        If level < 0 OrElse level > 100 Then
            level = 50
        End If

        Dim _encPara As System.Drawing.Imaging.EncoderParameter
        Dim _encParas As System.Drawing.Imaging.EncoderParameters

        Dim imgEncoder As System.Drawing.Imaging.ImageCodecInfo = GetEncoder(imgFormat)
        Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality

        _encParas = New System.Drawing.Imaging.EncoderParameters(1)
        _encPara = New System.Drawing.Imaging.EncoderParameter(myEncoder, level)
        _encParas.Param(0) = _encPara

        Dim result As System.IO.Stream = New System.IO.MemoryStream()
        sourceImg.Save(result, imgEncoder, _encParas)

        Return result
    End Function


#End Region

    ''' <summary>
    ''' 根据图片格式对象获取图片的编解码器信息
    ''' </summary>
    ''' <param name="format"></param>
    ''' <returns></returns>
    Public Shared Function GetEncoder(ByVal format As System.Drawing.Imaging.ImageFormat) As System.Drawing.Imaging.ImageCodecInfo
        Dim codecs As System.Drawing.Imaging.ImageCodecInfo() = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()
        Dim codec As System.Drawing.Imaging.ImageCodecInfo
        For Each codec In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' 根据图片mime类型获取图片的编解码器信息
    ''' </summary>
    ''' <param name="mimeType"></param>
    ''' <returns></returns>
    Public Shared Function GetEncoder(ByVal mimeType As String) As System.Drawing.Imaging.ImageCodecInfo
        mimeType = mimeType.ToLower().Trim()
        Dim codecs As System.Drawing.Imaging.ImageCodecInfo() = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()
        Dim codec As System.Drawing.Imaging.ImageCodecInfo
        For Each codec In codecs
            If codec.MimeType.ToLower() = mimeType Then
                Return codec
            End If
        Next
        Return Nothing
    End Function


End Class
