using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Common
{
    public class SendMail
    {
        public class UseSmtp {
            SmtpClient SmtpClient = new SmtpClient();
            MailMessage MailMessage = new MailMessage();

            public void SetSender(string senderAddress, string senderName = "")
            {
                MailMessage.From = new MailAddress(senderAddress, senderName);
            }

            public void SetRecipientTo(string recipientAddress, string recipientName = "")
            {
                MailMessage.To.Add(new MailAddress(recipientAddress, recipientName));
            }

            public void SetRecipientTo(string[,] array)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    MailMessage.To.Add(new MailAddress(array[i, 0], array[i, 1]));
                }
            }

            public void SetRecipientCc(string recipientAddress, string recipientName = "")
            {
                MailMessage.CC.Add(new MailAddress(recipientAddress, recipientName));
            }

            public void SetRecipientCc(string[,] array)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    MailMessage.CC.Add(new MailAddress(array[i, 0], array[i, 1]));
                }
            }

            public void SetRecipientBcc(string recipientAddress, string recipientName = "")
            {
                MailMessage.Bcc.Add(new MailAddress(recipientAddress, recipientName));
            }

            public void SetRecipientBcc(string[,] array)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    MailMessage.Bcc.Add(new MailAddress(array[i, 0], array[i, 1]));
                }
            }

            public void SetAttachments(string file)
            {
                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(file);
                MailMessage.Attachments.Add(attachment);
            }

            public void SetAttachments(string[] array)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(array[i]);
                    MailMessage.Attachments.Add(attachment);
                }
            }

            public void SetNotify(DeliveryNotificationOptions options)
            {
                MailMessage.DeliveryNotificationOptions = options;
            }

            public void SetMailDetail(string subject, string body)
            {
                MailMessage.Subject = subject;
                MailMessage.Body = body;
            }

            public void SetEncoding(Encoding encoding)
            {
                MailMessage.SubjectEncoding = encoding;
                MailMessage.BodyEncoding = encoding;
            }

            public void SetTimeout(int timeOut)
            {
                SmtpClient.Timeout = timeOut;
            }

            public void SetServerDetail(string host, int port)
            {
                SmtpClient.Host = host;
                SmtpClient.Port = port;
                SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            }

            public void Send()
            {
                SmtpClient.Send(MailMessage);
            }

            public void Dispose()
            {
                MailMessage.Dispose();
                SmtpClient.Dispose();
            }
        }

        public class UseSendGrid{

            public string ApiKey { get; set; }
            public EmailAddress From { get; set; }
            public EmailAddress To { get; set; }
            public List<EmailAddress> ToMultiple { get; set; }
            public string Attachment { get; set; }
            public List<SendGrid.Helpers.Mail.Attachment> Attachments { get; set; }
            public string Subject { get; set; }
            public string PlainTextContent { get; set; }
            public string HtmlContent { get; set; }


            public void SetSender(string senderAddress, string senderName = "")
            {
                From = new EmailAddress(senderAddress, senderName);
            }

            public void SetRecipientTo(string recipientAddress, string recipientName = "")
            {
                To = new EmailAddress(recipientAddress, recipientName);
            }

            public void SetRecipientTo(List<EmailAddress> emailAddresses)
            {
                ToMultiple = emailAddresses;
            }

            public void SetAttachment(string attachment)
            {
                Attachment = attachment;
            }

            public void SetAttachment(List<SendGrid.Helpers.Mail.Attachment> attachment)
            {
                Attachments = attachment;
            }


            public void SetMailDetail(string subject, string body)
            {
                Subject = subject;
                PlainTextContent = body;
                HtmlContent = body;
            }

            public HttpStatusCode Send()
            {
                var task = Execute();
                return task.Result;

            }

            async Task<HttpStatusCode> Execute()
            {
                SendGridClient client = new SendGridClient(ApiKey);

                SendGridMessage msg;
               
                
                if (ToMultiple != null)
                {
                    msg = MailHelper.CreateSingleEmailToMultipleRecipients(From, ToMultiple, Subject, PlainTextContent, HtmlContent);
                }
                else
                {
                    msg = MailHelper.CreateSingleEmail(From, To, Subject, PlainTextContent, HtmlContent);
                }

                if (Attachment!=null)
                {
                    msg.AddAttachment(Attachment,"");
                }

                if (Attachments!=null)
                {
                    msg.AddAttachments(Attachments);
                }

                var response = await client.SendEmailAsync(msg);

                return response.StatusCode;
            }
        }
    }
}