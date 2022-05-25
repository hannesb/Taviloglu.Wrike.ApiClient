using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Json;
using Taviloglu.Wrike.Core.WorkScheduleExceptions;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeWorkScheduleExceptionsClient
    {
        public IWrikeWorkScheduleExceptionsClient WorkScheduleExceptions { get { return this; } }

        async Task<List<WrikeWorkScheduleException>> IWrikeWorkScheduleExceptionsClient.GetAsync(WrikeClientIdParameter id, IWrikeDateFilter wrikeDateFilter)
        {
            var uriBuilder = new WrikeUriBuilder($"workschedules/{id}/workschedule_exclusions")
                .AddParameter("dateRange", wrikeDateFilter, new CustomDateTimeConverter("yyyy-MM-dd"));

            var response = await SendRequest<WrikeWorkScheduleException>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeWorkScheduleException> IWrikeWorkScheduleExceptionsClient.GetAsync(WrikeClientIdParameter id)
        {
            var uriBuilder = new WrikeUriBuilder($"workschedule_exclusions/{id}");

            var response = await SendRequest<WrikeWorkScheduleException>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

    }
}
