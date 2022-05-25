namespace Taviloglu.Wrike.Core.WorkSchedules
{
    public enum WrikeWorkScheduleType
    {
        /// <summary>
        /// Default schedule is created along with account and used for all users not explicitly assigned to custom schedule
        /// </summary>
        Default,
        /// <summary>
        /// Custom schedule is used when some account users have schedules which is different to default
        /// </summary>
        Custom
    }
}
