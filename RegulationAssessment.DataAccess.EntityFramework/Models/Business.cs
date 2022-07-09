using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("Business")]
    public partial class Business
    {
        public Business()
        {
            Locations = new HashSet<Location>();
            RelatedBusinesses = new HashSet<RelatedBusiness>();
        }

        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "character varying")]
        public string Type { get; set; } = null!;

        [InverseProperty("Business")]
        public virtual ICollection<Location> Locations { get; set; }
        [InverseProperty("Business")]
        public virtual ICollection<RelatedBusiness> RelatedBusinesses { get; set; }
    }
}
