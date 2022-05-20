using Newtonsoft.Json;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Extensions;

namespace Taviloglu.Wrike.Core.Spaces
{
    public sealed class WrikeSpaceMember : IWrikeObject
    {
        public WrikeSpaceMember(string id, string accessRoleId, bool isManager)
        {
            id.ValidateParameter(nameof(id));
            accessRoleId.ValidateParameter(nameof(accessRoleId));

            Id = id;
            AccessRoleId = accessRoleId;
            IsManager = isManager;
        }

        /// <summary>
        /// Contact ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Access Role ID
        /// </summary>
        [JsonProperty("accessRoleId")]
        public string AccessRoleId { get; private set; }

        /// <summary>
        /// User is Space manager
        /// </summary>
        [JsonProperty("isManager")]
        public bool IsManager { get; set; }
    }
}
