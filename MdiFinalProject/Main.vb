Imports System.Windows.Forms
Imports System.IO
Public Class frmMain
    'Variable for file Path
    Dim fullPath As String

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles mnuNew.Click, btnNew.Click
        ' Create a new instance of the child form.
        Dim frmTextEditor As New frmTextEditor

        'Make the txtEditor a parent
        frmTextEditor.MdiParent = Me

        'Increase the file counter
        m_ChildFormNumber += 1
        frmTextEditor.Text = "File " & m_ChildFormNumber

        'Show the frm
        frmTextEditor.Show()
    End Sub



    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles mnuOpen.Click, btnOpen.Click

        'Make a variable that will hold the OpenFileDialog
        Dim OpenFileDialog As New OpenFileDialog
        'Variable for the frmTestEditor
        Dim frmTextEditor As frmTextEditor


        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt"
        If (OpenFileDialog.ShowDialog(Me) = DialogResult.OK) Then

            'Make a variable that will hold the FileName
            Dim fileName As String = OpenFileDialog.FileName

            'Making frmTextEditor a new one
            frmTextEditor = New frmTextEditor

            'Call the openFile sub-Routine
            frmTextEditor.OpenFile(fileName)

            'Make the title of frm to the path
            frmTextEditor.Text = fileName

            'Make the fullPath hold the file path
            fullPath = fileName

            'Make the frm the parent
            frmTextEditor.MdiParent = Me

            'Show the frm
            frmTextEditor.Show()

        End If
    End Sub

    Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click, btnSave.Click

        'Make a variable that will hold the SaveFileDialog
        Dim saveDialog As New SaveFileDialog

        'Variable for the frmTestEditor
        Dim frmTextEditor As frmTextEditor

        'Make a variable that will hold the FileName
        Dim fileName As String = saveDialog.FileName

        If TypeOf Me.ActiveMdiChild Is frmWeeklyUnitShipped Then
            MessageBox.Show("Saving is not allowed from this form.", "Invalid Action")
        Else

            'Get the Active child form
            frmTextEditor = CType(ActiveMdiChild, frmTextEditor)

            'Check if the file has a path
            If fullPath = "" Then

                'Call the Save as Sub-routine
                SaveAs(frmTextEditor)

            Else

                'Take the filePath for the old variable
                fileName = fullPath

                'Call the sub-routine for Saving the file.
                frmTextEditor.SaveFile(fileName)

            End If
        End If
    End Sub

    Private Sub mnuSaveAs_Click(sender As Object, e As EventArgs) Handles mnuSaveAs.Click

        If TypeOf Me.ActiveMdiChild Is frmWeeklyUnitShipped Then
            MessageBox.Show("Saving is not allowed from this form.", "Invalid Action")
        Else
            'Call the Save as Sub-routine
            SaveAs(frmTextEditor)
        End If
    End Sub

    Private Sub SaveAs(frmTextEditor As frmTextEditor)

        'Make a variable that will hold the SaveFileDialog
        Dim saveDialog As New SaveFileDialog

        'Filter for the save dialog
        saveDialog.Filter = "Text Files (*.txt)|*.txt"

        'Check if the user pressed Save in the dialog
        If (saveDialog.ShowDialog(Me) = DialogResult.OK) Then

            'Make a variable that will hold the FileName
            Dim fileName As String = saveDialog.FileName

            'Call the sub-routine for Saving the file.
            frmTextEditor.SaveFile(fileName)

            'A globle variable that will hold the FilePath for later use.
            fullPath = fileName

        End If
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuExit.Click


        For Each frmTextEditor As frmTextEditor In Me.MdiChildren

            'Close the mdi child form
            frmTextEditor.Close()

            'Go to the next frmTextEditor
        Next frmTextEditor

        'Close the whole form
        Me.Close()

    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuCut.Click

        'Variable for the frmTestEditor
        Dim frmTextEditor As frmTextEditor

        'Error message
        If TypeOf Me.ActiveMdiChild Is frmWeeklyUnitShipped Then
            MessageBox.Show("Cut,Copy or Paste is not allowed for this form.", "Invalid Action")
        Else
            'get the Active child
            frmTextEditor = CType(ActiveMdiChild, frmTextEditor)

            'Do the cut function
            frmTextEditor.rtbDocument.Cut()
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuCopy.Click

        'Variable for the frmTestEditor
        Dim frmTextEditor As frmTextEditor

        'Error message
        If TypeOf Me.ActiveMdiChild Is frmWeeklyUnitShipped Then
            MessageBox.Show("Cut,Copy or Paste is not allowed for this form.", "Invalid Action")
        Else
            'get the Active child
            frmTextEditor = CType(ActiveMdiChild, frmTextEditor)
            'Do the copy function
            frmTextEditor.rtbDocument.Copy()
        End If
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuPaste.Click

        'Variable for the frmTestEditor
        Dim frmTextEditor As frmTextEditor

        'Error message
        If TypeOf Me.ActiveMdiChild Is frmWeeklyUnitShipped Then
            MessageBox.Show("Cut,Copy or Paste is not allowed for this form.", "Invalid Action")
        Else
            'get the Active child
            frmTextEditor = CType(ActiveMdiChild, frmTextEditor)
            'Do the paste function
            frmTextEditor.rtbDocument.Paste()
        End If
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuCascade.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuTileVertical.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuTileHorizontal.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        'Display the message to the user
        MessageBox.Show("NETD - 2201" & vbCrLf & vbCrLf & "lab # 5" & vbCrLf & vbCrLf & " S. Farhan ")
    End Sub

    Private Sub mnuClose_Click(sender As Object, e As EventArgs) Handles mnuClose.Click

        'Variable for the frmTestEditor
        Dim frmTextEditor As frmTextEditor

        'get the Active child
        frmTextEditor = CType(ActiveMdiChild, frmTextEditor)
        'Do the cut function

        If Not frmTextEditor Is Nothing Then
            'Close the frm
            frmTextEditor.Close()
            'Also reset the variable
            fullPath = ""

        End If

    End Sub

    Private Sub AverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AverToolStripMenuItem.Click

        'Variable for the frmWeeklyUnitShipped
        Dim WeeklyUnitShipped As New frmWeeklyUnitShipped

        'Make it a parent
        WeeklyUnitShipped.MdiParent = Me
        'Show the File
        WeeklyUnitShipped.Show()
    End Sub

End Class
