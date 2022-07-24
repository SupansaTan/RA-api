using System;

namespace RegulationAssessment.Common
{
    public static class ConnectionResolver
    {
        public static bool IsProduction { get; set; }
        public static string RAConnection { get; set; }
        public static string FrontendUrl { get; set; }
    }
}
