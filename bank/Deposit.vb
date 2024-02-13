Public Class Deposit

    Private Sub Deposit_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        TextBox1.Text = Login.acc
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim con As New OleDb.OleDbConnection
        Dim sql As String
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\HP\Desktop\final\Bank.accdb"

        con.Open()
        sql = "Insert into Deposit values(" & Val(TextBox1.Text) & "," & Val(TextBox2.Text) & ",'" & Now.Date & "')"
        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        cmd.Connection = con
        cmd.ExecuteNonQuery()

        sql = "Update account set Balance=Balance+" & Val(TextBox2.Text) & " Where Account_Number=" & Login.acc
        cmd.CommandText = sql
        cmd.Connection = con
        cmd.ExecuteNonQuery()

        MessageBox.Show(TextBox2.Text & " Sucessfully Deposited")
        con.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Withdraw.Show()
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
