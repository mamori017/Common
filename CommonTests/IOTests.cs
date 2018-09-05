using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using CommonTests.Properties;

namespace Common.Tests
{
    [TestClass()]
    public class IOTests
    {
        [TestMethod()]
        public void DirectoryCheckOnlyTest()
        {
            // Directory not exist
            // Directory check only
            if (Directory.Exists(IoSettings.Default.IODirectoryPath))
            {
                Directory.Delete(IoSettings.Default.IODirectoryPath);
            }

            Assert.AreEqual(true, IO.DirectoryCheck(IoSettings.Default.IODirectoryPath));

            DirectoryCheckTestAfterProcess();
        }

        [TestMethod()]
        public void DirectoryCheckAndCreateNewOneTest()
        {
            // Directory not exist
            // Directory check and create new one

            if (IO.DirectoryCheck(IoSettings.Default.IODirectoryPath, true))
            {
                Assert.AreEqual(true, Directory.Exists(IoSettings.Default.IODirectoryPath));
            }

            DirectoryCheckTestAfterProcess();
        }

        [TestMethod()]
        public void DirectoryCheckTargetExist()
        {
            // Directory exist
            if (!Directory.Exists(IoSettings.Default.IODirectoryPath))
            {
                Directory.CreateDirectory(IoSettings.Default.IODirectoryPath);
            }

            Assert.AreEqual(false, IO.DirectoryCheck(IoSettings.Default.IODirectoryPath));

            DirectoryCheckTestAfterProcess();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void DirectoryCheckArgumentException()
        {
            try
            {
                // Directory exist
                if (!Directory.Exists(IoSettings.Default.IODirectoryPath))
                {
                    Directory.CreateDirectory(IoSettings.Default.IODirectoryPath);
                }
                else
                {
                    Directory.Delete(IoSettings.Default.IODirectoryPath, true);
                }

                IO.DirectoryCheck("?" + IoSettings.Default.IODirectoryPath, true);
            }
            finally
            {
                DirectoryCheckTestAfterProcess();
            }
        }

        private void DirectoryCheckTestAfterProcess()
        {
            // Delete test object
            if (Directory.Exists(IoSettings.Default.IODirectoryPath))
            {
                Directory.Delete(IoSettings.Default.IODirectoryPath,true);
            }
        }

        [TestMethod()]
        public void CreateTextFileTest()
        {
            // Delete test object
            if (Directory.Exists(IoSettings.Default.IODirectoryPath))
            {
                Directory.Delete(IoSettings.Default.IODirectoryPath,true);
            }

            Assert.AreEqual(true, IO.CreateTextFile(IoSettings.Default.IOFilePath,
                                                    IoSettings.Default.IOFileName,
                                                    "test",
                                                    false,
                                                    IO.EncodeType.sjis));

            Assert.AreEqual(true, IO.CreateTextFile(IoSettings.Default.IOFilePath,
                                                    IoSettings.Default.IOFileName,
                                                    "test",
                                                    true,
                                                    IO.EncodeType.utf8));

            Assert.AreEqual(true, IO.CreateTextFile(IoSettings.Default.IOFilePath + "\\",
                                                    IoSettings.Default.IOFileName,
                                                    "test",
                                                    true,
                                                    IO.EncodeType.utf8));



            StreamReader reader = new StreamReader(IoSettings.Default.IOFilePath + "\\" +
                                                   IoSettings.Default.IOFileName);

            String a = reader.ReadToEnd();

            Assert.AreEqual(a, "testtesttest");

            reader.Close();

            File.Delete(IoSettings.Default.IOFilePath + "\\" +
                                                   IoSettings.Default.IOFileName);
        }

        [TestMethod()]
        [ExpectedException(typeof(IOException))]
        public void CreateTextFileIOExceptionTest()
        {
            StreamReader reader = null;

            // Delete test object
            if (Directory.Exists(IoSettings.Default.IODirectoryPath))
            {
                Directory.Delete(IoSettings.Default.IODirectoryPath, true);
            }

            Assert.AreEqual(true, IO.CreateTextFile(IoSettings.Default.IOFilePath,
                  IoSettings.Default.IOFileName,
                  "test",
                  false,
                  IO.EncodeType.utf8));

            try
            {
                reader = new StreamReader(IoSettings.Default.IOFilePath + "\\" +
                                          IoSettings.Default.IOFileName);

                String a = reader.ReadToEnd();

                IO.CreateTextFile(IoSettings.Default.IOFilePath,
                                  IoSettings.Default.IOFileName,
                                  "test",
                                  false,
                                  IO.EncodeType.utf8);
            }
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                    Directory.Delete(IoSettings.Default.IODirectoryPath, true);
                }
            }

        }


    }
}