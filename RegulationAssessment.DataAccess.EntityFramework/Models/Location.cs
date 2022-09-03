using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("Location")]
    public partial class Location
    {
        public Location()
        {
            Duties = new HashSet<Duty>();
            Tasks = new HashSet<Task>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public Guid ImplementUnitId { get; set; }
        public Guid BusinessId { get; set; }

        [ForeignKey("BusinessId")]
        [InverseProperty("Locations")]
        public virtual Business Business { get; set; }
        [ForeignKey("ImplementUnitId")]
        [InverseProperty("Locations")]
        public virtual ImplementUnit ImplementUnit { get; set; }
        [InverseProperty("Location")]
        public virtual ICollection<Duty> Duties { get; set; }
        [InverseProperty("Location")]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
