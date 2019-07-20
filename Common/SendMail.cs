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

            public void SetAttachments(List<string> list)
            {
                foreach (var item in list)
                {
                    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(item);
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

        /// <summary>
        /// SendGrid
        /// </summary>
        public class UseSendGrid{
            #region Property
            /// <summary>
            /// SendGrid API Key
            /// </summary>
            public string ApiKey { get; set; }

            /// <summary>
            /// Sender mail address
            /// </summary>
            public EmailAddress From { get; set; }

            /// <summary>
            /// Recipient mail address
            /// </summary>
            public EmailAddress To { get; set; }

            /// <summary>
            /// Recipient mail address(multiple)
            /// </summary>
            public List<EmailAddress> ToMultiple { get; set; }

            /// <summary>
            /// Attachment file path
            /// </summary>
            public string Attachment { get; set; }

            /// <summary>
            /// Attachment file path(multiple)
            /// </summary>
            public List<string> Attachments { get; set; }

            /// <summary>
            /// Mail subject
            /// </summary>
            public string Subject { get; set; }

            /// <summary>
            /// Mail body(plain)
            /// </summary>
            public string PlainTextContent { get; set; }

            /// <summary>
            /// Mail body(html)
            /// </summary>
            public string HtmlContent { get; set; }
            #endregion

            #region Method
            /// <summary>
            /// Set sender detail
            /// </summary>
            /// <param name="senderAddress"></param>
            /// <param name="senderName"></param>
            public void SetSender(string senderAddress, string senderName = "")
            {
                From = new EmailAddress(senderAddress, senderName);
            }

            /// <summary>
            /// Set recipient detail
            /// </summary>
            /// <param name="recipientAddress"></param>
            /// <param name="recipientName"></param>
            public void SetRecipientTo(string recipientAddress, string recipientName = "")
            {
                To = new EmailAddress(recipientAddress, recipientName);
            }

            /// <summary>
            /// Set recipient detail(multiple)
            /// </summary>
            /// <param name="emailAddresses"></param>
            public void SetRecipientTo(List<EmailAddress> emailAddresses)
            {
                ToMultiple = emailAddresses;
            }

            /// <summary>
            /// Set mail detail
            /// </summary>
            /// <param name="subject"></param>
            /// <param name="body"></param>
            public void SetMailDetail(string subject, string body)
            {
                Subject = subject;
                PlainTextContent = body;
                HtmlContent = body;
            }

            /// <summary>
            /// Set attachment
            /// </summary>
            /// <param name="emailAddresses"></param>
            public void SetAttachment(string attachment)
            {
                Attachment = attachment;
            }

            /// <summary>
            /// Set attachment(multiple)
            /// </summary>
            /// <param name="emailAddresses"></param>
            public void SetAttachment(List<string> attachment)
            {
                Attachments = attachment;
            }

            /// <summary>
            /// Mail send
            /// </summary>
            /// <returns></returns>
            public HttpStatusCode Send()
            {
                if ((From == null) && (To == null && ToMultiple == null))
                {
                    return HttpStatusCode.NoContent;
                }

                var task = Execute();
                return task.Result;
            }

            public string AddAttachment(string attachment)
            {
                var bytes = System.IO.File.ReadAllBytes(attachment);
                var file = Convert.ToBase64String(bytes);
                return file;
            }

            /// <summary>
            /// Mail send execute
            /// </summary>
            /// <returns></returns>
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

                if (Attachment != null)
                {
                    if (System.IO.File.Exists(Attachment))
                    {
                        msg.AddAttachment(System.IO.Path.GetFileName(Attachment), AddAttachment(Attachment));
                    }
                }
                else if (Attachments != null)
                {
                    foreach (var attachment in Attachments)
                    {
                        if (System.IO.File.Exists(attachment))
                        {
                            msg.AddAttachment(System.IO.Path.GetFileName(attachment), AddAttachment(attachment));
                        }
                    }
                }

                var response = await client.SendEmailAsync(msg);

                return response.StatusCode;
            }
            #endregion
        }
    }
}