﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

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
            if (Directory.Exists(CommonTests.Properties.Settings.Default.IODirectoryPath))
            {
                Directory.Delete(CommonTests.Properties.Settings.Default.IODirectoryPath);
            }

            Assert.AreEqual(true, IO.DirectoryCheck(CommonTests.Properties.Settings.Default.IODirectoryPath));

            DirectoryCheckTestAfterProcess();
        }

        [TestMethod()]
        public void DirectoryCheckAndCreateNewOneTest()
        {
            // Directory not exist
            // Directory check and create new one

            if (IO.DirectoryCheck(CommonTests.Properties.Settings.Default.IODirectoryPath, true))
            {
                Assert.AreEqual(true, Directory.Exists(CommonTests.Properties.Settings.Default.IODirectoryPath));
            }

            DirectoryCheckTestAfterProcess();
        }

        [TestMethod()]
        public void DirectoryCheckTargetExist()
        {
            // Directory exist
            if (!Directory.Exists(CommonTests.Properties.Settings.Default.IODirectoryPath))
            {
                Directory.CreateDirectory(CommonTests.Properties.Settings.Default.IODirectoryPath);
            }

            Assert.AreEqual(false, IO.DirectoryCheck(CommonTests.Properties.Settings.Default.IODirectoryPath));

            DirectoryCheckTestAfterProcess();
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void DirectoryCheckArgumentException()
        {
            try
            {
                // Directory exist
                if (!Directory.Exists(CommonTests.Properties.Settings.Default.IODirectoryPath))
                {
                    Directory.CreateDirectory(CommonTests.Properties.Settings.Default.IODirectoryPath);
                }
                else
                {
                    Directory.Delete(CommonTests.Properties.Settings.Default.IODirectoryPath, true);
                }

                IO.DirectoryCheck("?" + CommonTests.Properties.Settings.Default.IODirectoryPath, true);
            }
            finally
            {
                DirectoryCheckTestAfterProcess();
            }
        }

        private void DirectoryCheckTestAfterProcess()
        {
            // Delete test object
            if (Directory.Exists(CommonTests.Properties.Settings.Default.IODirectoryPath))
            {
                Directory.Delete(CommonTests.Properties.Settings.Default.IODirectoryPath,true);
            }
        }

       


        [TestMethod()]
        public void CreateTextFileTest()
        {
            // Delete test object
            if (Directory.Exists(CommonTests.Properties.Settings.Default.IODirectoryPath))
            {
                Directory.Delete(CommonTests.Properties.Settings.Default.IODirectoryPath,true);
            }

            Assert.AreEqual(true, IO.CreateTextFile(CommonTests.Properties.Settings.Default.IOFilePath,
                  CommonTests.Properties.Settings.Default.IOFileName,
                  "test",
                  false,
                  IO.EncodeType.sjis));

            Assert.AreEqual(true,IO.CreateTextFile(CommonTests.Properties.Settings.Default.IOFilePath,
                              CommonTests.Properties.Settings.Default.IOFileName,
                              "test",
                              true,
                              IO.EncodeType.utf8));



            StreamReader reader = new StreamReader(CommonTests.Properties.Settings.Default.IOFilePath + "\\" + 
                                                   CommonTests.Properties.Settings.Default.IOFileName);

            String a = reader.ReadToEnd();

            Assert.AreEqual(a, "testtest");

            reader.Close();

            File.Delete(CommonTests.Properties.Settings.Default.IOFilePath + "\\" +
                                                   CommonTests.Properties.Settings.Default.IOFileName);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.IO.IOException))]
        public void tetet()
        {
            StreamReader reader = null;

            // Delete test object
            if (Directory.Exists(CommonTests.Properties.Settings.Default.IODirectoryPath))
            {
                Directory.Delete(CommonTests.Properties.Settings.Default.IODirectoryPath, true);
            }

            Assert.AreEqual(true, IO.CreateTextFile(CommonTests.Properties.Settings.Default.IOFilePath,
                  CommonTests.Properties.Settings.Default.IOFileName,
                  "test",
                  false,
                  IO.EncodeType.utf8));

            try
            {
                reader = new StreamReader(CommonTests.Properties.Settings.Default.IOFilePath + "\\" +
                                                       CommonTests.Properties.Settings.Default.IOFileName);

                String a = reader.ReadToEnd();

                IO.CreateTextFile(CommonTests.Properties.Settings.Default.IOFilePath,
                      CommonTests.Properties.Settings.Default.IOFileName,
                      "test",
                      false,
                      IO.EncodeType.utf8);
            }
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                    Directory.Delete(CommonTests.Properties.Settings.Default.IODirectoryPath, true);
                }
            }

        }


    }
}