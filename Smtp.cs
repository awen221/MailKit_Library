using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace MailKit_Library
{
    public class Smtp
    {
        static void Send(SecureSocketOptions secure, string host, int port, string username, string password, MimeMessage message)
        {
            using SmtpClient client = new();
            client.Connect(host, port, secure);
            client.Authenticate(username, password);

            client.Send(message);

            client.Disconnect(true);
        }

        static public void SendText(SecureSocketOptions secure, string host, int port, string username, string password,
            string sendername, string senderaddress, string subject, string[] to, string[]? cc, string[]? bcc,
            string textbody)
        {
            using MimeMessage message = Message.GetText(sendername, senderaddress, subject, to, cc, bcc, textbody);
            Send(secure, host, port, username, password, message);
        }

        static public void SendHtml(SecureSocketOptions secure, string host, int port, string username, string password,
            string sendername, string senderaddress, string subject, string[] to, string[]? cc, string[]? bcc,
            string htmlbody)
        {
            using MimeMessage message = Message.GetHtml(sendername, senderaddress, subject, to, cc, bcc, htmlbody);
            Send(secure, host, port, username, password, message);
        }
    }
}