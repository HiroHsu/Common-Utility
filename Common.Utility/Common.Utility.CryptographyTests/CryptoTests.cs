using NUnit.Framework;
using Common.Utility.Cryptography;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utility.Cryptography.Tests
{
    [TestFixture()]
    public class CryptoTests
    {
        [TestCase("12345ABCDE", ExpectedResult = "fc85a7ce091aea86ef3463b9166e9b06")]
        
        public string MD5HashTest(string words)
        {
            return words.MD5Hash();
        }
    }
}