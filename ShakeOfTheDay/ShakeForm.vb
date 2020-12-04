Imports System.Data.SqlClient

Public Class ShakeForm

    ' Declare thisPatron as Patron class
    Public Property thisPatron As Patron

    ' Random object for dice roll
    Dim randomGen As New Random()

    ' SqlConnection to connect to DB
    Dim dbConnection As SqlConnection = connectToDb()

    ' Folder where images are
    Dim folder As String = "C:\Users\Dylan\Desktop\ShakeOfTheDay"

    ' Used to compare die needed to win
    Dim numberDay As String

    ' Variables used in different parts of the program
    Dim extraRoll As Boolean = True
    Dim rollsLeft As Integer
    Dim winner As Integer

    ' When the form loads
    Private Sub ShakeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Center to screen and add appropriate text and buttons
        Me.CenterToScreen()
        lblWinner.Text = ""
        lblHouseMoney.Text = "$" & thisPatron.HouseMoney
        lblPatron.Text = thisPatron.Name
        lblMoney.Text = "$" & thisPatron.Money
        lblMoneySpent.Text = "$" & thisPatron.Give
        lblMoneyWon.Text = "$" & thisPatron.MoneyWon
        lblPlayed.Text = thisPatron.Played
        lblGamesWon.Text = thisPatron.Won

        ' Get the die needed to win
        numberDay = System.IO.Path.Combine(folder, "images\" & rollDice(1, 6) & ".png")
        ptrDay.Image = Image.FromFile(numberDay)

    End Sub

    ' When you click the play button
    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        ' Close db Connection just incase one might be open
        dbConnection.Close()

        ' If this patrons money is less than or equal to zero
        If thisPatron.Money <= 0 Then
            MessageBox.Show("You ran out of money! You need to leave and find an ATM!")
        Else
            ' Add appropriate text, buttons and images when you click play
            lblWinner.Text = ""
            winner = 0
            extraRoll = True

            ' Clear the board
            ptrDiceOne.Image = Nothing
            ptrDiceTwo.Image = Nothing
            ptrDiceThree.Image = Nothing
            ptrDiceFour.Image = Nothing
            ptrDiceFive.Image = Nothing

            ' Make the dice visible
            ptrDiceOne.Visible = True
            ptrDiceTwo.Visible = True
            ptrDiceThree.Visible = True
            ptrDiceFour.Visible = True
            ptrDiceFive.Visible = True

            ' Clear the saved dice
            ptrSaveOne.Visible = False
            ptrSaveTwo.Visible = False
            ptrSaveThree.Visible = False
            ptrSaveFour.Visible = False
            ptrSaveFive.Visible = False

            ' Make the save buttons invisible
            btnSaveOne.Hide()
            btnSaveTwo.Hide()
            btnSaveThree.Hide()
            btnSaveFour.Hide()
            btnSaveFive.Hide()

            ' Show roll button hide play button
            btnRoll.Enabled = True
            btnPlay.Hide()

            ' Set rolls left
            rollsLeft = 3
            lblRollsLeft.Text = rollsLeft

            ' Math and new text 
            thisPatron.Money -= 1
            lblMoney.Text = "$" & thisPatron.Money

            thisPatron.Give += 1
            lblMoneySpent.Text = "$" & thisPatron.Give

            thisPatron.Played += 1
            lblPlayed.Text = thisPatron.Played

            thisPatron.HouseMoney += 1
            lblHouseMoney.Text = "$" & thisPatron.HouseMoney

            ' Updates Patron info
            dbConnection.Open()
            Dim sqlString As String = "UPDATE Patrons SET Money=@money, Give=@give, Played=@played WHERE Id=" & thisPatron.Id & ";"
            Dim saveCommand As New SqlCommand(sqlString, dbConnection)

            saveCommand.Parameters.AddWithValue("@money", thisPatron.Money)
            saveCommand.Parameters.AddWithValue("@give", thisPatron.Give)
            saveCommand.Parameters.AddWithValue("@played", thisPatron.Played)

            ' Catch exception for playing
            Try
                If saveCommand.ExecuteNonQuery > 0 Then

                End If
            Catch ex As Exception
                MessageBox.Show("Ooops, there was a problem connecting to the database" + ex.Message)
            End Try

            Dim houseSql As String = "UPDATE Patrons SET HouseMoney=@houseMoney;"
            Dim houseSave As New SqlCommand(houseSql, dbConnection)
            houseSave.Parameters.AddWithValue("@houseMoney", thisPatron.HouseMoney)

            ' Catch exception for house money
            Try
                If houseSave.ExecuteNonQuery > 0 Then

                End If
            Catch ex As Exception
                MessageBox.Show("Ooops, there was a problem connecting to the database" + ex.Message)
            End Try
        End If


    End Sub

    ' When the shake button is clicked
    Private Sub btnRoll_Click(sender As Object, e As EventArgs) Handles btnRoll.Click

        ' Clear save buttons
        btnSaveOne.Hide()
        btnSaveTwo.Hide()
        btnSaveThree.Hide()
        btnSaveFour.Hide()
        btnSaveFive.Hide()

        ' Rolls six dice
        Dim diceOne As String = System.IO.Path.Combine(folder, "images\" & rollDice(1, 6) & ".png")
        Dim diceTwo As String = System.IO.Path.Combine(folder, "images\" & rollDice(1, 6) & ".png")
        Dim diceThree As String = System.IO.Path.Combine(folder, "images\" & rollDice(1, 6) & ".png")
        Dim diceFour As String = System.IO.Path.Combine(folder, "images\" & rollDice(1, 6) & ".png")
        Dim diceFive As String = System.IO.Path.Combine(folder, "images\" & rollDice(1, 6) & ".png")

        ' Assigns picture depending on rolled die
        ptrDiceOne.Image = Image.FromFile(diceOne)
        ptrDiceTwo.Image = Image.FromFile(diceTwo)
        ptrDiceThree.Image = Image.FromFile(diceThree)
        ptrDiceFour.Image = Image.FromFile(diceFour)
        ptrDiceFive.Image = Image.FromFile(diceFive)

        ' Minus 1 to rolls left
        rollsLeft -= 1
        lblRollsLeft.Text = rollsLeft

        ' Checks to see if each die is the die of the day
        If diceOne = numberDay And ptrDiceOne.Visible = True Then
            btnSaveOne.Show()
        End If

        If diceTwo = numberDay And ptrDiceTwo.Visible = True Then
            btnSaveTwo.Show()
        End If

        If diceThree = numberDay And ptrDiceThree.Visible = True Then
            btnSaveThree.Show()
        End If

        If diceFour = numberDay And ptrDiceFour.Visible = True Then
            btnSaveFour.Show()
        End If

        If diceFive = numberDay And ptrDiceFive.Visible = True Then
            btnSaveFive.Show()
        End If

        ' If you have bonus roll look into btnshow
        If extraRoll = True And winner = 4 And rollsLeft = 0 Then
            extraRoll = False
            BonusRoll()
            ' Else If rolls left 0 disable shake button
            ' Show play button
        ElseIf rollsLeft = 0 Then
            btnRoll.Enabled = False
            btnPlay.Text = "Play Again?"
            btnPlay.Show()
        End If

    End Sub

    ' When the save one button is clicked
    Private Sub btnSaveOne_Click(sender As Object, e As EventArgs) Handles btnSaveOne.Click

        ' Move die to saved sied and check for bonus roll and winner
        ptrDiceOne.Visible = False
        ptrSaveOne.Image = ptrDiceOne.Image
        ptrSaveOne.Show()
        btnSaveOne.Hide()
        winner += 1
        If winner = 4 And rollsLeft = 0 And extraRoll = True Then
            extraRoll = False
            BonusRoll()
        End If
        If winner = 5 Then
            Win()
        End If
    End Sub

    ' When the save two button is clicked
    Private Sub btnSaveTwo_Click(sender As Object, e As EventArgs) Handles btnSaveTwo.Click

        ' Move die to saved side and check for bonus roll and winner
        ptrDiceTwo.Visible = False
        ptrSaveTwo.Image = ptrDiceTwo.Image
        ptrSaveTwo.Show()
        btnSaveTwo.Hide()
        winner += 1
        If winner = 4 And rollsLeft = 0 And extraRoll = True Then
            extraRoll = False
            BonusRoll()
        End If
        If winner = 5 Then
            Win()
        End If

    End Sub

    ' When the save three button is clicked
    Private Sub btnSaveThree_Click(sender As Object, e As EventArgs) Handles btnSaveThree.Click

        ' Move die to saved side and check for bonus roll and winner
        ptrDiceThree.Visible = False
        ptrSaveThree.Image = ptrDiceThree.Image
        ptrSaveThree.Show()
        btnSaveThree.Hide()
        winner += 1
        If winner = 4 And rollsLeft = 0 And extraRoll = True Then
            extraRoll = False
            BonusRoll()
        End If
        If winner = 5 Then
            Win()
        End If

    End Sub

    ' When the save four button is clicked
    Private Sub btnSaveFour_Click(sender As Object, e As EventArgs) Handles btnSaveFour.Click

        ' Move die to saved side and check for bonus roll and winner
        ptrDiceFour.Visible = False
        ptrSaveFour.Image = ptrDiceFour.Image
        ptrSaveFour.Show()
        btnSaveFour.Hide()
        winner += 1
        If winner = 4 And rollsLeft = 0 And extraRoll = True Then
            extraRoll = False
            BonusRoll()
        End If
        If winner = 5 Then
            Win()
        End If

    End Sub

    ' When the save five button is clicked
    Private Sub btnSaveFive_Click(sender As Object, e As EventArgs) Handles btnSaveFive.Click

        ' Move die to saved sied and check for bonus roll and winner
        ptrDiceFive.Visible = False
        ptrSaveFive.Image = ptrDiceFive.Image
        ptrSaveFive.Show()
        btnSaveFive.Hide()
        winner += 1
        If winner = 4 And rollsLeft = 0 And extraRoll = True Then
            extraRoll = False
            BonusRoll()
        End If
        If winner = 5 Then
            Win()
        End If

    End Sub

    ' Roll dice function
    Public Function rollDice(numDice As Integer, sides As Integer) As String

        ' Create a list to store all the die rolls
        Dim rolls As Integer
        Dim id As String

        ' Roll the dice once for each dice (as specified by numDice)
        For ctr As Integer = 1 To numDice
            rolls = randomGen.Next(1, sides + 1)
        Next

        ' If checks to assign image name to id
        If rolls = 1 Then
            id = "onedie"
        ElseIf rolls = 2 Then
            id = "twodie"
        ElseIf rolls = 3 Then
            id = "threedie"
        ElseIf rolls = 4 Then
            id = "fourdie"
        ElseIf rolls = 5 Then
            id = "fivedie"
        ElseIf rolls = 6 Then
            id = "sixdie"
        End If

        ' return the sum of all the rolls in the list
        Return id

    End Function

    ' Connect to the PatronDB
    Private Function connectToDb() As SqlConnection

        ' Set up connection string
        Dim connectionString As String = "Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dylan\Desktop\ShakeOfTheDay\ShakeOfTheDay\PatronDB.mdf;Integrated Security=True;"

        ' Create connection object
        Dim dbConnection As New SqlConnection(connectionString)

        Return dbConnection
    End Function

    ' When leave button is clicked
    Private Sub btnLeave_Click(sender As Object, e As EventArgs) Handles btnLeave.Click
        Dim openList As New PlayerList
        openList.Show()
        Me.Hide()
    End Sub

    ' Bonus roll Sub
    Public Sub BonusRoll()
        Dim result = MessageBox.Show("You get a bonus roll to win for $5!!", "BONUS ROLL!", MessageBoxButtons.YesNo)
        ' If you click yes on the messagebox
        If result = DialogResult.Yes Then
            ' If you have more than $5
            If thisPatron.Money > 5 Then
                dbConnection.Close()
                rollsLeft += 1
                btnRoll.Enabled = True
                lblRollsLeft.Text = "1"
                thisPatron.Money -= 5
                lblMoney.Text = "$" & thisPatron.Money

                ' Update database for money
                dbConnection.Open()
                Dim sqlString As String

                sqlString = "UPDATE Patrons SET Money=@money WHERE Id=" & thisPatron.Id & ";"

                Dim saveCommand As New SqlCommand(sqlString, dbConnection)

                saveCommand.Parameters.AddWithValue("@money", thisPatron.Money)

                ' Catch exception for updating patron
                Try
                    If saveCommand.ExecuteNonQuery > 0 Then

                    End If
                Catch ex As Exception
                    MessageBox.Show("Ooops, there was a problem connecting to the database" + ex.Message)
                End Try

                ' Update database for house money
                thisPatron.HouseMoney += 5
                lblHouseMoney.Text = "$" & thisPatron.HouseMoney

                Dim houseSql As String = "UPDATE Patrons SET HouseMoney=@houseMoney;"
                Dim houseSave As New SqlCommand(houseSql, dbConnection)
                houseSave.Parameters.AddWithValue("@houseMoney", thisPatron.HouseMoney)

                ' Catch exception for updating patron
                Try
                    If houseSave.ExecuteNonQuery > 0 Then

                    End If
                Catch ex As Exception
                    MessageBox.Show("Ooops, there was a problem connecting to the database" + ex.Message)
                End Try
            Else
                MessageBox.Show("You need more than $5 for the bonus roll!")
            End If

        End If
    End Sub

    ' Win Sub
    Public Sub Win()

        ' Called if you win the game
        dbConnection.Close()
        lblWinner.Text = "YOU WON $" & thisPatron.HouseMoney & "!!"
        btnRoll.Enabled = False
        btnPlay.Show()
        thisPatron.Money += thisPatron.HouseMoney
        lblMoney.Text = "$" & thisPatron.Money

        ' Adds house money to your money and money won
        thisPatron.MoneyWon += thisPatron.HouseMoney
        lblMoneyWon.Text = "$" & thisPatron.MoneyWon

        thisPatron.Won += 1
        lblGamesWon.Text = "$" & thisPatron.Won


        ' Update database for money and games won
        dbConnection.Open()
        Dim sqlString As String

        sqlString = "UPDATE Patrons SET Money=@money, Won=@won, MoneyWon=@moneyWon WHERE Id=" & thisPatron.Id & ";"

        Dim saveCommand As New SqlCommand(sqlString, dbConnection)

        saveCommand.Parameters.AddWithValue("@money", thisPatron.Money)
        saveCommand.Parameters.AddWithValue("@won", thisPatron.Won)
        saveCommand.Parameters.AddWithValue("@moneyWon", thisPatron.MoneyWon)

        ' Catch exception for updating patron
        Try
            If saveCommand.ExecuteNonQuery > 0 Then

            End If
        Catch ex As Exception
            MessageBox.Show("Ooops, there was a problem connecting to the database" + ex.Message)
        End Try

        ' Update database for house money
        thisPatron.HouseMoney = 0
        lblHouseMoney.Text = "$" & thisPatron.HouseMoney

        Dim houseSql As String = "UPDATE Patrons SET HouseMoney=@houseMoney;"
        Dim houseSave As New SqlCommand(houseSql, dbConnection)
        houseSave.Parameters.AddWithValue("@houseMoney", thisPatron.HouseMoney)

        ' Catch exception for updating patron
        Try
            If houseSave.ExecuteNonQuery > 0 Then

            End If
        Catch ex As Exception
            MessageBox.Show("Ooops, there was a problem connecting to the database" + ex.Message)
        End Try
    End Sub
End Class
