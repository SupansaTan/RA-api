using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("Law")]
    public partial class Law
    {
        public Law()
        {
            KeyActions = new HashSet<KeyAction>();
            RelatedBusinesses = new HashSet<RelatedBusiness>();
            RelatedSystems = new HashSet<RelatedSystem>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(500)]
        public string Title { get; set; } = null!;
        [Column(TypeName = "timestamp without time zone")]
        public DateTime AnnounceDate { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? EnforceDate { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? CancelDate { get; set; }
        [StringLength(500)]
        public string? PdfUrl { get; set; }
        [StringLength(255)]
        public string Catagory { get; set; } = null!;
        [StringLength(255)]
        public string ActType { get; set; } = null!;
        [StringLength(255)]
        public string LegislationType { get; set; } = null!;
        [Column(TypeName = "character varying")]
        public string LegislationUnit { get; set; } = null!;

        [InverseProperty("Law")]
        public virtual ICollection<KeyAction> KeyActions { get; set; }
        [InverseProperty("Law")]
        public virtual ICollection<RelatedBusiness> RelatedBusinesses { get; set; }
        [InverseProperty("Law")]
        public virtual ICollection<RelatedSystem> RelatedSystems { get; set; }
    }
}
