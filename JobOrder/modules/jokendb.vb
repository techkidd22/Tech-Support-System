Module jokendb

    Public Function jokenconn() As OleDb.OleDbConnection
        Return New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\jobdb.mdb")
    End Function
End Module
