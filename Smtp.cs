using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;


namespace MailKit_Library
{
    public class Smtp
    {
        static void Send(
            string host, int port, string username, string password,
            MimeMessage message
            )
        {
            using (SmtpClient client = new())
            {
                client.Connect(host, port, SecureSocketOptions.SslOnConnect);
                client.Authenticate(username, password);

                client.Send(message);

                client.Disconnect(true);
            }
        }

        static public void SendText(string host, int port, string username, string password,
            string sendername, string senderaddress, string subject, string[] to, string[]? cc, string[]? bcc,
            string text)
        {
            using (MimeMessage message = Message.GetText(sendername, senderaddress, subject, to, cc, bcc, text))
            {
                Send(host, port, username, password, message);
            }
        }

        static public void SendHtml(string host, int port, string username, string password,
            string sendername, string senderaddress, string subject, string[] to, string[]? cc, string[]? bcc,
            string html)
        {
            using (MimeMessage message = Message.GetHtml(sendername, senderaddress, subject, to, cc, bcc, html))
            {
                Send(host, port, username, password, message);
            }
        }
    }
}