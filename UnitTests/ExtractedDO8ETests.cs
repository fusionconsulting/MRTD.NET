﻿using System;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.DataObjects.Extracted;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class ExtractedDO8ETests
    {
        [Test]
        public void Extract_DO8E_from_protectedResponseApdu()
        {
            Assert.AreEqual(
                    "8E08AD55CC17140B2DED",
                    new Hex(
                        new ExtractedDO8E(
                            new BinaryHex("8709019FF0EC34F9922651990290008E08AD55CC17140B2DED9000")
                        )
                    ).ToString()
                );
        }
    }
}
