Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Module DataGridViewExtensions
    ''' <summary>
    ''' Expand each column to completely viewable.
    ''' </summary>
    ''' <param name="sender"></param>
    <Runtime.CompilerServices.Extension>
    Public Sub ExpandAllColumns(sender As DataGridView)

        For Each column As DataGridViewColumn In sender.Columns
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

    End Sub
    ''' <summary>
    ''' Determines if the specified cell is a ComboBox cell
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    <Runtime.CompilerServices.Extension>
    Public Function IsComboBoxCell(sender As DataGridViewCell) As Boolean

        Dim result As Boolean = False

        If sender.EditType IsNot Nothing Then
            If sender.EditType Is GetType(DataGridViewComboBoxEditingControl) Then
                result = True
            End If
        End If

        Return result

    End Function
    ''' <summary>
    ''' Split column name by upper case characters e.g. FirstName becomes First name.
    ''' </summary>
    ''' <param name="sender"></param>
    <Runtime.CompilerServices.Extension>
    Public Sub NormalizeColumnHeaders(sender As DataGridView)

        For Each column As DataGridViewColumn In sender.Columns

            column.HeaderText = String.Join(" ", Regex.Matches(column.Name, "([A-Z][a-z]+)").
                                               Cast(Of Match)().Select(Function(m) m.Value))
        Next

    End Sub
End Module