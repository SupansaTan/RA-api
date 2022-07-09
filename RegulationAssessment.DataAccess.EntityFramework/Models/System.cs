using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("System")]
    public partial class System
    {
        public System()
        {
            RelatedSystems = new HashSet<RelatedSystem>();
        }

        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "character varying")]
        public string Name { get; set; } = null!;

        [InverseProperty("System")]
        public virtual ICollection<RelatedSystem> RelatedSystems { get; set; }
    }
}
