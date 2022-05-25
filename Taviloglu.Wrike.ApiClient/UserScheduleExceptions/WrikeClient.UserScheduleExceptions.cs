using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Json;
using Taviloglu.Wrike.Core.UserScheduleExceptions;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeUserScheduleExceptionsClient
    {
        public IWrikeUserScheduleExceptionsClient UserScheduleExceptions { get { return this; } }

        async Task<List<WrikeUserScheduleException>> IWrikeUserScheduleExceptionsClient.GetAsync(IWrikeDateFilter wrikeDateFilter, WrikeClientIdListParameter userIds)
        {
            var uriBuilder = new WrikeUriBuilder($"user_schedule_exclusions")
                .AddParameter("dateRange", wrikeDateFilter, new CustomDateTimeConverter("yyyy-MM-dd"))
                .AddParameter("userIds", userIds.Values.Select(r => r.Value).ToArray());

            var response = await SendRequest<WrikeUserScheduleException>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeUserScheduleException> IWrikeUserScheduleExceptionsClient.GetAsync(WrikeClientIdParameter id)
        {
            var uriBuilder = new WrikeUriBuilder($"user_schedule_exclusions/{id}");

            var response = await SendRequest<WrikeUserScheduleException>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

    }
}
