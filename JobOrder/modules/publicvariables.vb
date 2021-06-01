Module publicvariables
    Public con As OleDb.OleDbConnection = jokenconn()
    Public Sub showform(f As Form)
        f.TopLevel = False
        f.TopMost = True
        Main.Panel1.Controls.Clear()
        Main.Panel1.Controls.Add(f)
        f.Show()
    End Sub
End Module
