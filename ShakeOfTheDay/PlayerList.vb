Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class PlayerList

    ' Declare selectedPatron as Patron class
    Public Property selectedPatron As Patron

    ' Folder location for images
    Dim folder As String = "C:\Users\Dylan\Desktop\ShakeOfTheDay"

    ' BindingList for Patron objects
    Dim patrons As New BindingList(Of Patron)

    ' Variable to hold last used Id and house money in patrons tables
    Dim lastPatronId As Integer
    Dim houseMoney As Integer

    ' When the form loads
    Private Sub PlayerList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Center to screen and hide appropriate text and buttons
        Me.CenterToScreen()
        txtName.Hide()
        lblName.Text = ""
        lblMoneyText.Hide()
        lblMoney.Text = ""
        btnSign.Hide()
        btnDelete.Enabled = False

        ' Atm and Beer images
        ptrAtm.Visible = False
        ptrAtm.Image = Image.FromFile(System.IO.Path.Combine(folder, "images/atm" & ".png"))
        ptrBeer.Image = Image.FromFile(System.IO.Path.Combine(folder, "images/beer" & ".png"))

        ' Load ListBox
        lbxPatrons.DataSource = patrons
        lbxPatrons.DisplayMember = "DisplayInfo"


        ' Create a SqlConnection to DB path
        Dim dbConnection As SqlConnection = connectToDb()

        ' Open Connection
        dbConnection.Open()

        ' Query for the last IDs used in the database
        Dim identSqlString As String = "SELECT IDENT_CURRENT('Patrons')"

        ' Declare id commands to get last ID
        Dim identCommand As New SqlCommand(identSqlString, dbConnection)

        ' Get last patron id
        Try
            Dim identReader As SqlDataReader = identCommand.ExecuteReader()
            identReader.Read()
            ' Store the last used ID
            lastPatronId = CInt(identReader.Item(0))
            identReader.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        ' Write sql select statement for patrons
        Dim sqlString As String = "SELECT * FROM Patrons"

        Dim selectCommand As New SqlCommand(sqlString, dbConnection)

        ' Declare patronResults as the select statment
        Dim patronResults As SqlDataReader = selectCommand.ExecuteReader()

        ' Parse the patron result set
        While patronResults.Read()

            ' Create patron objects from the data
            Dim dbPatron As New Patron()

            ' Fill in dbPatron info which gets added to the list
            dbPatron.Name = patronResults.Item("Name").ToString()
            dbPatron.Money = CInt(patronResults.Item("Money"))
            dbPatron.Give = CInt(patronResults.Item("Give"))
            dbPatron.Won = CInt(patronResults.Item("Won"))
            dbPatron.MoneyWon = CInt(patronResults.Item("MoneyWon"))
            dbPatron.Played = CInt(patronResults.Item("Played"))
            dbPatron.HouseMoney = CInt(patronResults.Item("HouseMoney"))
            ' Checks to see if house money is less than 10
            If dbPatron.HouseMoney < 10 Then
                dbPatron.HouseMoney = 10
            End If
            lblHouse.Text = "$" & dbPatron.HouseMoney
            houseMoney = dbPatron.HouseMoney

            dbPatron.Id = CInt(patronResults.Item("Id"))

            ' Add our male objects to the male list
            ' Clears selected user to make sure our click event works
            patrons.Add(dbPatron)
            selectedPatron = dbPatron
            lbxPatrons.ClearSelected()

        End While
        patronResults.Close()

    End Sub

    ' When you click new patron button
    Private Sub btnPatron_Click(sender As Object, e As EventArgs) Handles btnPatron.Click
        ' Shows and hides appropriate buttons, text and images
        txtName.Show()
        btnSign.Show()
        btnDelete.Enabled = False
        lbxPatrons.ClearSelected()
        ptrAtm.Visible = False
        lblName.Text = ""
        lblMoneyText.Hide()
        lblMoney.Text = ""

    End Sub

    ' When you click the enter the bar button
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click

        ' Creates new ShakeForm object and passes over patron info
        Dim openShake As New ShakeForm
        openShake.thisPatron = selectedPatron
        openShake.Show()
        Me.Hide()

    End Sub

    ' When you click the sign me up button
    Private Sub btnSign_Click(sender As Object, e As EventArgs) Handles btnSign.Click
        ' Checks to see if txtName is empty
        If txtName.Text.Trim.Length = 0 Then
            txtName.Clear()
            MessageBox.Show("Please enter a name.")
        Else
            ' If not emptry create new Patron
            Dim newPatron As New Patron
            ' Info thats needs to be passed to the next page
            newPatron.Name = txtName.Text
            newPatron.Money = 20.0

            ' Add patron to patrons list
            selectedPatron = newPatron
            patrons.Add(newPatron)

            ' Hides name textbox and sign me up button
            txtName.Hide()
            btnSign.Hide()

            ' Connects to the Patrons table and inserts new info
            Dim dbConnection As SqlConnection = connectToDb()
            dbConnection.Open()
            Dim sqlString As String

            ' Enter new patron into patrons table
            sqlString = "INSERT INTO Patrons (Name, Money, Give, Won, MoneyWon, Played, HouseMoney) VALUES (@name, @money, @give, @won, @moneyWon, @played, @houseMoney)"

            ' Give new ID
            newPatron.Id = lastPatronId + 1
            lastPatronId += 1
            newPatron.HouseMoney = houseMoney

            ' Create a sql command to interact with the database
            Dim saveCommand As New SqlCommand(sqlString, dbConnection)

            ' Saves new patron info into the database
            saveCommand.Parameters.AddWithValue("@name", newPatron.Name)
            saveCommand.Parameters.AddWithValue("@money", 20.0)
            saveCommand.Parameters.AddWithValue("@give", 0)
            saveCommand.Parameters.AddWithValue("@won", 0)
            saveCommand.Parameters.AddWithValue("@moneyWon", 0)
            saveCommand.Parameters.AddWithValue("@played", 0)
            saveCommand.Parameters.AddWithValue("@houseMoney", houseMoney)

            ' Catch exception for new patron
            Try
                If saveCommand.ExecuteNonQuery > 0 Then
                    MessageBox.Show("You have $20 to start good luck!")
                Else
                    MessageBox.Show("Your Id says you are under 21 sorry!")
                End If
            Catch ex As Exception
                MessageBox.Show("Oops, there was a problem connecting to the database" + ex.Message)
            End Try

        End If

        ' Clears name text box and listbox
        txtName.Clear()
        lbxPatrons.ClearSelected()
        ptrAtm.Visible = False

    End Sub

    ' When you click a user in the listbox
    Private Sub lbxPatrons_Click(sender As Object, e As EventArgs) Handles lbxPatrons.Click
        ' Shows and hides appropriate text, buttons, and images
        If Not lbxPatrons.SelectedItem Is Nothing Then
            selectedPatron = CType(lbxPatrons.SelectedItem, Patron)
            btnEnter.Enabled = True
            btnDelete.Enabled = True
            ptrAtm.Visible = True
            txtName.Hide()
            txtName.Clear()
            btnSign.Hide()
            lblName.Text = selectedPatron.Name
            lblMoneyText.Show()
            lblMoney.Text = "$" & selectedPatron.Money

        End If
    End Sub

    ' Connect to the PatronDB
    Private Function connectToDb() As SqlConnection
        'set up connection string
        Dim connectionString As String = "Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & folder & "\ShakeOfTheDay\PatronDB.mdf;Integrated Security=True;"

        'create connection object
        Dim dbConnection As New SqlConnection(connectionString)

        Return dbConnection
    End Function

    ' When you click the delete button
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Remove the patron from the listbox
        patrons.Remove(patrons(lbxPatrons.SelectedIndex))

        ' If there is a user
        If selectedPatron.Id > 0 Then

            ' Delete user from the database
            Dim dbConnection As SqlConnection = connectToDb()
            dbConnection.Open()

            Dim sqlString = "DELETE FROM Patrons WHERE Id=@id"

            Dim deleteCommand As New SqlCommand(sqlString, dbConnection)

            deleteCommand.Parameters.AddWithValue("@id", selectedPatron.Id)

            ' Catch exception for delete patron
            Try
                If deleteCommand.ExecuteNonQuery() > 0 Then
                    MessageBox.Show(selectedPatron.Name + " was removed")
                    ptrAtm.Visible = False
                Else
                    MessageBox.Show(selectedPatron.Name + " was not removed")
                End If
            Catch ex As Exception
                MessageBox.Show("Oops there was a problem connecting to the database." + ex.Message)
            End Try

        End If

        ' If you can select and item in the listbox
        If Not lbxPatrons.SelectedItem Is Nothing Then
            selectedPatron = CType(lbxPatrons.SelectedItem, Patron)
        End If

        ' If the listcount is 0 disable delete and enter bar buttons
        If patrons.Count = 0 Then
            btnDelete.Enabled = False
            btnEnter.Enabled = False
        End If

        ' Shows and hides appropriate text and buttons
        lblName.Text = ""
        lblMoneyText.Hide()
        lblMoney.Text = ""
        btnEnter.Enabled = False
        btnDelete.Enabled = False
        lbxPatrons.ClearSelected()
    End Sub

    ' When you click on the ATM image
    Private Sub ptrAtm_Click(sender As Object, e As EventArgs) Handles ptrAtm.Click
        Dim result = MessageBox.Show("Do you want to take $20 out of the ATM?", "Take out money?", MessageBoxButtons.YesNo)
        ' If you click yes on the messagebox
        If (result = DialogResult.Yes) Then
            selectedPatron.Money += 20
            lblMoney.Text = "$" & selectedPatron.Money
            ' Updates database for money
            Dim dbConnection As SqlConnection = connectToDb()
            dbConnection.Open()
            Dim sqlString As String = "UPDATE Patrons SET Money=@money WHERE Id=" & selectedPatron.Id & ";"
            Dim saveCommand As New SqlCommand(sqlString, dbConnection)


            saveCommand.Parameters.AddWithValue("@money", selectedPatron.Money)

            ' Catch exception for ATM
            Try
                If saveCommand.ExecuteNonQuery > 0 Then
                    MessageBox.Show("You withdrew $20!")
                Else
                    MessageBox.Show("You did not get money.")
                End If
            Catch ex As Exception
                MessageBox.Show("Ooops, there was a problem connecting to the database" + ex.Message)
            End Try
        Else

        End If
    End Sub
End Class
