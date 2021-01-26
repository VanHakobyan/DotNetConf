namespace DotNetConf.Api.Common
{
    /// <summary>
    /// Core literal
    /// </summary>
    public static class Literal
    {
        public const string SwaggerVersion = "v1";
        public const string SwaggerTitle = "DotNetConf.Api";
        public const string SwaggerUrl = "/swagger/v1/swagger.json";
        public const string SwaggerJwtDescription = "Desctiption";

        public const string ProductionHost = @"https://vanikhakobyan.medium.com";
        public const string Bearer = nameof(Bearer);
        public const string Authorization = nameof(Authorization);
        public const string ContentType = "application/json";

        public const string Health = "/health";
    }
}
