﻿Module Module1

    Sub Main()

        Try
            Dim args() As String = Environment.GetCommandLineArgs
            Dim strPath As String = ""

            For i As Integer = 0 To args.Length - 1
                strPath = args(i)
            Next

            Dim fList As String() = System.IO.Directory.GetDirectories(strPath)
            Dim dtToday As DateTime = Today
            Dim dtUpdate As DateTime
            Dim diff As Integer

            For Each f In fList

                dtUpdate = IO.Directory.GetLastWriteTime(f)
                diff = (dtToday - dtUpdate).TotalDays

                If diff > 180 Then
                    Try
                        IO.Directory.Delete(f, True)
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End If
            Next

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

End Module
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             