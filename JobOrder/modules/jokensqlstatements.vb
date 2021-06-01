Module jokensqlstatements
    Dim cmd As New OleDb.OleDbCommand
    Dim da As New OleDb.OleDbDataAdapter
    Dim table As New DataTable
    Public Sub jokenfindthis(ByVal sql As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        con.Close()
        da.Dispose()
    End Sub


    Public Sub checkresult()

        Dim table As New DataTable
        Try
            da.SelectCommand = cmd
            da.Fill(table)
            If table.Rows.Count > 0 Then
                Dim id As Integer
                Dim res, name As String
                res = table.Rows(0).Item(4)
                name = table.Rows(0).Item(1)
                id = table.Rows(0).Item(0)
                '  MsgBox(id)
                Main.userid.Text = id
                If res = "Administrator" Then
                    jokeninsert("INSERT INTO logs(userid,logindate)VALUES('" & id & "',#" & DateValue(Main.DateTimePicker1.Value) & "#)")
                    MsgBox("Welcome you log on as " & res)
                    Main.logintool.Text = "Log out"
                    Main.Guest.Text = name
                    Main.JobOrdertool.Visible = True
                    Main.paymentstool.Visible = True
                    Main.ManageUserToolStripMenuItem.Visible = True
                    Main.customertool.Visible = True
                    Main.ReportsToolStripMenuItem.Visible = True
                    Main.techToolStrip.Visible = True
                ElseIf res = "Manager" Then

                    jokeninsert("INSERT INTO logs(userid,logindate)VALUES('" & id & "',#" & DateValue(Main.DateTimePicker1.Value) & "#)")
                    MsgBox("Welcome you log on as " & res)
                    Main.logintool.Text = "Log out"
                    Main.Guest.Text = name
                    'Main.JobOrdertool.Visible = True
                    'Main.paymentstool.Visible = True
                    Main.ManageUserToolStripMenuItem.Visible = True
                    Main.customertool.Visible = True
                    Main.ReportsToolStripMenuItem.Visible = True
                    Main.techToolStrip.Visible = True
                ElseIf res = "Technician Incharge" Then
                    MsgBox("Welcome you log on as " & res)
                    jokeninsert("INSERT INTO logs(userid,logindate)VALUES('" & id & "',#" & DateValue(Main.DateTimePicker1.Value) & "#)")
                    'For Each ctrl As Control In Form1.Panel1.Controls
                    '    If ctrl.GetType Is GetType(Button) Then
                    '        ctrl.Show()
                    '        Form1.btnuser.Visible = False
                    '        Form1.btnlogin.Text = "Log out"
                    '        Form1.btnreports.SetBounds(18, 197, 127, 35)
                    '        Form1.btnexit.SetBounds(18, 238, 127, 35)
                    '        Form1.Text = name

                    '    End If
                    'Next
                    Main.logintool.Text = "Log out"
                    Main.Guest.Text = name
                    Main.JobOrdertool.Visible = True
                    Main.paymentstool.Visible = True
                    '  Main.ManageUserToolStripMenuItem.Visible = True
                    Main.customertool.Visible = True
                    Main.ReportsToolStripMenuItem.Visible = True
                    Main.techToolStrip.Visible = True
                    'ElseIf res = "Encoder" Then
                    '    MsgBox("Welcome you log on as " & res)
                    '    jokeninsert("INSERT INTO logs(userid,logindate)VALUES('" & id & "',#" & DateValue(Main.DateTimePicker1.Value) & "#)")
                    '    'For Each ctrl As Control In Form1.Panel1.Controls
                    '    '    If ctrl.GetType Is GetType(Button) Then
                    '    '        ctrl.Show()
                    '    '        Form1.btnuser.Visible = False
                    '    '        Form1.btnlogin.Text = "Log out"
                    '    '        Form1.btnreports.SetBounds(18, 154, 127, 35)
                    '    '        Form1.btnexit.SetBounds(18, 197, 127, 35)
                    '    '        Form1.btntransac.Visible = False
                    '    '        Form1.Text = name
                    '    '    End If
                    '    'Next

                End If

                Main.Show()
            Else
                MsgBox("Contact administrator to registered!")
                'Form1.Text = "Guest"
            End If
            login.Hide()
            login.txtuser.Clear()
            login.txtpass.Clear()
            login.txtuser.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub logintrue()

    End Sub
End Module
