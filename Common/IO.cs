using System;
using System.IO;
using System.Text;

namespace Common
{
    /// <summary>
    /// 入出力
    /// </summary>
    public static class IO
    {
        /// <summary>
        /// ディレクトリ存在チェック
        /// </summary>
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
        /// エンコードタイプ
        /// </summary>
        public enum EncodeType
        {
            utf8,
            sjis
        }

        /// <summary>
        /// テキストファイル作成
        /// </summary>
        /// <param name="outputString"></param>
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
