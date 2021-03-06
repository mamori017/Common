﻿ using System;

namespace Common
{
    public static class Log
    {
        public static void Output(String outputDetail, String filePath, String fileName)
        {
            if (IO.DirectoryCheck(filePath, true))
            {
                IO.CreateTextFile(filePath, fileName, outputDetail, true, IO.EncodeType.utf8);
            }
        }

        public static void ExceptionOutput(Exception ex, String filePath, String fileName)
        {
            var outputDetail = "";

            outputDetail = ex.Message + "\n" + 
                           ex.InnerException + "\n" + 
                           ex.StackTrace + "\n" + 
                           ex.Source;

            if (IO.DirectoryCheck(filePath, true))
            {
                IO.CreateTextFile(filePath, fileName, outputDetail, true, IO.EncodeType.utf8);
            }
        }
    }
}
