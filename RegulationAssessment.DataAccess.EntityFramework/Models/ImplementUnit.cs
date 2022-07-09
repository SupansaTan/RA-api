using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("ImplementUnit")]
    public partial class ImplementUnit
    {
        public ImplementUnit()
        {
            Locations = new HashSet<Location>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; } = null!;
        public Guid BusinessLineId { get; set; }

        [ForeignKey("BusinessLineId")]
        [InverseProperty("ImplementUnits")]
        public virtual BusinessLine BusinessLine { get; set; } = null!;
        [InverseProperty("ImplementUnit")]
        public virtual ICollection<Location> Locations { get; set; }
    }
}
