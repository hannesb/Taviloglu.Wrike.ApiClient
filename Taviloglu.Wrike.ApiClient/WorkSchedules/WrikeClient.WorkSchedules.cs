using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.WorkSchedules;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeWorkSchedulesClient
    {
        public IWrikeWorkSchedulesClient WorkSchedules { get { return this; } }

        async Task<List<WrikeWorkSchedule>> IWrikeWorkSchedulesClient.GetAsync(List<string> optionalFields)
        {
            if (optionalFields != null && optionalFields.Count > 0 && optionalFields.Except(WrikeWorkSchedule.OptionalFields.List).Any()) {
                throw new ArgumentOutOfRangeException(nameof(optionalFields), "Use only values in WrikeWorkSchedule.OptionalFields");
            }

            var uriBuilder = new WrikeUriBuilder("workschedules")
                .AddParameter("fields", optionalFields);            

            var response = await SendRequest<WrikeWorkSchedule>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeWorkSchedule> IWrikeWorkSchedulesClient.GetAsync(WrikeClientIdParameter id, List<string> optionalFields)
        {
            if (optionalFields != null && optionalFields.Count > 0 && optionalFields.Except(WrikeWorkSchedule.OptionalFields.List).Any()) {
                throw new ArgumentOutOfRangeException(nameof(optionalFields), "Use only values in WrikeWorkSchedule.OptionalFields");
            }

            var uriBuilder = new WrikeUriBuilder($"workschedules/{id}")
                .AddParameter("fields", optionalFields);

            var response = await SendRequest<WrikeWorkSchedule>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

    }
}
