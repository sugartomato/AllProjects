Imports System.Runtime.InteropServices

Namespace Structures.Rectangle

    ''' <summary>
    ''' The POINT structure defines the x- and y- coordinates of a point.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential, Pack:=0)>
    Public Structure POINT
        Public X As Int32
        Public Y As Int32

        Public Sub New(ByVal pX As Int32, ByVal pY As Int32)
            Me.X = pX
            Me.Y = pY
        End Sub
    End Structure

End Namespace

