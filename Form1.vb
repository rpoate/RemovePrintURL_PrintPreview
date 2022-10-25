Public Class Form1

    Private regKey As String = "HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\PageSetup"

    Private keyHeader As String
    Private keyFooter As String
    Private keyBottom As String
    Private keyLeft As String
    Private keyRight As String
    Private keyTop As String

    Private Sub HtmlEditControl1_CommandsToolbarButtonClicked(sender As Object, e As Zoople.CommandsToolbarButtonClickedEventArgs) Handles HtmlEditControl1.CommandsToolbarButtonClicked

        If e.ButtonIdentifier = "tsbPrint" Then

            e.Cancelled = True

            'set temporary registry values
            My.Computer.Registry.SetValue(regKey, "header", "The Page &p of &P")
            My.Computer.Registry.SetValue(regKey, "footer", "")
            My.Computer.Registry.SetValue(regKey, "margin_bottom", "0.50000")
            My.Computer.Registry.SetValue(regKey, "margin_left", "0.50000")
            My.Computer.Registry.SetValue(regKey, "margin_right", "0.50000")
            My.Computer.Registry.SetValue(regKey, "margin_top", "0.50000")

            Me.HtmlEditControl1.print_Document(True)


        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        keyHeader = My.Computer.Registry.GetValue(regKey, "header", "no value")
        keyFooter = My.Computer.Registry.GetValue(regKey, "footer", "no value")
        keyBottom = My.Computer.Registry.GetValue(regKey, "margin_bottom", "no value")
        keyLeft = My.Computer.Registry.GetValue(regKey, "margin_left", "no value")
        keyRight = My.Computer.Registry.GetValue(regKey, "margin_right", "no value")
        keyTop = My.Computer.Registry.GetValue(regKey, "margin_top", "no value")

    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        'set registry values to original state
        My.Computer.Registry.SetValue(regKey, "header", keyHeader)
        My.Computer.Registry.SetValue(regKey, "footer", keyFooter)
        My.Computer.Registry.SetValue(regKey, "margin_bottom", keyBottom)
        My.Computer.Registry.SetValue(regKey, "margin_left", keyLeft)
        My.Computer.Registry.SetValue(regKey, "margin_right", keyRight)
        My.Computer.Registry.SetValue(regKey, "margin_top", keyTop)

    End Sub
End Class
