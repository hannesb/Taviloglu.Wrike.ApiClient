using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.Spaces;

namespace Taviloglu.Wrike.Core.Tests.Unit
{
    [TestFixture]
    public class WrikeSpaceMemberTests
    {
        [Test]
        public void Ctor_WhenIdEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeSpaceMember(string.Empty, "<accessRoleId>", false));
            Assert.AreEqual("id", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenIdNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeSpaceMember(null, "<accessRoleId>", false));
            Assert.AreEqual("id", ex.ParamName);
        }
        [Test]
        public void Ctor_WhenAccessRoleIdEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeSpaceMember("<id>", string.Empty, false));
            Assert.AreEqual("accessRoleId", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenAccessRoleIdNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeSpaceMember("<id>", null, false));
            Assert.AreEqual("accessRoleId", ex.ParamName);
        }
    }
}
