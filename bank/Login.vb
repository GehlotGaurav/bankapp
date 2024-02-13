Public Class Login
    Public acc As Integer

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim con As New OleDb.OleDbConnection
        Dim sql, password As String
        Dim user As Integer

        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\HP\Desktop\final\Bank.accdb"
        con.Open()
        sql = "select * from users Where [User_Id]=" & Val(TextBox1.Text)
        Dim da As New OleDb.OleDbDataAdapter(sql, con)
        Dim ds As New DataSet
        da.Fill(ds, "users")

        If ds.Tables("users").Rows.Count > 0 Then
            user = ds.Tables("users").Rows(0).Item(0)
            password = ds.Tables("users").Rows(0).Item(1)
        Else
            MessageBox.Show("Wrong Username")
            Exit Sub
        End If

        If TextBox1.Text = user And TextBox2.Text = password Then
            acc = user
            Deposit.Show()
            Hide()
        Else
            MessageBox.Show("Wrong Password")
        End If
        con.Close()
    End Sub

    Private Sub Label3_Click(ByVal sender As Object, ByVal e As EventArgs)
        Register.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Search.Show()
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'made by gauravgehlot
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Register.Show()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Register.Show()

    End Sub
End Class
