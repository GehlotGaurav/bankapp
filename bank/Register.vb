Public Class Register
    Public count As Integer

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Please enter your name")
        ElseIf TextBox2.Text.Length <> 10 Then
            MessageBox.Show("Wrong contact number")
        ElseIf TextBox4.Text = "" Then
            MessageBox.Show("Select your state")
        ElseIf Val(TextBox6.Text) < 1000 Then
            MessageBox.Show("Minimum balance should be least 1000")
        Else
            Dim cmd As New OleDb.OleDbCommand
            Dim con As New OleDb.OleDbConnection
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\HP\Desktop\final\Bank.accdb"

            con.Open()
            Dim sql As String
            sql = "select * from account"
            Dim da As New OleDb.OleDbDataAdapter(sql, con)
            Dim ds As New DataSet
            da.Fill(ds, "account")
            'made by gauravgehlot
            count = ds.Tables("account").Rows.Count()
            count = 1000 + count

            sql = "Insert into account values(" & count & ",'" & TextBox1.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "'," & TextBox2.Text & "," & TextBox6.Text & ")"
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            cmd.Connection = con

            If cmd.ExecuteNonQuery().Equals(1) Then
                ACC(cmd, con)
                MessageBox.Show("Account Created!")
                Password.Show()
                Me.Close()
            End If

            con.Close()
        End If
    End Sub

    Sub ACC(ByRef cmd As OleDb.OleDbCommand, ByRef con As OleDb.OleDbConnection)
        Dim sql As String
        sql = "Insert into Deposit values(" & count & "," & Val(TextBox5.Text) & ",'" & Now.Date & "')"
        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        cmd.Connection = con
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub Register_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
