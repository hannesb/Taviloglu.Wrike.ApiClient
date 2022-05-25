using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.UserScheduleExceptions;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// User schedule exceptions operations
    /// </summary>
    public interface IWrikeUserScheduleExceptionsClient
    {
        /// <summary>
        /// Get exceptions for given users and date range.
        /// Scopes: amReadOnlyWorkSchedule, amReadWriteWorkSchedule
        /// </summary>
        /// <param name="wrikeDateFilter">Query exceptions for given date range</param>
        /// <param name="userIds">Query exceptions for given user ids (max. 100 ids)</param>
        /// See <see href="https://developers.wrike.com/api/v4/user-schedule-exceptions/#query-user-schedule-exception"/>
        Task<List<WrikeUserScheduleException>> GetAsync(IWrikeDateFilter wrikeDateFilter, WrikeClientIdListParameter userIds);

        /// <summary>
        /// Get exception by Id.
        /// Scopes: amReadOnlyWorkSchedule, amReadWriteWorkSchedule
        /// </summary>
        /// <param name="id">id of user schedule exception</param>
        /// See <see href="https://developers.wrike.com/api/v4/user-schedule-exceptions/#query-user-schedule-exception"/>
        Task<WrikeUserScheduleException> GetAsync(WrikeClientIdParameter id);

        // TODO: implement Create/Update/Delete
    }
}
