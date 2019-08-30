Imports System.Data.OleDb

Public Class AccessMdb

    ''' <summary>
    ''' SQLコネクション
    ''' </summary>
    Private _con As OleDbConnection = Nothing

    ''' <summary>
    ''' トランザクション・オブジェクト
    ''' </summary>
    ''' <remarks></remarks>
    Private _trn As OleDbTransaction = Nothing

    ''' <summary>
    ''' DB接続
    ''' </summary>
    ''' <param name="dsn">データソース名</param>
    ''' <param name="tot">タイムアウト値</param>
    ''' <remarks></remarks>
    Public Sub Connect(ByVal dsn As String, ByVal tot As Integer)

        Try
            If _con Is Nothing Then
                _con = New OleDbConnection
            End If

            Dim cst As String = ""
            cst = cst & "Provider=Microsoft.Jet.OLEDB.4.0"
            cst = cst & ";Data Source=" & dsn
            ' データベースパスワードが設定されている場合
            ' cst = cst & ";Jet OLEDB:Database Password=xxxxx"
            If tot > -1 Then
                '_con.ConnectionTimeout = tot
                cst = cst & ";Connect Timeout=" & tot.ToString
            End If
            _con.ConnectionString = cst

            _con.Open()
        Catch ex As Exception
            Throw New Exception("Connect Error", ex)
        End Try
    End Sub

    ''' <summary>
    ''' DB切断
    ''' </summary>
    Public Sub Disconnect()
        Try
            _con.Close()
        Catch ex As Exception
            Throw New Exception("Disconnect Error", ex)
        End Try
    End Sub

    ''' <summary>
    ''' SQLの実行
    ''' </summary>
    ''' <param name="sql">SQL文</param>
    ''' <param name="tot">タイムアウト値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExecuteSql(ByVal sql As String, _
                               Optional ByVal tot As Integer = -1) As DataTable
        Dim dt As New DataTable

        Try
            Dim sqlCommand As New OleDbCommand(sql, _con, _trn)

            If tot > -1 Then
                sqlCommand.CommandTimeout = tot
            End If

            Dim adapter As New OleDbDataAdapter(sqlCommand)

            adapter.Fill(dt)
            adapter.Dispose()
            sqlCommand.Dispose()
        Catch ex As Exception
            Throw New Exception("ExecuteSql Error", ex)
        End Try

        Return dt
    End Function

    ''' <summary>
    ''' トランザクション開始
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub BeginTransaction()
        Try
            _trn = _con.BeginTransaction()
        Catch ex As Exception
            Throw New Exception("BeginTransaction Error", ex)
        End Try
    End Sub

    ''' <summary>
    ''' コミット
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CommitTransaction()
        Try
            If _trn Is Nothing = False Then
                _trn.Commit()
            End If
        Catch ex As Exception
            Throw New Exception("CommitTransaction Error", ex)
        Finally
            _trn = Nothing
        End Try
    End Sub

    ''' <summary>
    ''' ロールバック
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RollbackTransaction()
        Try
            If _trn Is Nothing = False Then
                _trn.Rollback()
            End If
        Catch ex As Exception
            Throw New Exception("RollbackTransaction Error", ex)
        Finally
            _trn = Nothing
        End Try
    End Sub

    ''' <summary>
    ''' ファイナライズ
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub Finalize()
        Disconnect()
        MyBase.Finalize()
    End Sub
End Class
