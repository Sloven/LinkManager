using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Services.Helpers;

namespace Backend.UnitTest.Services
{
    [TestFixture]
    public class URLShortenerTests
    {
        [TestCase(12312311231231254L)]
        [TestCase(0L)]
        [TestCase(10312812543449869L)]
        [TestCase(999999999999999999L)]
        public void SampleId_is_shortened(long aliasId)
        {
            var uss = new URLShortener();

            var result = uss.Encode(aliasId);

            Assert.Less(result.Length, aliasId.ToString().Length);
            Assert.IsInstanceOf<string>(result);
        }

        [TestCase("23232")]
        [TestCase("U")]
        [TestCase("3282543449869L")]
        [TestCase("cdfgsCDFGSGFDGFDGFDGFDGFDGFDGFDGFDGFDGSDFFGSDFGDSFGDSFGSDFGDSFGDSgfsdFGSDfgdsFGSDfgdsFGDSfgfgsfgSDfgsdFGSDfgsdFGSDfg")]
        public void ShortPath_is_long(string str)
        {
            var uss = new URLShortener();

            var result = uss.Decode(str);

            Assert.IsInstanceOf<long>(result);
        }
    }
}
