Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim strNew As String = StrConv(tbKaoku.Text, VbStrConv.Wide)
        strNew = strNew.Replace(vbCrLf, "、")
        strNew = strNew.Replace(" ", "")
        strNew = strNew.Replace("　", "")
        strNew = strNew.TrimEnd("、")

        Dim strList As String()
        strList = Split(strNew, "、")

        Dim newList As New ArrayList
        For i As Integer = 0 To strList.Length - 1

            Dim flg As Boolean = newList.Contains(strList(i))
            If flg = False Then
                newList.Add(strList(i))
            End If

        Next

        strNew = ""
        Dim strNew2 As String = ""
        Dim strNew3 As String = ""
        Dim strNew4 As String = ""
        Dim strNew5 As String = ""
        Dim strNew6 As String = ""
        Dim strNew7 As String = ""
        Dim strNew8 As String = ""

        Dim count As Integer = 0
        For Each s As String In newList
            count += 1

            If count <= 20 Then
                strNew = strNew & "、" & s
                strNew = strNew.Trim("、")
                tbRep1.Text = strNew
                Clipboard.SetText(strNew)
            ElseIf count <= 40 Then
                strNew2 = strNew2 & "、" & s
                strNew2 = strNew2.Trim("、")
                tbRep2.Text = strNew2
            ElseIf count <= 60 Then
                strNew3 = strNew3 & "、" & s
                strNew3 = strNew3.Trim("、")
                tbRep3.Text = strNew3
            ElseIf count <= 80 Then
                strNew4 = strNew4 & "、" & s
                strNew4 = strNew4.Trim("、")
                tbRep4.Text = strNew4
            ElseIf count <= 100 Then
                strNew5 = strNew5 & "、" & s
                strNew5 = strNew5.Trim("、")
                tbRep5.Text = strNew5
            ElseIf count <= 120 Then
                strNew6 = strNew6 & "、" & s
                strNew6 = strNew6.Trim("、")
                tbRep6.Text = strNew6
            ElseIf count <= 140 Then
                strNew7 = strNew7 & "、" & s
                strNew7 = strNew7.Trim("、")
                tbRep7.Text = strNew7
            ElseIf count <= 160 Then
                strNew8 = strNew8 & "、" & s
                strNew8 = strNew8.Trim("、")
                tbRep8.Text = strNew8
            End If
        Next
        'strNew = strNew.Trim("、")
        'Clipboard.SetText(strNew)
        'tbRep1.Text = strNew
    End Sub

    Private Sub tbKaoku_DoubleClick(sender As Object, e As EventArgs) Handles tbKaoku.DoubleClick
        tbKaoku.Text = ""
        tbRep1.Text = ""
        tbRep2.Text = ""
        tbRep3.Text = ""
        tbRep4.Text = ""
        tbRep5.Text = ""
        tbRep6.Text = ""
        tbRep7.Text = ""
        tbRep8.Text = ""
        Label1.ForeColor = Color.Black
        Label2.ForeColor = Color.Black
        Label3.ForeColor = Color.Black
        Label4.ForeColor = Color.Black
        Label5.ForeColor = Color.Black
        Label6.ForeColor = Color.Black
        Label7.ForeColor = Color.Black
        Label8.ForeColor = Color.Black
    End Sub

    Private Sub tbRep1_Click(sender As Object, e As EventArgs) Handles tbRep1.Click
        Label1.ForeColor = Color.Red
        Label2.ForeColor = Color.Black
        Label3.ForeColor = Color.Black
        Label4.ForeColor = Color.Black
        Label5.ForeColor = Color.Black
        Label6.ForeColor = Color.Black
        Label7.ForeColor = Color.Black
        Label8.ForeColor = Color.Black
    End Sub

    Private Sub tbRep2_Click(sender As Object, e As EventArgs) Handles tbRep2.Click
        Label1.ForeColor = Color.Black
        Label2.ForeColor = Color.Red
        Label3.ForeColor = Color.Black
        Label4.ForeColor = Color.Black
        Label5.ForeColor = Color.Black
        Label6.ForeColor = Color.Black
        Label7.ForeColor = Color.Black
        Label8.ForeColor = Color.Black
    End Sub

    Private Sub tbRep3_Click(sender As Object, e As EventArgs) Handles tbRep3.Click
        Label1.ForeColor = Color.Black
        Label2.ForeColor = Color.Black
        Label3.ForeColor = Color.Red
        Label4.ForeColor = Color.Black
        Label5.ForeColor = Color.Black
        Label6.ForeColor = Color.Black
        Label7.ForeColor = Color.Black
        Label8.ForeColor = Color.Black
    End Sub

    Private Sub tbRep4_Click(sender As Object, e As EventArgs) Handles tbRep4.Click
        Label1.ForeColor = Color.Black
        Label2.ForeColor = Color.Black
        Label3.ForeColor = Color.Black
        Label4.ForeColor = Color.Red
        Label5.ForeColor = Color.Black
        Label6.ForeColor = Color.Black
        Label7.ForeColor = Color.Black
        Label8.ForeColor = Color.Black
    End Sub

    Private Sub tbRep5_Click(sender As Object, e As EventArgs) Handles tbRep5.Click
        Label1.ForeColor = Color.Black
        Label2.ForeColor = Color.Black
        Label3.ForeColor = Color.Black
        Label4.ForeColor = Color.Black
        Label5.ForeColor = Color.Red
        Label6.ForeColor = Color.Black
        Label7.ForeColor = Color.Black
        Label8.ForeColor = Color.Black
    End Sub

    Private Sub tbRep6_Click(sender As Object, e As EventArgs) Handles tbRep6.Click
        Label1.ForeColor = Color.Black
        Label2.ForeColor = Color.Black
        Label3.ForeColor = Color.Black
        Label4.ForeColor = Color.Black
        Label5.ForeColor = Color.Black
        Label6.ForeColor = Color.Red
        Label7.ForeColor = Color.Black
        Label8.ForeColor = Color.Black
    End Sub

    Private Sub tbRep7_Click(sender As Object, e As EventArgs) Handles tbRep7.Click
        Label1.ForeColor = Color.Black
        Label2.ForeColor = Color.Black
        Label3.ForeColor = Color.Black
        Label4.ForeColor = Color.Black
        Label5.ForeColor = Color.Black
        Label6.ForeColor = Color.Black
        Label7.ForeColor = Color.Red
        Label8.ForeColor = Color.Black
    End Sub

    Private Sub tbRep8_Click(sender As Object, e As EventArgs) Handles tbRep8.Click
        Label1.ForeColor = Color.Black
        Label2.ForeColor = Color.Black
        Label3.ForeColor = Color.Black
        Label4.ForeColor = Color.Black
        Label5.ForeColor = Color.Black
        Label6.ForeColor = Color.Black
        Label7.ForeColor = Color.Black
        Label8.ForeColor = Color.Red
    End Sub
End Class
