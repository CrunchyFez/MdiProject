Imports System.IO
Public Class frmTextEditor

    Friend Sub OpenFile(fileName As String)

        Dim fileStream As New FileStream(fileName, FileMode.Open, FileAccess.Read)
        Dim reader As New StreamReader(fileStream)

        rtbDocument.Text = reader.ReadToEnd()

        reader.Close()

    End Sub

    Friend Sub SaveFile(fileName As String)

        Dim sw As New StreamWriter(fileName)
        sw.Write(rtbDocument.Text)
        sw.Close()

    End Sub

End Class
