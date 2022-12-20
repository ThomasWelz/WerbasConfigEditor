namespace Data.Entity
{
    /// <summary>
    /// Client Entity
    /// </summary>
    public class Client
    {
        /// <summary>
        /// The Path of the Client
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Is the Client a TS Type?
        /// </summary>
        public bool IsTsClient { get; set; }
    }
}
