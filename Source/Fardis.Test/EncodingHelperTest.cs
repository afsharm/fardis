using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Fardis.Test
{
    [TestFixture]
    public class EncodingHelperTest
    {
        [Test]
        public void ToCSharpTest()
        {
            char[] chars = { 'a', 'ش', '`', '2', '۳', 'ك', 'ف', 'P' };
            string[] csharp = { @"\u0061", @"\u0634", @"\u0060", @"\u0032", @"\u06f3", @"\u0643", @"\u0641", @"\u0050" };

            if (chars.Length != csharp.Length)
                Assert.Inconclusive("array lengths are not same");

            for (int i = 0; i < chars.Length; i++)
                Assert.AreEqual(csharp[i], EncodingHelper.GetCSharpRep(chars[i]));
        }

        [Test]
        public void HasRtlTextTest()
        {
            Assert.IsTrue(EncodingHelper.HasRtlText("hjkduekلsdoekjsd 389x9df skdhsd 9sdfu "));
            Assert.IsFalse(EncodingHelper.HasRtlText("hjkdueksdoekjsd 389x9df skdhsd 9sdfu "));
        }

        [Test]
        public void IsRtlCharTest()
        {
            Assert.IsTrue(EncodingHelper.IsRtlChar('ش'));
            Assert.IsFalse(EncodingHelper.IsRtlChar('A'));
        }
    }
}
