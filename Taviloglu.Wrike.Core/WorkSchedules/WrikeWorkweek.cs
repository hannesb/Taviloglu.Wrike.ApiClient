using Newtonsoft.Json;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Extensions;

namespace Taviloglu.Wrike.Core.WorkSchedules
{
    public sealed class WrikeWorkweek : IWrikeObject
    {
        public WrikeWorkweek(List<string> workDays, int? capacityMinutes)
        {
            WorkDays = workDays;
            CapacityMinutes = capacityMinutes;
        }

        [JsonProperty("workDays")]
        public List<string> WorkDays { get; set; }

        [JsonProperty("capacityMinutes")]
        public int? CapacityMinutes { get; private set; }
    }
}
