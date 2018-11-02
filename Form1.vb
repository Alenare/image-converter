Public Class Converter1

    Structure COLORTYPE
        Dim RED As Integer
        Dim BLUE As Integer
        Dim GREEN As Integer
    End Structure

    Structure DATATYPE
        Dim Type As String
        Dim col As Integer
        Dim row As Integer
        Dim MAX As Integer
    End Structure

    Dim textfile As String

    Dim PixelH As DATATYPE

    Dim ColorH(0, 0) As COLORTYPE

    Dim n As Integer

    Sub DisplayImage()

        Dim b As Bitmap = New Bitmap(PixelH.col, PixelH.row)

        For y As Integer = 0 To PixelH.row - 1
            For x As Integer = 0 To PixelH.col - 1
                b.SetPixel(x, y, Color.FromArgb(ColorH(y, x).RED, ColorH(y, x).GREEN, ColorH(y, x).BLUE))
            Next
        Next

        PictureBox1.Width = PixelH.col - 1
        PictureBox1.Height = PixelH.row - 1
        PictureBox1.Image = b
    End Sub
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
        textfile = OpenFileDialog1.FileName

        Dim image() As String = IO.File.ReadAllLines(textfile)
        Dim tmpStr() As String = image(1).Split(" "c)
        Dim j, k As Integer
        n = image.Count - 1
        PixelH.Type = image(0)
        PixelH.row = tmpStr(1)
        PixelH.col = tmpStr(0)
        PixelH.MAX = image(2)

        ReDim ColorH(PixelH.row - 1, PixelH.col - 1)

        For i As Integer = 3 To n
            image(i) = RTrim(image(i))
            Dim tmp() As String = image(i).Split(" "c)
            For x As Integer = 0 To tmp.Length - 1
                ColorH(k, j).RED = tmp(x)
                ColorH(k, j).GREEN = tmp(x + 1)
                ColorH(k, j).BLUE = tmp(x + 2)
                x = x + 2
                j = j + 1
                If j = PixelH.col Then
                    j = 0
                    k = k + 1
                End If
            Next
        Next
        DisplayImage()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub DisplayImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisplayImageToolStripMenuItem.Click

        Dim b As Bitmap = New Bitmap(PixelH.col, PixelH.row)

        For y As Integer = 0 To PixelH.row - 1
            For x As Integer = 0 To PixelH.col - 1
                b.SetPixel(x, y, Color.FromArgb(ColorH(y, x).RED, ColorH(y, x).GREEN, ColorH(y, x).BLUE))
            Next
        Next

        PictureBox1.Width = PixelH.col - 1
        PictureBox1.Height = PixelH.row - 1
        PictureBox1.Image = b
    End Sub

//Flattens Need Improvement
    Private Sub FlattenRedToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles FlattenRedToolStripMenuItem.Click
        Dim b As Bitmap = New Bitmap(PixelH.col, PixelH.row)

        For y As Integer = 0 To PixelH.row - 1
            For x As Integer = 0 To PixelH.col - 1
                b.SetPixel(x, y, (Color.FromArgb(ColorH(0, x).RED, ColorH(y, x).GREEN, ColorH(y, x).BLUE)))
            Next
        Next

        PictureBox1.Width = PixelH.col - 1
        PictureBox1.Height = PixelH.row - 1
        PictureBox1.Image = b
    End Sub

//Flattens Need Improvement
    Private Sub FlattenGreenToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles FlattenGreenToolStripMenuItem.Click
        Dim b As Bitmap = New Bitmap(PixelH.col, PixelH.row)

        For y As Integer = 0 To PixelH.row - 1
            For x As Integer = 0 To PixelH.col - 1
                b.SetPixel(x, y, Color.FromArgb(ColorH(y, x).RED, ColorH(0, x).GREEN, ColorH(y, x).BLUE))
            Next
        Next

        PictureBox1.Width = PixelH.col - 1
        PictureBox1.Height = PixelH.row - 1
        PictureBox1.Image = b
    End Sub

//Flattens Need Improvement
    Private Sub FlattenBlueToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles FlattenBlueToolStripMenuItem.Click
        Dim b As Bitmap = New Bitmap(PixelH.col, PixelH.row)

        For y As Integer = 0 To PixelH.row - 1
            For x As Integer = 0 To PixelH.col - 1
                b.SetPixel(x, y, Color.FromArgb(ColorH(y, x).RED, ColorH(y, x).GREEN, ColorH(0, x).BLUE))
            Next
        Next

        PictureBox1.Width = PixelH.col - 1
        PictureBox1.Height = PixelH.row - 1
        PictureBox1.Image = b
    End Sub

    Private Sub GreyScaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GreyScaleToolStripMenuItem.Click
        Dim sum As Integer
        Dim b As Bitmap = New Bitmap(PixelH.col, PixelH.row)

        For y As Integer = 0 To PixelH.row - 1
            For x As Integer = 0 To PixelH.col - 1
                sum = (ColorH(y, x).RED + ColorH(y, x).GREEN + ColorH(y, x).BLUE) / 3
                b.SetPixel(x, y, (Color.FromArgb(sum, sum, sum)))
            Next
        Next

        PictureBox1.Width = PixelH.col - 1
        PictureBox1.Height = PixelH.row - 1
        PictureBox1.Image = b
    End Sub

    Private Sub FlipHorizontalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FlipHorizontalToolStripMenuItem.Click

        Dim b As Bitmap = New Bitmap(PixelH.col, PixelH.row)

        For y As Integer = PixelH.row -1 To 0 Step -1
            For x As Integer = PixelH.col - 1 To 0 Step -1
                b.SetPixel(x, y, Color.FromArgb(ColorH(y, x).RED, ColorH(y, x).GREEN, ColorH(y, x).BLUE))
            Next
        Next

        PictureBox1.Width = PixelH.col - 1
        PictureBox1.Height = PixelH.row - 1
        PictureBox1.Image = b
        PictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
    End Sub

    Private Sub NegateRedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NegateRedToolStripMenuItem.Click
        Dim b As Bitmap = New Bitmap(PixelH.col, PixelH.row)
        Dim negRed As Integer
        For y As Integer = 0 To PixelH.row - 1
            For x As Integer = 0 To PixelH.col - 1
                negRed = 255 - ColorH(y, x).RED
                b.SetPixel(x, y, (Color.FromArgb(negRed, ColorH(y, x).GREEN, ColorH(y, x).BLUE)))
            Next
        Next

        PictureBox1.Width = PixelH.col - 1
        PictureBox1.Height = PixelH.row - 1
        PictureBox1.Image = b
    End Sub

    Private Sub NegateBlueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NegateBlueToolStripMenuItem.Click
        Dim b As Bitmap = New Bitmap(PixelH.col, PixelH.row)
        Dim negBlue As Integer
        For y As Integer = PixelH.row - 1 To 0 Step -1
            For x As Integer = PixelH.col - 1 To 0 Step -1
                negBlue = 255 - ColorH(y, x).BLUE
                b.SetPixel(x, y, Color.FromArgb(ColorH(y, x).RED, ColorH(y, x).GREEN, negBlue))
            Next
        Next

        PictureBox1.Width = PixelH.col - 1
        PictureBox1.Height = PixelH.row - 1
        PictureBox1.Image = b
    End Sub

    Private Sub NegateGreenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NegateToolStripMenuItem.Click
        Dim b As Bitmap = New Bitmap(PixelH.col, PixelH.row)
        Dim negGreen As Integer
        For y As Integer = 0 To PixelH.row - 1
            For x As Integer = 0 To PixelH.col - 1
                negGreen = 255 - ColorH(y, x).GREEN
                b.SetPixel(x, y, Color.FromArgb(ColorH(y, x).RED, negGreen, ColorH(y, x).BLUE))
            Next
        Next

        PictureBox1.Width = PixelH.col - 1
        PictureBox1.Height = PixelH.row - 1
        PictureBox1.Image = b
    End Sub
End Class
