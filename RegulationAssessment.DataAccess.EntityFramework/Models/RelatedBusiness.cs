using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("RelatedBusiness")]
    public partial class RelatedBusiness
    {
        [Key]
        public Guid Id { get; set; }
        public Guid LawId { get; set; }
        public Guid BusinessId { get; set; }

        [ForeignKey("BusinessId")]
        [InverseProperty("RelatedBusinesses")]
        public virtual Business Business { get; set; } = null!;
        [ForeignKey("LawId")]
        [InverseProperty("RelatedBusinesses")]
        public virtual Law Law { get; set; } = null!;
    }
}
