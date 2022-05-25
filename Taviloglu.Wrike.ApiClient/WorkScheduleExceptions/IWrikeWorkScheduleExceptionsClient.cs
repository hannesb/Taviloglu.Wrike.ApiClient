using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.WorkScheduleExceptions;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Work schedule exceptions operations
    /// </summary>
    public interface IWrikeWorkScheduleExceptionsClient
    {
        /// <summary>
        /// Get all exceptions for given schedule.
        /// Scopes: amReadOnlyWorkSchedule, amReadWriteWorkSchedule
        /// </summary>
        /// <param name="id">id of work schedule</param>
        /// <param name="wrikeDateFilter">Filter by Start to End or by Equal</param>
        /// See <see href="https://developers.wrike.com/api/v4/work-schedule-exceptions/#query-work-schedule-exceptions"/>
        Task<List<WrikeWorkScheduleException>> GetAsync(WrikeClientIdParameter id, IWrikeDateFilter wrikeDateFilter);

        /// <summary>
        /// Get exception by Id.
        /// Scopes: amReadOnlyWorkSchedule, amReadWriteWorkSchedule
        /// </summary>
        /// <param name="id">id of work schedule exception</param>
        /// See <see href="https://developers.wrike.com/api/v4/work-schedule-exceptions/#query-work-schedule-exceptions"/>
        Task<WrikeWorkScheduleException> GetAsync(WrikeClientIdParameter id);

        // TODO: implement Create/Update/Delete
    }
}
