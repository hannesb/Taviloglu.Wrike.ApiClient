using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Extensions;

namespace Taviloglu.Wrike.Core.Spaces
{
    /// <summary>
    /// User Groups are customizable groups made up of selected users.
    /// </summary>
    public sealed class WrikeSpace : WrikeObjectWithId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrikeSpace"></see> class with the
        ///  title, memberIds and metadata for the new space.
        /// </summary>
        /// <param name="title">Title of space</param>
        public WrikeSpace(string title)
        {
            title.ValidateParameter(nameof(title));

            Title = title;
        }

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; private set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Avatar URL
        /// </summary>
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Access type
        /// </summary>
        [JsonProperty("accessType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeSpaceAccessType AccessType { get; set; }

        /// <summary>
        /// Space is archived
        /// </summary>
        [JsonProperty("archived")]
        public bool Archived { get; set; }

        /// <summary>
        /// Space members
        /// </summary>
        [JsonProperty("members")]
        public List<WrikeSpaceMember> Members { get; set; }

        /// <summary>
        /// Guest Role ID, available only for a public space
        /// </summary>
        [JsonProperty("guestRoleId")]
        public string GuestRoleId { get; set; }

        /// <summary>
        /// Default project workflow ID for a space
        /// </summary>
        [JsonProperty("defaultProjectWorkflowId")]
        public string DefaultProjectWorkflowId { get; set; }

        /// <summary>
        /// Suggested project workflows IDs for a space.
        /// </summary>
        [JsonProperty("suggestedProjectWorkflowIds")]
        public List<string> SuggestedProjectWorkflowIds { get; set; }

        /// <summary>
        /// Default task workflow ID for a space
        /// </summary>
        [JsonProperty("defaultTaskWorkflowId")]
        public string DefaultTaskWorkflowId { get; set; }

        /// <summary>
        /// Suggested task workflows IDs for a space.
        /// </summary>
        [JsonProperty("suggestedTaskWorkflowIds")]
        public List<string> SuggestedTaskWorkflowIds { get; set; }

        /// <summary>
        /// Optional fields to be included in the response model 
        /// </summary>
        public class OptionalFields
        {

            public static List<string> List = new List<string> { Members, SuggestedProjectWorkflows, SuggestedTaskWorkflows };

            /// <summary>
            /// Space members
            /// </summary>
            public const string Members = "members";
            /// <summary>
            /// Suggested project workflows for a space.
            /// Not allowed in 'Get Spaces'
            /// </summary>
            public const string SuggestedProjectWorkflows = "suggestedProjectWorkflows";
            /// <summary>
            /// Suggested task workflows for a space
            /// Not allowed in 'Get Spaces'
            /// </summary>
            public const string SuggestedTaskWorkflows = "suggestedTaskWorkflows";
        }

    }
}
