Public Class Search
    Dim count, acc, increase As Integer
    Private Sub Search_Closed(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Closed
        Login.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim sql, table, date1, date2 As String
        Dim dt As New DataTable
        dt.Clear()

        If TextBox1.Text <> "" Then
            sql = "Select Customer_Name as [Name],[Account_Number] as [Account Number],Balance from account where [Customer_Name]=" & "'" & TextBox1.Text & "'"
            table = "account"
            dt.Merge(Search(sql, table, 1))
            dt.DefaultView.Sort = "Account Number ASC"

        ElseIf TextBox2.Text <> "" Then
            sql = "Select Account_Number as [Account Number],Amount as [Credit],[_Date] as [Date] from deposit Where Account_Number=" & Val(TextBox2.Text)
            table = "deposit"
            dt.Merge(Search(sql, table, 2))

            sql = "select Account_Number as [Account Number],Amount as [Debit],[_Date] as [Date] from withdraw Where Account_Number=" & Val(TextBox2.Text)
            table = "withdraw"
            dt.Merge(Search(sql, table, 2))

            sql = "select Balance from account where Account_Number=" & Val(TextBox2.Text)
            table = "account"
            dt.Merge(Search(sql, table, 2))
            'all code are made by gauravgehlot
        Else
            date1 = DateTimePicker1.Value.ToShortDateString
            date2 = DateTimePicker2.Value.ToShortDateString

            If DateTimePicker2.Checked = False Then
                sql = "Select Account_Number as [Account Number],Amount as [Credit],[_Date] as [Date] from deposit Where [_Date]= #" & date1 & "#"
                table = "deposit"
                dt.Merge(Search(sql, table, 2))

                sql = "Select Account_Number as [Account Number],Amount as [Debit],[_Date] as [Date] from withdraw Where [_Date]=#" & date1 & "#"
                table = "withdraw"
                dt.Merge(Search(sql, table, 2))
            Else
                sql = "Select Account_Number as [Account Number],Amount as [Credit],[_Date] as [Date] from deposit where [_Date] between #" & date2 & "# and #" & date1 & "#"
                table = "deposit"
                dt.Merge(Search(sql, table, 2))

                sql = "Select Account_Number as [Account Number],Amount as [Debit],[_Date] as [Date] from withdraw where [_Date] between #" & date2 & "# and #" & date1 & "#"
                table = "withdraw"
                dt.Merge(Search(sql, table, 2))
            End If
        End If

        DataGridView1.DataSource = dt
        count = 0
        acc = 0
        increase = 0
    End Sub

    Function Search(ByRef sql As String, ByVal table As String, ByVal num As Integer) As DataTable
        Dim dt As DataTable
        Dim query As String
        If num = 1 Then
            dt = Execution(sql, table)
            Accno(sql)

            For i = 0 To count - 1
                query = "Select [Account_Number] as [Account Number],Amount as [Credit],[_Date] as [Date] from deposit where Account_Number=" & acc
                table = "deposit"
                dt.Merge(Execution(query, table))
                query = "Select [Account_Number] as [Account Number],Amount as [Debit],[_Date] as [Date] from withdraw where Account_Number=" & acc
                table = "withdraw"
                dt.Merge(Execution(query, table))
                Accno(sql)
            Next
            Return dt

        Else
            dt = Execution(sql, table)
            Return dt

        End If
    End Function

    Function Execution(ByRef query As String, ByRef table As String) As DataTable
        Dim con As New OleDb.OleDbConnection
        Dim dt As DataTable
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\HP\Desktop\final\Bank.accdb"
        con.Open()
        Dim da As New OleDb.OleDbDataAdapter(query, con)
        Dim ds As New DataSet
        da.Fill(ds, table)
        dt = ds.Tables(table)
        con.Close()
        Return dt
    End Function

    Sub Accno(ByRef query As String)
        Dim con As New OleDb.OleDbConnection
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\HP\Desktop\final\Bank.accdb"
        con.Open()
        Dim da As New OleDb.OleDbDataAdapter(query, con)
        Dim ds As New DataSet
        da.Fill(ds, "account")
        count = ds.Tables("account").Rows.Count()
        If increase < count Then
            acc = ds.Tables("account").Rows(increase).Item(1)
        End If
        increase += 1
        con.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim url As String = "https://www.gauravgehlot.in"
        Process.Start(url)
    End Sub
End Class
