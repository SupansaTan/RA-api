using System;

namespace RegulationAssessment.Common
{
    public static class ConnectionResolver
    {
        public static bool IsProduction { get; set; }
        public static string RaConnection { get; set; }
        public static string FrontendUrl { get; set; }
    }
}
