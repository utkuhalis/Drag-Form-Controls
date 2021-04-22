Public Class Form1

#Region "SÜRÜKLEME"
    Public Class DragInfo
        Public Property Farenin_ilk_Konumu As Point
        Public Property Baslama_Yeri As Point

        Public Sub New(ByVal MouseCoords As Point, ByVal Location As Point)
            Farenin_ilk_Konumu = MouseCoords
            Baslama_Yeri = Location
        End Sub

        Public Function NewLocation(ByVal MouseCoords As Point) As Point
            Dim yer As New Point(Baslama_Yeri.X + (MouseCoords.X - Farenin_ilk_Konumu.X), Baslama_Yeri.Y + (MouseCoords.Y - Farenin_ilk_Konumu.Y))
            Return yer
        End Function
    End Class
    Private Sub Sürükle(ByVal Control As Control)
        AddHandler Control.MouseDown, Sub(sender As Object, e As MouseEventArgs) StartDrag(Control)
        AddHandler Control.MouseMove, Sub(sender As Object, e As MouseEventArgs) Drag(Control)
        AddHandler Control.MouseUp, Sub(sender As Object, e As MouseEventArgs) StopDrag(Control)
    End Sub

    Private Sub StartDrag(ByVal Control As Control)
        Control.Tag = New DragInfo(Form.MousePosition, Control.Location)
    End Sub

    Private Sub Drag(ByVal Control As Control)
        If Control.Tag IsNot Nothing AndAlso TypeOf Control.Tag Is DragInfo Then
            Dim Bilgi As DragInfo = CType(Control.Tag, DragInfo)
            Dim Yeni_Yer As Point = Bilgi.NewLocation(Form.MousePosition)
            If Me.ClientRectangle.Contains(New Rectangle(Yeni_Yer, Control.Size)) Then Control.Location = Yeni_Yer
        End If
    End Sub

    Private Sub StopDrag(ByVal Control As Control)
        Control.Tag = Nothing
    End Sub
#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sürükle(Button1) 'Button1 Sürüklene Bilir
        'Sürükle(Button2) 'Button2 Sürüklenemez
    End Sub

End Class
