using System;
using System.IO;
using System.Text;

namespace Common
{
    public static class IO
    {
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

        public enum EncodeType
        {
            utf8,
            sjis
        }

        public static bool CreateTextFile(string filePath, string fileName, string outputString, bool append = true, EncodeType encode = EncodeType.utf8)
        {
            try
            {
                DirectoryCheck(filePath, true);

                string outputFilePath = filePath.Substring(filePath.Length - 1) != "\\" ? filePath + "\\" + fileName : filePath + fileName;

                Encoding objEncoding = encode == EncodeType.sjis ? Encoding.GetEncoding(932) : Encoding.UTF8;

                using (var objWriter = new StreamWriter(outputFilePath, append, objEncoding))
                {
                    objWriter.Write(outputString);
                    objWriter.Close();
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
