using MimeKit;

namespace MailKit_Library
{
    public class Message
    {
        static MimeMessage Get(string senderName, string senderAddress, string subject,
            string[] to, string[]? cc, string[]? bcc, MimeEntity body)
        {
            MimeMessage message = new();
            message.Sender = new MailboxAddress(senderName, senderAddress);
            message.Subject = subject;
            foreach (var _to in to) message.To.Add(MailboxAddress.Parse(_to));
            if (cc is not null)
                foreach (var _cc in cc) message.Cc.Add(MailboxAddress.Parse(_cc));
            if (bcc is not null)
                foreach (var _bcc in bcc) message.Bcc.Add(MailboxAddress.Parse(_bcc));

            message.Body = body;

            return message;
        }

        static public MimeMessage GetText(string senderName, string senderAddress, string subject,
            string[] to, string[]? cc, string[]? bcc, string textbody)
        {
            return Get(senderName, senderAddress, subject, to, cc, bcc, Body.GetText(textbody));
        }
        static public MimeMessage GetHtml(string senderName, string senderAddress, string subject,
            string[] to, string[]? cc, string[]? bcc, string htmlbody)
        {
            return Get(senderName, senderAddress, subject, to, cc, bcc, Body.GetHtml(htmlbody));
        }

        class Body
        {
            static public MimeEntity GetText(string textbody)
            {
                var builder = new BodyBuilder();
                builder.TextBody = textbody;

                return builder.ToMessageBody();
            }

            static public MimeEntity GetHtml(string htmlbody)
            {
                var builder = new BodyBuilder();
                builder.HtmlBody = htmlbody;

                return builder.ToMessageBody();
            }
        }
    }
}
