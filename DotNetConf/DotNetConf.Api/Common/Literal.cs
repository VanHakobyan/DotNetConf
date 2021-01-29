#pragma warning disable 1591
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
        public const string JohnSmith = "John Smith";
        public const string ControllerRoute = "api/[controller]";

        public const string SqlLog = nameof(SqlLog);
        public const string ConnectionStrings = nameof(ConnectionStrings);
        public const string HealthChecksUI = nameof(HealthChecksUI);
        public const string Master = nameof(Master);
        public const string ReadOnly = nameof(ReadOnly);

        public const string NLogConfig = "nlog.config";
        public const string ApplicationStarting = "Application starting";
        public const string ApplicationException = "Stopped program because of exception";
        public const string EnableSqlQueryLog = nameof(EnableSqlQueryLog);
        public const string GetById = nameof(GetById);
    }
}
