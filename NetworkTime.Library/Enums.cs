namespace NetworkTime
{
    public enum LeapIndicator
    {
        /// <summary>
        /// No warning
        /// </summary>
        NoWarning = 0,
        
        /// <summary>
        /// Last Minute has 61 seconds
        /// </summary>
        LastMinute61 = 1,

        /// <summary>
        /// Last Minute has 59 seconds
        /// </summary>
        LastMinute59 = 2,

        /// <summary>
        /// Alarm condition (clock not synchronized)
        /// </summary>
        Alarm = 3,
    }

    /// <summary>
    /// Mode field values
    /// </summary>
    public enum Mode
    {
        /// <summary>
        /// 0, 6, 7 - Reserved
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Symmetric active
        /// </summary>
        SymmetricActive = 1,

        /// <summary>
        /// Symmetric pasive
        /// </summary>
        SymmetricPassive = 2, 

        /// <summary>
        /// Client
        /// </summary>
        Client = 3,

        /// <summary>
        /// Server 
        /// </summary>
        Server = 4,

        /// <summary>
        ///  Broadcast
        /// </summary>
        Broadcast = 5,
    }

    /// <summary>
    /// Stratum field values
    /// </summary>
    public enum Stratum
    {
        /// <summary>
        /// 0 - unspecified or unavailable
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// 1 - primary reference (e.g. radio-clock)
        /// </summary>
        PrimaryReference = 1,

        /// <summary>
        /// 2-15 - secondary reference (via NTP or SNTP)
        /// </summary>
        SecondaryReference = 2,

        /// <summary>
        /// 16-255 - reserved
        /// </summary>
        Reserved = 16,
    }
}
