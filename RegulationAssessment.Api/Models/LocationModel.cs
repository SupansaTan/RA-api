﻿namespace RegulationAssessment.Api.Models
{
    public class LocationModel
    {

    }

    public class LocationListModel
    {
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public string BusinessType { get; set; }
    }
}
