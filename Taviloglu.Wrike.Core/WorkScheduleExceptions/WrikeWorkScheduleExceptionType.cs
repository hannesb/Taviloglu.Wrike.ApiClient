namespace Taviloglu.Wrike.Core.WorkScheduleExceptions
{
    public enum WrikeWorkScheduleExceptionType
    {
        /// <summary>
        /// Additional working days, i.e. during weekends
        /// </summary>
        AdditionalWorkDays,
        /// <summary>
        /// Non-working days because of public holidays
        /// </summary>
        PublicHolidays,
        /// <summary>
        /// Non-working days because of some company or private event
        /// </summary>
        OtherEvent
    }
}
