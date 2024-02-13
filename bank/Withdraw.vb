Public Class Withdraw
    Private Sub Withdraw_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        TextBox1.Text = Login.acc
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim amount As Integer
        Dim cmd As New OleDb.OleDbCommand
        Dim con As New OleDb.OleDbConnection
        Dim sql As String

        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\HP\Desktop\final\Bank.accdb"
        con.Open()

        sql = "Select * from account Where Account_Number=" & Login.acc
        Dim da As New OleDb.OleDbDataAdapter(sql, con)
        Dim ds As New DataSet
        da.Fill(ds, "account")
        amount = ds.Tables("account").Rows(0).Item(6)

        sql = "Insert into Withdraw values(" & Val(TextBox1.Text) & "," & Val(TextBox2.Text) & ",'" & Now.Date & "')"
        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        cmd.Connection = con
        cmd.ExecuteNonQuery()

        sql = "Update account set Balance=Balance-" & Val(TextBox2.Text) & " where Account_Number=" & Login.acc
        cmd.CommandText = sql
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        MessageBox.Show(TextBox2.Text & " Sucessfully withdraw")
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Deposit.Show()
        Me.Close()
    End Sub
End Class
