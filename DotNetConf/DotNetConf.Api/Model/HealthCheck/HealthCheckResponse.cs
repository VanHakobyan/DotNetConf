using System;
using System.Collections.Generic;

namespace DotNetConf.Api.Model.HealthCheck
{
    /// <summary>
    /// HealthCheck Response
    /// </summary>
    public class HealthCheckResponse
    {
        public string Status { get; set; }
        public IEnumerable<HealthCheck> Checks { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
