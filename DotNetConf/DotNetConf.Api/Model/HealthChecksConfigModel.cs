namespace DotNetConf.Api.Model
{
    public class HealthChecksConfigModel
    {
        public HealthCheck[] HealthChecks { get; set; }
        public int EvaluationTimeOnSeconds { get; set; }
        public int MinimumSecondsBetweenFailureNotifications { get; set; }
    }
    public class HealthCheck
    {
        public string Name { get; set; }
        public string Uri { get; set; }
    }
}
