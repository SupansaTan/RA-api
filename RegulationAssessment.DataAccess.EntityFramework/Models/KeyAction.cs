using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("KeyAction")]
    public partial class KeyAction
    {
        public KeyAction()
        {
            Loggings = new HashSet<Logging>();
            Responsibilities = new HashSet<Responsibility>();
        }

        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "character varying")]
        public string KeyReq { get; set; } = null!;
        [Column(TypeName = "character varying")]
        public string? Standard { get; set; }
        [Column(TypeName = "character varying")]
        public string? Practice { get; set; }
        public int Frequency { get; set; }
        public int Order { get; set; }
        public Guid LawId { get; set; }
        public Guid TaskId { get; set; }

        [ForeignKey("LawId")]
        [InverseProperty("KeyActions")]
        public virtual Law Law { get; set; } = null!;
        [ForeignKey("TaskId")]
        [InverseProperty("KeyActions")]
        public virtual Task Task { get; set; } = null!;
        [InverseProperty("KeyAct")]
        public virtual ICollection<Logging> Loggings { get; set; }
        [InverseProperty("KeyAct")]
        public virtual ICollection<Responsibility> Responsibilities { get; set; }
    }
}
