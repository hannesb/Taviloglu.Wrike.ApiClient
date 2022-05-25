using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.WorkSchedules;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Work schedules operations
    /// </summary>
    public interface IWrikeWorkSchedulesClient
    {
        /// <summary>
        /// Returns list of all work schedules in account.
        /// Scopes: amReadOnlyWorkSchedule, amReadWriteWorkSchedule
        /// </summary>
        /// <param name="optionalFields">Optional fields to be included in the response model 
        /// Use <see cref="WrikeWorkSchedule.OptionalFields"/></param>
        /// See <see href="https://developers.wrike.com/api/v4/spaces/#get-spaces"/>
        Task<List<WrikeWorkSchedule>> GetAsync(List<string> optionalFields = null);

        /// <summary>
        /// Get work schedule by Id.
        /// Scopes: amReadOnlyWorkSchedule, amReadWriteWorkSchedule
        /// </summary>
        /// <param name="id">Workschedule Id</param>
        /// <param name="optionalFields">Optional fields to be included in the response model 
        /// Use <see cref="WrikeWorkSchedule.OptionalFields"/></param>
        /// See <see href="https://developers.wrike.com/api/v4/spaces/#get-space"/>
        Task<WrikeWorkSchedule> GetAsync(WrikeClientIdParameter id, List<string> optionalFields = null);

        // TODO: implement Create/Update/Delete
    }
}
