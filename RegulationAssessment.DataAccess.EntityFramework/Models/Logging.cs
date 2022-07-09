using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("Logging")]
    public partial class Logging
    {
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime CreateDate { get; set; }
        [StringLength(255)]
        public string? Notation { get; set; }
        public int Process { get; set; }
        public bool Status { get; set; }
        public Guid TaskId { get; set; }
        public Guid KeyActId { get; set; }
        public Guid RespId { get; set; }
        public Guid EmpId { get; set; }

        [ForeignKey("EmpId")]
        [InverseProperty("Loggings")]
        public virtual Employee Emp { get; set; } = null!;
        [ForeignKey("KeyActId")]
        [InverseProperty("Loggings")]
        public virtual KeyAction KeyAct { get; set; } = null!;
        [ForeignKey("KeyActId")]
        [InverseProperty("Loggings")]
        public virtual Responsibility KeyActNavigation { get; set; } = null!;
        [ForeignKey("TaskId")]
        [InverseProperty("Loggings")]
        public virtual Task Task { get; set; } = null!;
    }
}
