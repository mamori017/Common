using CommonTests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests
{
    [TestClass()]
    public class SendMailTests
    {
        [TestClass()]
        public class UseSendGrid
        {
            [TestMethod()]
            public void SendSingleTest()
            {
                string method = "_SendSingleTest";

                SendMail.UseSendGrid mail = new SendMail.UseSendGrid
                {
                    ApiKey = SendMailSettings.Default.SendGridApiKey
                };

                mail.SetSender(SendMailSettings.Default.From, SendMailSettings.Default.FromName);

                mail.SetRecipientTo(SendMailSettings.Default.To, SendMailSettings.Default.ToName);

                mail.SetMailDetail(SendMailSettings.Default.Subject + method, SendMailSettings.Default.Body);

                Assert.AreEqual(mail.Send(), System.Net.HttpStatusCode.Accepted);
            }

            [TestMethod()]
            public void SendSingleWithAttachmentTest()
            {
                string method = "_SendSingleWithAttachmentTest";

                SendMail.UseSendGrid mail = new SendMail.UseSendGrid
                {
                    ApiKey = SendMailSettings.Default.SendGridApiKey
                };

                mail.SetSender(SendMailSettings.Default.From, SendMailSettings.Default.FromName);

                mail.SetRecipientTo(SendMailSettings.Default.To, SendMailSettings.Default.ToName);

                mail.SetMailDetail(SendMailSettings.Default.Subject + method, SendMailSettings.Default.Body);

                mail.SetAttachment(SendMailSettings.Default.AttachmentPath_1);

                Assert.AreEqual(mail.Send(), System.Net.HttpStatusCode.Accepted);
            }

            [TestMethod()]
            public void SendSingleWithAttachmentsTest()
            {
                string method = "_SendSingleWithAttachmentsTest";

                SendMail.UseSendGrid mail = new SendMail.UseSendGrid
                {
                    ApiKey = SendMailSettings.Default.SendGridApiKey
                };

                mail.SetSender(SendMailSettings.Default.From, SendMailSettings.Default.FromName);

                mail.SetRecipientTo(SendMailSettings.Default.To, SendMailSettings.Default.ToName);

                mail.SetMailDetail(SendMailSettings.Default.Subject + method, SendMailSettings.Default.Body);

                List<string> attachments = new List<string>
                {
                    SendMailSettings.Default.AttachmentPath_1,
                    SendMailSettings.Default.AttachmentPath_2,
                    SendMailSettings.Default.AttachmentPath_3
                };

                mail.SetAttachment(attachments);

                Assert.AreEqual(mail.Send(), System.Net.HttpStatusCode.Accepted);
            }

            [TestMethod()]
            public void SendMultipleTest()
            {
                string method = "_SendMultipleTest";

                SendMail.UseSendGrid mail = new SendMail.UseSendGrid
                {
                    ApiKey = SendMailSettings.Default.SendGridApiKey
                };

                mail.SetSender(SendMailSettings.Default.From, SendMailSettings.Default.FromName);

                List<SendGrid.Helpers.Mail.EmailAddress> to = new List<SendGrid.Helpers.Mail.EmailAddress>();

                for (int i = 0; i < 5; i++)
                {
                    to.Add(new SendGrid.Helpers.Mail.EmailAddress(SendMailSettings.Default.To,
                                                                  SendMailSettings.Default.ToName + "_" + i));
                }

                mail.SetRecipientTo(to);

                mail.SetMailDetail(SendMailSettings.Default.Subject + method, SendMailSettings.Default.Body);

                Assert.AreEqual(mail.Send(), System.Net.HttpStatusCode.Accepted);
            }

            [TestMethod()]
            public void SendMultipleWithAttachmentTest()
            {
                string method = "_SendMultipleWithAttachmentTest";

                SendMail.UseSendGrid mail = new SendMail.UseSendGrid
                {
                    ApiKey = SendMailSettings.Default.SendGridApiKey
                };

                mail.SetSender(SendMailSettings.Default.From, SendMailSettings.Default.FromName);

                List<SendGrid.Helpers.Mail.EmailAddress> to = new List<SendGrid.Helpers.Mail.EmailAddress>();

                for (int i = 0; i < 5; i++)
                {
                    to.Add(new SendGrid.Helpers.Mail.EmailAddress(SendMailSettings.Default.To,
                                                                  SendMailSettings.Default.ToName + "_" + i));
                }

                mail.SetRecipientTo(to);

                mail.SetMailDetail(SendMailSettings.Default.Subject + method, SendMailSettings.Default.Body);

                mail.SetAttachment(SendMailSettings.Default.AttachmentPath_1);

                Assert.AreEqual(mail.Send(), System.Net.HttpStatusCode.Accepted);
            }

            [TestMethod()]
            public void SendMultipleWithAttachmentsTest()
            {
                string method = "_SendMultipleWithAttachmentsTest";

                SendMail.UseSendGrid mail = new SendMail.UseSendGrid
                {
                    ApiKey = SendMailSettings.Default.SendGridApiKey
                };

                mail.SetSender(SendMailSettings.Default.From, SendMailSettings.Default.FromName);

                List<SendGrid.Helpers.Mail.EmailAddress> to = new List<SendGrid.Helpers.Mail.EmailAddress>();

                for (int i = 0; i < 5; i++)
                {
                    to.Add(new SendGrid.Helpers.Mail.EmailAddress(SendMailSettings.Default.To,
                                                                  SendMailSettings.Default.ToName + "_" + i));
                }

                mail.SetRecipientTo(to);

                mail.SetMailDetail(SendMailSettings.Default.Subject + method, SendMailSettings.Default.Body);

                List<string> attachments = new List<string>
                {
                    SendMailSettings.Default.AttachmentPath_1,
                    SendMailSettings.Default.AttachmentPath_2,
                    SendMailSettings.Default.AttachmentPath_3
                };

                mail.SetAttachment(attachments);

                Assert.AreEqual(mail.Send(), System.Net.HttpStatusCode.Accepted);
            }
        }


        [TestClass()]
        public class UseSmtp
        {
            [TestMethod()]
            public void SendSingleWithAttachmentTest()
            {
                string method = "_SendSingleTest";

                SendMail.UseSmtp mail = new SendMail.UseSmtp();
                mail.SetServerDetail(SendMailSettings.Default.SmtpServer, SendMailSettings.Default.SmtpPort);
                mail.SetSender(SendMailSettings.Default.From, SendMailSettings.Default.FromName);
                mail.SetRecipientTo(SendMailSettings.Default.To, SendMailSettings.Default.ToName);
                mail.SetRecipientCc(SendMailSettings.Default.Cc, SendMailSettings.Default.CcName);
                mail.SetRecipientBcc(SendMailSettings.Default.Bcc, SendMailSettings.Default.BccName);
                mail.SetAttachments(SendMailSettings.Default.AttachmentPath_1);
                mail.SetMailDetail(SendMailSettings.Default.Subject + method, SendMailSettings.Default.Body);
                mail.SetNotify(System.Net.Mail.DeliveryNotificationOptions.None);
                mail.Send();
                mail.Dispose();
                Assert.AreEqual(true, true);
            }

            [TestMethod()]
            public void SendSingleWithAttachmentsTest()
            {
                string method = "_SendSingleWithAttachmentsTest";

                SendMail.UseSmtp mail = new SendMail.UseSmtp();
                mail.SetServerDetail(SendMailSettings.Default.SmtpServer, SendMailSettings.Default.SmtpPort);
                mail.SetSender(SendMailSettings.Default.From, SendMailSettings.Default.FromName);
                mail.SetRecipientTo(SendMailSettings.Default.To, SendMailSettings.Default.ToName);
                mail.SetRecipientCc(SendMailSettings.Default.Cc, SendMailSettings.Default.CcName);
                mail.SetRecipientBcc(SendMailSettings.Default.Bcc, SendMailSettings.Default.BccName);
                mail.SetAttachments(SendMailSettings.Default.AttachmentPath_1);
                mail.SetAttachments(SendMailSettings.Default.AttachmentPath_2);
                mail.SetAttachments(SendMailSettings.Default.AttachmentPath_3);
                mail.SetMailDetail(SendMailSettings.Default.Subject + method, SendMailSettings.Default.Body);
                mail.SetNotify(System.Net.Mail.DeliveryNotificationOptions.None);
                mail.Send();
                mail.Dispose();
                Assert.AreEqual(true, true);
            }

            [TestMethod()]
            public void SendMultipleWithAttachmentTest()
            {
                string method = "_SendMultipleWithAttachmentTest";

                SendMail.UseSmtp mail = new SendMail.UseSmtp();
                mail.SetServerDetail(SendMailSettings.Default.SmtpServer, SendMailSettings.Default.SmtpPort);
                mail.SetSender(SendMailSettings.Default.From, SendMailSettings.Default.FromName);
                string[,] recipientTo = new string[3, 2];
                for (int i = 0; i < 3; i++)
                {
                    recipientTo[i, 0] = SendMailSettings.Default.To;
                    recipientTo[i, 1] = SendMailSettings.Default.ToName + "_" + i;
                }
                mail.SetRecipientTo(recipientTo);
                mail.SetRecipientCc(SendMailSettings.Default.Cc, SendMailSettings.Default.CcName);
                mail.SetRecipientBcc(SendMailSettings.Default.Bcc, SendMailSettings.Default.BccName);
                mail.SetAttachments(SendMailSettings.Default.AttachmentPath_1);
                mail.SetMailDetail(SendMailSettings.Default.Subject + method, SendMailSettings.Default.Body);
                mail.SetNotify(System.Net.Mail.DeliveryNotificationOptions.None);
                mail.Send();
                mail.Dispose();
                Assert.AreEqual(true, true);
            }

            [TestMethod()]
            public void SendMultipleWithAttachmentsTest()
            {
                string method = "_SendMultipleWithAttachmentTest";

                SendMail.UseSmtp mail = new SendMail.UseSmtp();
                mail.SetServerDetail(SendMailSettings.Default.SmtpServer, SendMailSettings.Default.SmtpPort);
                mail.SetSender(SendMailSettings.Default.From, SendMailSettings.Default.FromName);
                string[,] recipientTo = new string[3,2];
                for (int i = 0; i < 3; i++)
                {
                    recipientTo[i, 0] = SendMailSettings.Default.To;
                    recipientTo[i, 1] = SendMailSettings.Default.ToName + "_" + i;                        
                }
                mail.SetRecipientTo(recipientTo);
                mail.SetRecipientCc(SendMailSettings.Default.Cc, SendMailSettings.Default.CcName);
                mail.SetRecipientBcc(SendMailSettings.Default.Bcc, SendMailSettings.Default.BccName);
                mail.SetAttachments(SendMailSettings.Default.AttachmentPath_1);
                mail.SetAttachments(SendMailSettings.Default.AttachmentPath_2);
                mail.SetAttachments(SendMailSettings.Default.AttachmentPath_3);
                mail.SetMailDetail(SendMailSettings.Default.Subject + method, SendMailSettings.Default.Body);
                mail.SetNotify(System.Net.Mail.DeliveryNotificationOptions.None);
                mail.Send();
                mail.Dispose();
                Assert.AreEqual(true, true);
            }
        }
    }
}