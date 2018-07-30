using System;
using System.Threading;
using System.Windows.Forms;

namespace Common
{
    public static class Process
    {
        /// <summary>
        /// Multiple start check
        /// </summary>
        public static void ExcludeMultipleStartUp(string strProductName)
        {
            Mutex objMutex = new Mutex(false, strProductName);

            if (!objMutex.WaitOne(0, false))
            {
                return;
            }

            GC.KeepAlive(objMutex);
            Application.Run();
        }
    }
}
