using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("BusinessLine")]
    public partial class BusinessLine
    {
        public BusinessLine()
        {
            ImplementUnits = new HashSet<ImplementUnit>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; } = null!;
        public Guid CommiteeGroupId { get; set; }

        [ForeignKey("CommiteeGroupId")]
        [InverseProperty("BusinessLines")]
        public virtual CommiteeGroup CommiteeGroup { get; set; } = null!;
        [InverseProperty("BusinessLine")]
        public virtual ICollection<ImplementUnit> ImplementUnits { get; set; }
    }
}
