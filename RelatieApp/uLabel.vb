Imports System.Drawing.Drawing2D

Public Class uLabel
    Inherits Label
    Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim formGraphics As Graphics = e.Graphics
        Dim gradientBrush As New LinearGradientBrush(New Point(0, 0), New Point(Width, 0), Color.LightBlue, Color.White)

        formGraphics.FillRectangle(gradientBrush, ClientRectangle)
        Dim myfont As New Font("Sans Serif", 12, FontStyle.Bold)
        Me.Font = myfont
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or _
            ControlStyles.DoubleBuffer Or _
            ControlStyles.ResizeRedraw Or _
            ControlStyles.UserPaint, _
            True)

        Me.ForeColor = Color.WhiteSmoke

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
