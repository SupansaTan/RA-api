using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("RelatedSystem")]
    public partial class RelatedSystem
    {
        [Key]
        public Guid Id { get; set; }
        public Guid LawId { get; set; }
        public Guid SystemId { get; set; }

        [ForeignKey("LawId")]
        [InverseProperty("RelatedSystems")]
        public virtual Law Law { get; set; } = null!;
        [ForeignKey("SystemId")]
        [InverseProperty("RelatedSystems")]
        public virtual System System { get; set; } = null!;
    }
}
