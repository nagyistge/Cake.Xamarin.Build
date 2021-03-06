﻿using NUnit.Framework;
using System;
using Cake.Xamarin.Tests.Fakes;
using Cake.Core.IO;
using Cake.Xamarin.Build;

namespace Cake.FileHelpers.Tests
{
    [TestFixture]
    public class DownloadFileTests : TestFixtureBase
    {
        [Test]
        public void Download_FacebookSDK ()
        {
            var url = "https://origincache.facebook.com/developers/resources/?id=FacebookSDKs-iOS-20160210.zip";

            var destFile = new FilePath("./fbsdk.zip");

            Cake.DownloadFile(url, destFile, new DownloadFileSettings
            {
                UserAgent = "curl/7.43.0"
            });
            
            var fileInfo = new System.IO.FileInfo(destFile.MakeAbsolute(Cake.Environment).FullPath);

            Assert.IsTrue(fileInfo.Exists);
            Assert.Greater(fileInfo.Length, 1024);
        }
    }
}

