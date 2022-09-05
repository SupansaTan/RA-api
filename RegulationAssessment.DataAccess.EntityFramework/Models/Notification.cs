using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("Notification")]
    public partial class Notification
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public Guid EmpId { get; set; }
        public DateTime NotifyDate { get; set; }
        public bool Read { get; set; }
        public int Process { get; set; }

        [ForeignKey("EmpId")]
        [InverseProperty("Notifications")]
        public virtual Employee Emp { get; set; } = null!;
        [ForeignKey("TaskId")]
        [InverseProperty("Notifications")]
        public virtual Task Task { get; set; } = null!;
    }
}
