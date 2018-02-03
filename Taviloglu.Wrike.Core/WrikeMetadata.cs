﻿using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Taviloglu.Wrike.Core
{
    public class WrikeMetadata
    {
       [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
       [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }

}
