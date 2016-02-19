using Nop.Core.Configuration;

namespace Nop.Plugin.RestService
{
    public class RestServiceSettings : ISettings
    {
        public string ApiToken { get; set; }
    }
}