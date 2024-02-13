Public Class Password
    Dim pass As String
    Private Sub Password_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        TextBox1.Text = Register.count
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        pass = TextBox2.Text

        Dim cmd As New OleDb.OleDbCommand
        Dim con As New OleDb.OleDbConnection
        Dim sql As String

        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\HP\Desktop\final\Bank.accdb"
        con.Open()
        'made by gauravgehlot
        sql = "Insert into users values(" & Val(TextBox1.Text) & ",'" & pass & "')"
        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        con.Close()

        MessageBox.Show("Password Created!")
        Me.Hide()


    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
