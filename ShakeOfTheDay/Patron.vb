Public Class Patron
    ' What info to Display, will display name and age
    Public ReadOnly Property DisplayInfo() As String
        Get
            Return cName
        End Get
    End Property

    ' Setters and Getters
    Private cName As String
    Public Property Name() As String
        Get
            Return cName
        End Get
        Set(ByVal value As String)
            cName = value
        End Set
    End Property


    Private cMoney As Integer
    Public Property Money() As Integer
        Get
            Return cMoney
        End Get
        Set(ByVal value As Integer)
            cMoney = value
        End Set
    End Property

    Private cGive As Integer
    Public Property Give() As Integer
        Get
            Return cGive
        End Get
        Set(ByVal value As Integer)

            cGive = value

        End Set
    End Property

    Private cWon As Integer
    Public Property Won() As Integer
        Get
            Return cWon
        End Get
        Set(ByVal value As Integer)

            cWon = value

        End Set
    End Property

    Private cMoneyWon As Integer
    Public Property MoneyWon() As Integer
        Get
            Return cMoneyWon
        End Get
        Set(ByVal value As Integer)

            cMoneyWon = value

        End Set
    End Property

    Private cPlayed As Integer
    Public Property Played() As Integer
        Get
            Return cPlayed
        End Get
        Set(ByVal value As Integer)

            cPlayed = value

        End Set
    End Property

    Private cHouseMoney As Integer
    Public Property HouseMoney() As Integer
        Get
            Return cHouseMoney
        End Get
        Set(ByVal value As Integer)

            cHouseMoney = value

        End Set
    End Property

    Private cId As Integer
    Public Property Id() As Integer
        Get
            Return cId
        End Get
        Set(ByVal value As Integer)
            cId = value
        End Set
    End Property


End Class
