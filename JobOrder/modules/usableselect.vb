Module usableselect
    Dim cmd As New OleDb.OleDbCommand
    Dim da As New OleDb.OleDbDataAdapter
    Public total As Decimal
    Public Sub jokenselect(ByVal sql As String)
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
    Public Sub filltable(ByVal dtgrd As Object)
        Dim publictable As New DataTable
        Try
            da.SelectCommand = cmd
            da.Fill(publictable)
            dtgrd.DataSource = publictable
            dtgrd.Columns(0).Visible = False
            da.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try

    End Sub

    Public Sub fillitemtable(ByVal dtgrd As Object)
        Dim publictable As New DataTable
        Try
            da.SelectCommand = cmd
            da.Fill(publictable)
            dtgrd.DataSource = publictable
            dtgrd.Columns(0).Visible = False
            da.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
       
    End Sub

    Public Sub fillpaymentdata(ByVal dtgrd As Object)
        Dim publictable As New DataTable
        Try
            da.SelectCommand = cmd
            da.Fill(publictable)
            dtgrd.DataSource = publictable
            dtgrd.Columns(0).Visible = False
            dtgrd.Columns(10).Visible = False
            dtgrd.Columns(11).Visible = False
            dtgrd.Columns(12).Visible = False
            dtgrd.Columns(13).Visible = False
            dtgrd.Columns(14).Visible = False


            da.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try

    End Sub

    Public Sub clearall(ByVal group As Object, ByVal cleardtg As Object)
        For Each ctrl As Control In group.Controls
            If ctrl.GetType Is GetType(TextBox) Then
                ctrl.Text = Nothing
                cleardtg.DataSource = Nothing
            End If
        Next
    End Sub

    Public Sub cleartext(ByVal group As Object)
        For Each ctrl As Control In group.Controls
            If ctrl.GetType Is GetType(TextBox) Then
                ctrl.Text = Nothing

            End If
        Next
    End Sub

    'Public Sub fillcustdata()
    '    Dim publictable As New DataSet
    '    Try
    '        da.SelectCommand = cmd
    '        da.Fill(publictable, "jobdb")
    '        Payment.txtcustname.Text = publictable.Tables("jobdb").Rows(0).Item(2)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Information)
    '    End Try

    'End Sub
    Public Sub filltotaltable(ByVal dtgrd As Object)
        Dim publictable As New DataTable
        Try
            da.SelectCommand = cmd
            da.Fill(publictable)
            dtgrd.DataSource = publictable
            dtgrd.Columns(0).Visible = False

            da.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
        Try
            total = publictable.Compute("sum([Amount])", String.Empty)
            ' total = FormatNumber(total, 2)
            publictable.Rows.Add(Nothing, "Total Payments", Nothing, Nothing, "", total)

        Catch ex As Exception
            MsgBox("Amount Is not Available!", MsgBoxStyle.Information)
        End Try
       
    End Sub
    Public Sub filltotalcustmerpayments(ByVal dtgrd As Object)
        Dim publictable As New DataTable
        Try
            da.SelectCommand = cmd
            da.Fill(publictable)
            dtgrd.DataSource = publictable
            dtgrd.Columns(0).Visible = False

            da.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
        Try
            total = publictable.Compute("sum([Amount])", String.Empty)
            ' total = FormatNumber(total, 2)
            publictable.Rows.Add(Nothing, "Total Payments", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, "", total)

        Catch ex As Exception
            MsgBox("Amount Is not Available!", MsgBoxStyle.Information)
        End Try

    End Sub

End Module
