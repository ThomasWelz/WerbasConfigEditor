namespace WerbasConfigEditor.Entity
{
    /// <summary>
    /// Structure of a Client XML Node
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Shows the Path to the Client
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Is the Client behind the Path a TS Client or not? -> Default = false
        /// </summary>
        public bool TSClient { get; set; } = false;
    }
}
