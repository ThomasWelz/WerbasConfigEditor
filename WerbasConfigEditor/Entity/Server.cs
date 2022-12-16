namespace WerbasConfigEditor.Entity
{
    /// <summary>
    /// Structure of a Server XML Node
    /// </summary>
    public class Server
    {
        /// <summary>
        /// Shows the Path to the Server
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The ConnectionString to Connect to the Server
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
