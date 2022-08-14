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
            TaskKeyActs = new HashSet<TaskKeyAct>();
        }

        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "character varying")]
        public string KeyReq { get; set; } = null!;
        [Column(TypeName = "character varying")]
        public string? Standard { get; set; }
        [Column(TypeName = "character varying")]
        public string? Practice { get; set; }
        [Column(TypeName = "character varying")]
        public string? Frequency { get; set; }
        public int Order { get; set; }
        public Guid LawId { get; set; }

        [ForeignKey("LawId")]
        [InverseProperty("KeyActions")]
        public virtual Law Law { get; set; } = null!;
        [InverseProperty("KeyAct")]
        public virtual ICollection<TaskKeyAct> TaskKeyActs { get; set; }
    }
}
