Public Class TeamBuilder
    Private name As String
    Private nickName As String
    Private shirtColor As Color
    Private homeTown As String
    Private ground As String

    Public Function CreateTeam(ByVal name As String) As TeamBuilder
        Me.name = name
        Return Me
    End Function

    Public Function WithNickName(ByVal nickName As String) As TeamBuilder
        Me.nickName = nickName
        Return Me
    End Function

    Public Function WithShirtColor(ByVal shirtColor As Color) As TeamBuilder
        Me.shirtColor = shirtColor
        Return Me
    End Function

    Public Function FromTown(ByVal homeTown As String) As TeamBuilder
        Me.homeTown = homeTown
        Return Me
    End Function

    Public Function PlayingAt(ByVal ground As String) As TeamBuilder
        Me.ground = ground
        Return Me
    End Function

    ' CONVERSION OPERATOR

    Public Shared Widening Operator CType(ByVal tb As TeamBuilder) As Team
        Return New Team(tb.name, tb.nickName, tb.shirtColor, tb.homeTown, tb.ground)
    End Operator
End Class
Public Enum Color
    White
    Red
    Green
    Blue
End Enum

Public Class Team
    Private Property Name() As String
    Private Property NickName() As String
    Private Property ShirtColor() As Color
    Private Property HomeTown() As String
    Private Property Ground() As String

    Public Sub New(ByVal name As String, ByVal nickName As String, ByVal shirtColor As Color, ByVal homeTown As String, ByVal ground As String)
        Me.Name = name
        Me.NickName = nickName
        Me.ShirtColor = shirtColor
        Me.HomeTown = homeTown
        Me.Ground = ground
    End Sub
End Class