using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("TaskKeyAct")]
    public partial class TaskKeyAct
    {
        public TaskKeyAct()
        {
            Loggings = new HashSet<Logging>();
            Responsibilities = new HashSet<Responsibility>();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public Guid KeyActId { get; set; }

        [ForeignKey("KeyActId")]
        [InverseProperty("TaskKeyActs")]
        public virtual KeyAction KeyAct { get; set; } = null!;
        [ForeignKey("TaskId")]
        [InverseProperty("TaskKeyActs")]
        public virtual Task Task { get; set; } = null!;
        [InverseProperty("TaskKeyAct")]
        public virtual ICollection<Logging> Loggings { get; set; }
        [InverseProperty("TaskKeyAct")]
        public virtual ICollection<Responsibility> Responsibilities { get; set; }
    }
}
