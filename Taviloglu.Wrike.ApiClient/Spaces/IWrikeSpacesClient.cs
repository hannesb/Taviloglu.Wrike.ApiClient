using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Spaces;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Space operations
    /// </summary>
    public interface IWrikeSpacesClient
    {
        /// <summary>
        /// Returns a list of spaces.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="withArchived">Include archived spaces</param>
        /// <param name="userIsMember">Include only spaces where user is member</param>
        /// <param name="optionalFields">Optional fields to be included in the response model 
        /// Use <see cref="WrikeSpace.OptionalFields"/></param>
        /// See <see href="https://developers.wrike.com/api/v4/spaces/#get-spaces"/>
        Task<List<WrikeSpace>> GetAsync(bool withArchived = false, bool? userIsMember = null, List<string> optionalFields = null);

        /// <summary>
        /// Returns info about a space.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="id">Space Id</param>
        /// <param name="optionalFields">Optional fields to be included in the response model 
        /// Use <see cref="WrikeSpace.OptionalFields"/></param>
        /// See <see href="https://developers.wrike.com/api/v4/spaces/#get-space"/>
        Task<WrikeSpace> GetAsync(WrikeClientIdParameter id, List<string> optionalFields = null);

        /// <summary>
        /// Create a space.
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="newSpace"></param>
        /// <param name="optionalFields">Optional fields to be included in the response model 
        /// Use <see cref="WrikeSpace.OptionalFields"/></param>
        /// See <see href="https://developers.wrike.com/api/v4/spaces/#create-space"/>
        Task<WrikeSpace> CreateAsync(WrikeSpace newSpace, List<string> optionalFields = null);

        /// <summary>
        ///  Update a space.
        /// Scopes: Default, wsReadWrite
        /// <param name="id">Space Id</param>
        /// <param name="newSpace"></param>
        /// <param name="membersToAdd">Add specified users to Space</param>
        /// <param name="membersToUpdate">Add specified users to Space</param>
        /// <param name="membersToRemove">Remove specified users from Space</param>
        /// <param name="suggestedProjectWorkflowsAdd">Add specified users to Space</param>
        /// <param name="suggestedProjectWorkflowsRemove">Remove specified users from Space</param>
        /// <param name="suggestedTaskWorkflowsAdd">Add specified users to Space</param>
        /// <param name="suggestedTaskWorkflowsRemove">Remove specified users from Space</param>
        /// <param name="optionalFields">Optional fields to be included in the response model 
        /// Use <see cref="WrikeSpace.OptionalFields"/></param>
        /// See <see href="https://developers.wrike.com/api/v4/spaces/#update-space"/>
        /// </summary>
        Task<WrikeSpace> UpdateAsync(WrikeClientIdParameter id, WrikeSpace newSpace, List<WrikeSpaceMember> membersToAdd = null, 
            List<WrikeSpaceMember> membersToUpdate = null, List<string> membersToRemove = null,
            List<string> suggestedProjectWorkflowsAdd = null, List<string> suggestedProjectWorkflowsRemove = null,
            List<string> suggestedTaskWorkflowsAdd = null, List<string> suggestedTaskWorkflowsRemove = null,
            List<string> optionalFields = null);

        /// <summary>
        /// Delete space by Id
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="id">Space Id</param>  
        /// See <see href="https://developers.wrike.com/api/v4/spaces/#delete-space"/>
        Task DeleteAsync(WrikeClientIdParameter id);




    }
}
