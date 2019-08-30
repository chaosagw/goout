Public Structure FolderProperty
    Public Size As Long
    Public FileCount As Long
    Public FolderCount As Long
End Structure

Public Enum ItemImage
    ClosedFolder = 0
    OpenedFolder = 1
    Drive = 2
    DVD = 3
    NW = 4
    USB = 5
    RAM = 6
    NOROOT = 7
    UNKNOWN = 8
End Enum

Public Class FileSorter
    Implements IComparer
    Private Column As Integer
    Private SortOrder As SortOrder = SortOrder.Descending
    Private BindingListView As ListView

    Public Sub New(ByVal BindingListView As ListView)
        Me.BindingListView = BindingListView
    End Sub
    Public Sub Execute(ByVal Column As Integer)
        Me.Column = Column

        If Me.SortOrder = SortOrder.Ascending Then
            Me.SortOrder = SortOrder.Descending
        Else
            Me.SortOrder = SortOrder.Ascending
        End If

        If IsNothing(BindingListView.ListViewItemSorter) Then
            BindingListView.ListViewItemSorter = Me
        Else
            BindingListView.Sort()
        End If

    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim strX As String = CType(x, ListViewItem).SubItems(Column).Text
        Dim strY As String = CType(y, ListViewItem).SubItems(Column).Text
        Dim XValue As Long
        Dim YValue As Long
        Dim UnitLength As Integer

        '●[名前]列の場合は単純に比較

        If Column = 0 Then
            If SortOrder = SortOrder.Ascending Then
                Return Comparer.Default.Compare(strX, strY) '昇順
            Else
                Return Comparer.Default.Compare(strY, strX) '降順
            End If
        End If

        '●[サイズ]列の場合は単位(" KB")を除去して数値として比較

        '▼比較できるように形式を整える
        If Column = 1 Then
            UnitLength = Len(" KB")
        End If

        If strX = "" Then
            XValue = -1 ' ""を0より小さい物として扱うための技巧的処理
        Else
            XValue = Left(strX, Len(strX) - UnitLength) '単位(" KB")を除去して数値のみにする。
        End If

        If strY = "" Then
            YValue = -1 ' ""を0より小さい物として扱うための技巧的処理
        Else
            YValue = Left(strY, Len(strY) - UnitLength) '単位(" KB")を除去して数値のみにする。
        End If

        '▼比較実行

        If SortOrder = SortOrder.Ascending Then
            Return Comparer.Default.Compare(XValue, YValue) '昇順
        Else
            Return Comparer.Default.Compare(YValue, XValue) '降順
        End If

    End Function

End Class