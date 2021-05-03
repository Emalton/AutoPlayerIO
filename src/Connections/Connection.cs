using System.Threading.Tasks;

namespace AutoPlayerIO
{
    public class Connection
    {
        /// <summary>
        /// The name of the connection.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The description of the connection.
        /// </summary>
        public string Description { get; }


        internal Connection(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public async Task<string> GetSharedSecretAsync()
        {
            var connectionDetails = await _client.Request($"/my/connections/edit/{this.NavigationId}/{connectionName}/{this.XSRFToken}")
                .LoadDocumentAsync(cancellationToken)
                .ConfigureAwait(false);

            return connectionDetails.GetElementById("Basic256AuthSharedSecret").GetAttribute("value");
        }
    }
}
