using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Taviloglu.Wrike.Core.Spaces;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Spaces
{
    [TestFixture, Order(19)]
    public class SpacesTests
    {
        const string PersonalFolderId = "IEACGXLUI4KZG6UV";

        readonly List<string> DefaultSpaceIds = new List<string> { PersonalFolderId };
        readonly List<string> SupportedOptionalFields = new List<string> { WrikeSpace.OptionalFields.Members, WrikeSpace.OptionalFields.SuggestedProjectWorkflows, WrikeSpace.OptionalFields.SuggestedTaskWorkflows };


        [OneTimeTearDown]
        public void ReturnToDefaults()
        {
            var spaces = WrikeClientFactory.GetWrikeClient().Spaces.GetAsync().Result;

            foreach (var space in spaces) {
                if (!DefaultSpaceIds.Contains(space.Id) && space.Title.StartsWith("IntegrationTest")) {
                    WrikeClientFactory.GetWrikeClient().Tasks.DeleteAsync(space.Id).Wait();
                }
            }
        }

        [Test, Order(1)]
        public void GetAsync_ShouldReturnSpaces()
        {
            var spaces = WrikeClientFactory.GetWrikeClient().Spaces.GetAsync().Result;
            Assert.IsNotNull(spaces);
            Assert.GreaterOrEqual(spaces.Count, DefaultSpaceIds.Count);
        }

        [Test, Order(2)]
        public void GetAsyncWithId_ShouldReturnDefaultSpace()
        {
            var space = WrikeClientFactory.GetWrikeClient().Spaces.GetAsync(PersonalFolderId, SupportedOptionalFields).Result;
            Assert.IsNotNull(space);
            Assert.AreEqual(PersonalFolderId, space.Id);
        }

#if false
        // not_allowed: Operation is not allowed due insufficient user rights or account license limitations
        [Test, Order(3)]
        public void CreateAsync_ShouldAddNewSpaceWithTitle()
        {            
            var newSpace = new WrikeSpace("IntegrationTest Space #2");
            
            var createdSpace = WrikeClientFactory.GetWrikeClient().Spaces.CreateAsync(newSpace).Result;

            Assert.IsNotNull(createdSpace);
            Assert.AreEqual(newSpace.Title, createdSpace.Title);
        }
#endif
    }
}
