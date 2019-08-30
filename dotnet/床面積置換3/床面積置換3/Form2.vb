Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            tbYuka.Text = tbYuka.Text.Replace("　", "")
            tbYuka.Text = tbYuka.Text.Replace("：", ".")

            Dim txtLine() As String
            txtLine = tbYuka.Lines

            Dim dblSum As Double
            Dim strTmp As String

            For n As Integer = 0 To txtLine.GetUpperBound(0)
                strTmp = StrConv(txtLine(n), VbStrConv.Narrow)
                strTmp = strTmp.Trim("0")

                If Strings.Right(strTmp, 1) = "." Then
                    strTmp = strTmp.Replace(".", "")
                End If

                'Debug.WriteLine(StrConv(txtLine(n), VbStrConv.Narrow))
                'Debug.WriteLine(strTmp)
                If strTmp <> "" Then
                    dblSum = dblSum + Double.Parse(strTmp)
                End If

            Next

            Clipboard.SetText(dblSum)
            tbSum.Text = dblSum

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub tbYuka_DoubleClick(sender As Object, e As EventArgs) Handles tbYuka.DoubleClick
        tbYuka.Text = ""
        tbSum.Text = ""
    End Sub
End Class
