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
    public class MailTests
    {
        string Server = @"";
        int Port = 25;
        string From = @"";
        string FromName = "";
        string To = "";
        string ToName = "";
        string[,] ToArray = { { "", "" }, { "", "" }};
        string Cc = "";
        string CcName = "";
        string[,] CcArray = { { "", "" }, { "", "" }};
        string Bcc = "";
        string BccName = "";
        string[,] BccArray = { { "", "" }, { "", "" }};
        string Subject = "";
        string Body = "";
        string Attach = @"";
        string[] AttachArray = {@"", @""};

        [TestMethod()]
        public void SendGridMultipleToTest()
        {
            SendMail.UseSendGrid mail = new SendMail.UseSendGrid();
            mail.ApiKey = Settings.Default.SendGridApiKey;
            mail.SetSender(Settings.Default.SendGridSendToAddress, Settings.Default.SendGridSendToName);

            List<SendGrid.Helpers.Mail.EmailAddress> to = new List<SendGrid.Helpers.Mail.EmailAddress>();
            for (int i = 0; i < 5; i++)
            {
                to.Add(new SendGrid.Helpers.Mail.EmailAddress(Settings.Default.SendGridSendToAddress,
                                                              Settings.Default.SendGridSendToName + "_" + i));
            }
            mail.SetRecipientTo(to);
            mail.SetMailDetail(Settings.Default.SendGridSubject, Settings.Default.SendGridBody);
            System.Net.HttpStatusCode ret = mail.Send();

            Assert.AreEqual(ret.ToString(), "Accepted");
        }

        [TestMethod()]
        public void SendTest()
        {
            SendMail.UseSmtp mail = new SendMail.UseSmtp();
            mail.SetServerDetail(Server, Port);
            mail.SetSender(From, FromName);
            mail.SetRecipientTo(To, ToName);
            mail.SetRecipientCc(Cc, CcName);
            mail.SetRecipientBcc(Bcc, BccName);
            mail.SetAttachments(Attach);
            mail.SetMailDetail(Subject, Body);
            mail.SetNotify(System.Net.Mail.DeliveryNotificationOptions.None);
            mail.Send();
            mail.Dispose();

            mail = new SendMail.UseSmtp();
            mail.SetServerDetail(Server, Port);
            mail.SetSender(From, FromName);
            mail.SetRecipientTo(To, ToName);
            mail.SetMailDetail(Subject, Body);
            mail.Send();
            mail.Dispose();
            
            mail = new SendMail.UseSmtp();
            mail.SetServerDetail(Server, Port);
            mail.SetSender(From, FromName);
            mail.SetRecipientBcc(Bcc, BccName);
            mail.SetAttachments(Attach);
            mail.SetMailDetail(Subject, Body);
            mail.SetNotify(System.Net.Mail.DeliveryNotificationOptions.None);
            mail.Send();
            mail.Dispose();

            Assert.AreEqual(true,true);
        }

        [TestMethod()]
        public void MultiUserSendTest()
        {
            SendMail.UseSmtp mail = new SendMail.UseSmtp();
            mail.SetServerDetail(Server, Port);
            mail.SetSender(From, FromName);

            int len = ToArray.GetLength(1);

            for (int i = 0; i < ToArray.GetLength(0); i++)
            {           
                mail.SetRecipientTo(ToArray[i,0], ToArray[i, 1]);
            }

            for (int i = 0; i < CcArray.GetLength(0); i++)
            {
                mail.SetRecipientCc(CcArray[i, 0], CcArray[i, 1]);
            }


            mail.SetAttachments(AttachArray);

            mail.SetMailDetail(Subject, Body);
            mail.SetNotify(System.Net.Mail.DeliveryNotificationOptions.None);
            mail.Send();
            mail.Dispose();
            Assert.AreEqual(true, true);
        }

    }
}