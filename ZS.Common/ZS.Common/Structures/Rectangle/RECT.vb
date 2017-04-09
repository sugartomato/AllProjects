Imports System.Runtime.InteropServices

Namespace Structures.Rectangle


    ''' <summary>
    ''' The RECT Structure defines the coordinates Of the upper-left And lower-right corners Of a rectangle.
    ''' </summary>
    ''' <link ref="https://msdn.microsoft.com/en-us/library/dd162897(v=vs.85).aspx"></link>
    <StructLayout(LayoutKind.Sequential, Pack:=0)>
    Public Structure RECT

        ''' <summary>
        ''' The x-coordinate of the upper-left corner of the rectangle.
        ''' </summary>
        Public left As Int64
        ''' <summary>
        ''' The y-coordinate of the upper-left corner of the rectangle.
        ''' </summary>
        Public top As Int64
        ''' <summary>
        ''' The x-coordinate of the lower-right corner of the rectangle.
        ''' </summary>
        Public right As Int64
        ''' <summary>
        ''' The y-coordinate of the lower-right corner of the rectangle.
        ''' </summary>
        Public bottom As Int64

        ''' <summary>
        ''' 矩形宽度
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property width
            Get
                Return Math.Abs(right - left)
            End Get
        End Property

        Public ReadOnly Property height
            Get
                Return Math.Abs(bottom - top)
            End Get
        End Property


        Public Sub New(ByVal pLeft As Int64, ByVal pTop As Int64, ByVal pRight As Int64, ByVal pBottom As Int64)
            With Me
                .left = pLeft
                .top = pTop
                .right = pRight
                .bottom = pBottom
            End With
        End Sub

        Public Sub New(ByVal src As RECT)
            With Me
                .left = src.left
                .top = src.top
                .right = src.right
                .bottom = src.bottom
            End With
        End Sub



    End Structure

End Namespace

