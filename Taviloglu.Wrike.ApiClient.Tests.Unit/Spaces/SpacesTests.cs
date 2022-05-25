using NUnit.Framework;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Spaces;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Spaces
{
    [TestFixture]
    public class SpacesTests
    {
        [Test]
        public void SpacesProperty_ShouldReturnSpacesClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeSpacesClient), TestConstants.WrikeClient.Spaces);
        }

        [Test]
        public void GetAsync_WhenOptionalFieldsNotSupported_ThrowArgumentOutOfRangeException()
        {
            var ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => 
                TestConstants.WrikeClient.Spaces.GetAsync(optionalFields: new List<string> { "dummyfieldname" }));
            Assert.AreEqual("optionalFields", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("Use only values in WrikeSpace.OptionalFields"));
        }

        [Test]
        public void GetAsyncWithId_WhenOptionalFieldsNotSupported_ThrowArgumentOutOfRangeException()
        {
            var ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                TestConstants.WrikeClient.Spaces.GetAsync("<spaceId>", optionalFields: new List<string> { "dummyfieldname" }));
            Assert.AreEqual("optionalFields", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("Use only values in WrikeSpace.OptionalFields"));
        }

    }
}
