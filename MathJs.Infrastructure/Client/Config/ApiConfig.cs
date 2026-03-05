namespace MathJs.Infrastructure.Client.Config
{
    public static class ApiConfig
    {
        public readonly static string BaseUrl = "http://api.mathjs.org";
        public readonly static string Endpoint = "/v4";
        public readonly static Dictionary<string, string> Headers = new Dictionary<string, string>
        {
            {"Content-Type", "application/json" },
            {"User-Agent", "Learning Automation" }
        };
    }
}
