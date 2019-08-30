Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.OleDb
Imports System.IO



Module Module1

    Sub Main()

        'Dim path As String = "C:\Users\r-kkc\Documents\Visual Studio 2015\Projects\稼働DB更新2\test"
        Dim path As String = "D:\WS\fukuoka_chiban\経費\201905"
        Dim files As String() = Directory.GetFiles(path, "*.xls", SearchOption.TopDirectoryOnly)
        'Dim dsn As String = "C:\Users\r-kkc\Documents\Visual Studio 2015\Projects\稼働DB更新2\test\稼働集計.mdb"
        Dim dsn As String = path & "\稼働集計.mdb"
        Dim accessMdb As AccessMdb = New AccessMdb()
        Dim now As DateTime = DateTime.Now
        accessMdb.Connect(dsn, -1)
        accessMdb.BeginTransaction()
        Dim sql As String = "DELETE * FROM 集計"
        accessMdb.ExecuteSql(sql, -1)
        accessMdb.CommitTransaction()
        accessMdb.Disconnect()

        For Each path2 As String In files
            Dim name As String = IO.Path.GetFileName(path2).Replace(".xls", "")
            Dim oleDbConnection As OleDbConnection = Nothing
            Dim oleDbDataAdapter As OleDbDataAdapter = Nothing
            Dim dataTable As DataTable = Nothing

            Console.WriteLine(name)

            Try
                Try
                    oleDbConnection = New OleDbConnection()
                    If System.IO.Path.GetExtension(path2).ToLower = "xlsx" Then
                        oleDbConnection.ConnectionString = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" &
                    System.IO.Path.GetFullPath(path2) & ";Extended Properties=Excel 12.0;"
                    Else
                        oleDbConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" &
                    System.IO.Path.GetFullPath(path2) & ";Extended Properties=Excel 8.0;"
                    End If
                    oleDbConnection.Open()
                Catch ex As Exception
                    Interaction.MsgBox("...EXCELオープン失敗", MsgBoxStyle.OkOnly, Nothing)
                    Exit Try
                End Try
                Dim selectCommandText As String = "SELECT * FROM [kinmu$E19:BQ39]"
                Try
                    oleDbDataAdapter = New OleDbDataAdapter(selectCommandText, oleDbConnection)
                    dataTable = New DataTable()
                    oleDbDataAdapter.Fill(dataTable)
                Catch ex2 As Exception
                    Interaction.MsgBox("...EXCELデータ取得失敗", MsgBoxStyle.OkOnly, Nothing)
                    Exit Try
                End Try
                Try
                    For Each obj As Object In dataTable.Rows

                        Dim dataRow As DataRow = CType(obj, DataRow)
                        If dataRow(63) = 0 Then
                            If dataRow(0) Is DBNull.Value Then
                                Exit For
                            End If
                        End If

                        Dim text2 As String
                        If dataRow(0) Is DBNull.Value Then
                            text2 = "物件名未記入"
                        Else
                            text2 = dataRow(0)
                        End If

                        Dim value As Double = dataRow(63)
                        Dim str As String = "values(" & "'" & now & "'" & "," & "'" & text2 & "'" & "," & "'" & name & "'" & "," & value & ")"
                        'Dim Val As String = "values(" & no & Year() & "," & Month() & "," & Day() & "," & "'" & Today & "'" & "," & "'" & name & "'" & "," & "'" & bukken & "'" & "," & kado & ")"
                        'MsgBox(str)
                        sql = "insert into 集計(日付,物件,氏名,時間) " + str
                        accessMdb.Connect(dsn, -1)
                        accessMdb.BeginTransaction()
                        accessMdb.ExecuteSql(sql, -1)
                        accessMdb.CommitTransaction()
                        accessMdb.Disconnect()
                    Next
                Catch ex3 As Exception
                    Interaction.MsgBox(ex3.Message, MsgBoxStyle.OkOnly, Nothing)
                    Exit Try
                End Try
            Finally

                If Not dataTable Is Nothing Then
                    dataTable.Clear()
                    dataTable.Dispose()
                End If
                dataTable = Nothing

                If Not oleDbDataAdapter Is Nothing Then
                    oleDbDataAdapter.Dispose()
                End If
                oleDbDataAdapter = Nothing

                If Not oleDbConnection Is Nothing Then
                    oleDbConnection.Close()
                    oleDbConnection.Dispose()
                End If
                oleDbConnection = Nothing

            End Try
        Next

    End Sub

End Module
