using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Spaces;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeSpacesClient
    {
        public IWrikeSpacesClient Spaces { get { return this; } }

        async Task<List<WrikeSpace>> IWrikeSpacesClient.GetAsync(bool withArchived, bool? userIsMember, List<string> optionalFields)
        {
            if (optionalFields != null && optionalFields.Count > 0 && optionalFields.Except(WrikeSpace.OptionalFields.List).Any()) {
                throw new ArgumentOutOfRangeException(nameof(optionalFields), "Use only values in WrikeSpace.OptionalFields");
            }

            var uriBuilder = new WrikeUriBuilder("spaces")
                .AddParameter("withArchived", withArchived)
                .AddParameter("userIsMember", userIsMember)
                .AddParameter("fields", optionalFields);            

            var response = await SendRequest<WrikeSpace>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeSpace> IWrikeSpacesClient.GetAsync(WrikeClientIdParameter id, List<string> optionalFields)
        {
            if (optionalFields != null && optionalFields.Count > 0 && optionalFields.Except(WrikeSpace.OptionalFields.List).Any()) {
                throw new ArgumentOutOfRangeException(nameof(optionalFields), "Use only values in WrikeSpace.OptionalFields");
            }

            var uriBuilder = new WrikeUriBuilder($"spaces/{id}")
                .AddParameter("fields", optionalFields);

            var response = await SendRequest<WrikeSpace>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeSpace> IWrikeSpacesClient.CreateAsync(WrikeSpace newSpace, List<string> optionalFields)
        {
            if (newSpace == null) {
                throw new ArgumentNullException(nameof(newSpace));
            }

            var requestUri = $"spaces";

            var postDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("accessType", newSpace.AccessType)
                .AddParameter("title", newSpace.Title)
                .AddParameter("description", newSpace.Description)
                .AddParameter("members", newSpace.Members)
                .AddParameter("guestRoleId", newSpace.GuestRoleId)
                .AddParameter("defaultProjectWorkflowId", newSpace.DefaultProjectWorkflowId)
                .AddParameter("suggestedProjectWorkflows", newSpace.SuggestedProjectWorkflowIds)
                .AddParameter("defaultTaskWorkflowId", newSpace.DefaultTaskWorkflowId)
                .AddParameter("suggestedTaskWorkflows", newSpace.SuggestedTaskWorkflowIds)
                .AddParameter("fields", optionalFields);

            var postContent = postDataBuilder.GetContent();
            var response = await SendRequest<WrikeSpace>(requestUri, HttpMethods.Post, postContent).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeSpace> IWrikeSpacesClient.UpdateAsync(WrikeClientIdParameter id, WrikeSpace newSpace, 
            List<WrikeSpaceMember> membersToAdd, List<WrikeSpaceMember> membersToUpdate, List<string> membersToRemove,
            List<string> suggestedProjectWorkflowsAdd, List<string> suggestedProjectWorkflowsRemove,
            List<string> suggestedTaskWorkflowsAdd, List<string> suggestedTaskWorkflowsRemove,
            List<string> optionalFields)
        {
            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("accessType", newSpace.AccessType)
                .AddParameter("title", newSpace.Title)
                .AddParameter("description", newSpace.Description)
                .AddParameter("guestRoleId", newSpace.GuestRoleId)
                .AddParameter("defaultProjectWorkflowId", newSpace.DefaultProjectWorkflowId)
                .AddParameter("defaultTaskWorkflowId", newSpace.DefaultTaskWorkflowId)
                .AddParameter("membersAdd", membersToAdd)
                .AddParameter("membersUpdate", membersToUpdate)
                .AddParameter("membersRemove", membersToRemove)
                .AddParameter("suggestedProjectWorkflowsAdd", suggestedProjectWorkflowsAdd)
                .AddParameter("suggestedProjectWorkflowsRemove", suggestedProjectWorkflowsRemove)
                .AddParameter("suggestedTaskWorkflowsAdd", suggestedTaskWorkflowsAdd)
                .AddParameter("suggestedTaskWorkflowsRemove", suggestedTaskWorkflowsRemove)
                .AddParameter("fields", optionalFields)
                ;

            var response = await SendRequest<WrikeSpace>($"spaces/{id}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task IWrikeSpacesClient.DeleteAsync(WrikeClientIdParameter id)
        {
            var uriBuilder = new WrikeUriBuilder($"spaces/{id}");
            
            await SendRequest<WrikeSpace>(uriBuilder.GetUri(), HttpMethods.Delete).ConfigureAwait(false);
        }

    }
}
