using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Extensions;

namespace Taviloglu.Wrike.Core.WorkSchedules
{
    public class WrikeWorkSchedule : WrikeObjectWithId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrikeWorkSchedule"></see> class with title
        /// </summary>
        /// <param name="title"></param>
        public WrikeWorkSchedule(string title)
        {
            title.ValidateParameter(nameof(title));

            Title = title;
        }

        /// <summary>
        /// Status of task 
        /// </summary>
        [JsonProperty("scheduleType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeWorkScheduleType ScheduleType { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; private set; }

        /// <summary>
        /// Work week (why list?!?)
        /// </summary>
        [JsonProperty("workweek")]
        public List<WrikeWorkweek> Workweek { get; set; }

        /// <summary>
        /// List of Contact Ids
        /// </summary>
        [JsonProperty("userIds")]
        public List<string> UserIds { get; set; }

        /// <summary>
        /// Optional fields to be included in the response model 
        /// </summary>
        public class OptionalFields
        {
            public static List<string> List = new List<string> { Users };

            /// <summary>
            /// Users assigned to WorkSchedule
            /// </summary>
            public const string Users = "userIds";
        }

    }
}
