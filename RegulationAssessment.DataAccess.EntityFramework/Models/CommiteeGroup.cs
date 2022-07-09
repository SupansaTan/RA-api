using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("CommiteeGroup")]
    public partial class CommiteeGroup
    {
        public CommiteeGroup()
        {
            BusinessLines = new HashSet<BusinessLine>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; } = null!;

        [InverseProperty("CommiteeGroup")]
        public virtual ICollection<BusinessLine> BusinessLines { get; set; }
    }
}
