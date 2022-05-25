using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Extensions;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.Core.UserScheduleExceptions
{
    public class WrikeUserScheduleException : WrikeObjectWithId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrikeUserScheduleException"></see> class
        /// </summary>
        /// <param name="contactId">Contact ID</param>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        /// <param name="isWorkDays">True if this exception is for working days</param>
        /// <param name="exceptionType">Type of exception</param>
        public WrikeUserScheduleException(string contactId, DateTime fromDate, DateTime toDate, bool isWorkDays, WrikeUserScheduleExceptionType exceptionType)
        {
            ContactId = contactId;
            FromDate = fromDate;
            ToDate = toDate;
            IsWorkDays = isWorkDays;
            ExceptionType = exceptionType;
        }

        /// <summary>
        /// Contact ID
        /// </summary>
        [JsonProperty("userId")]
        public string ContactId { get; private set; }

        /// <summary>
        /// From date
        /// </summary>
        [JsonProperty("fromDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd" })]
        public DateTime FromDate { get; private set; }

        /// <summary>
        /// To date
        /// </summary>
        [JsonProperty("toDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd" })]
        public DateTime ToDate { get; private set; }

        /// <summary>
        /// True if this exception is for working days
        /// </summary>
        [JsonProperty("isWorkDays")]
        public bool IsWorkDays { get; private set; }

        /// <summary>
        /// Type of exception
        /// </summary>
        [JsonProperty("exclusionType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeUserScheduleExceptionType ExceptionType { get; private set; }

    }
}
