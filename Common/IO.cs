using System;
using System.IO;
using System.Text;

namespace Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class IO
    {
        /// <summary>
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="makeDir"></param>
        /// <returns></returns>
        public static bool DirectoryCheck(string directoryPath, bool makeDir = false)
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    if (makeDir)
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public enum EncodeType
        {
            utf8,
            sjis
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="outputString"></param>
        /// <param name="append"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static bool CreateTextFile(string filePath, string fileName, string outputString, bool append = true, EncodeType encode = EncodeType.utf8)
        {

            String outputFilePath = "";
            Encoding objEncoding = null;
            StreamWriter objWriter = null;

            try
            {
                DirectoryCheck(filePath, true);

                // Set text file full path
                if (filePath.Substring(filePath.Length - 1) != "\\")
                {
                    outputFilePath = filePath + "\\" + fileName;
                }
                else
                {
                    outputFilePath = filePath + fileName;
                }

                // Encode type
                if (encode == EncodeType.sjis)
                {
                    objEncoding = Encoding.GetEncoding(932);
                }
                else
                {
                    objEncoding = Encoding.UTF8;
                }

                // Stream
                objWriter = new StreamWriter(outputFilePath, append, objEncoding);

                objWriter.Write(outputString);

                objWriter.Close();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objEncoding = null;
                objWriter = null;
            }
        }

    }
}
