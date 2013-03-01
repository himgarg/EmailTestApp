Imports System.Net.Mail

Public Class Form1

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Try
            txtResult.Text = ""
            Dim smtpClient As New SmtpClient(txtServer.Text, txtPort.Text)
            smtpClient.EnableSsl = chkSecure.Checked
            smtpClient.Credentials = New System.Net.NetworkCredential(txtUserID.Text, txtPassword.Text)

            Dim message As New MailMessage
            message.IsBodyHtml = True
            message.From = New MailAddress(txtUserID.Text)
            message.To.Add(txtTo.Text)
            message.Subject = txtSubject.Text
            message.Body = txtBody.Text


            smtpClient.Send(message)
            txtResult.Text = "Sent Successfully"
        Catch ex As Exception
            txtResult.Text = "Error Message: " + ex.Message + vbCrLf + "Stack Trace: " + ex.StackTrace
            Dim innerException As Exception = ex.InnerException

            Do While innerException IsNot Nothing
                txtResult.Text += "Error Message: " + innerException.Message + vbCrLf + "Stack Trace: " + innerException.StackTrace
                innerException = innerException.InnerException
            Loop

        End Try
    End Sub
End Class
