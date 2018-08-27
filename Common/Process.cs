using System;
using System.Threading;
using System.Windows.Forms;

namespace Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class Process
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strProductName"></param>
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
