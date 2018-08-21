using System;
using System.IO;
using Windows.UI.Notifications;

namespace Common
{
    /// <summary>
    /// 通知
    /// Windows.winmdの参照が必要
    /// (C:\Program Files (x86)\Windows Kits\8.1\References\CommonConfiguration\Neutral\Annotated)
    /// </summary>
    public static class Notification
    {
        /// <summary>
        /// アクションバー通知(Windows8、10専用)
        /// </summary>
        public static void ShowNotify(String strLine_1, string strLine_2, string strProductName, string iconPath)
        {
            try
            {
                var tmpl = ToastTemplateType.ToastImageAndText02;
                var xml = ToastNotificationManager.GetTemplateContent(tmpl);
                var images = xml.GetElementsByTagName("image");
                var src = images[0].Attributes.GetNamedItem("src");
                var texts = xml.GetElementsByTagName("text");
                var notify = ToastNotificationManager.CreateToastNotifier(strProductName);

                if (File.Exists(iconPath))
                {
                    src.InnerText = "file:///" + Path.GetFullPath(iconPath);
                }

                texts[0].AppendChild(xml.CreateTextNode(strLine_1));
                texts[1].AppendChild(xml.CreateTextNode(strLine_2));

                notify.Show(new ToastNotification(xml));
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
