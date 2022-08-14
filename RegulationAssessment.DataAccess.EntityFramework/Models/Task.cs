using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("Task")]
    public partial class Task
    {
        public Task()
        {
            Notifications = new HashSet<Notification>();
            TaskKeyActs = new HashSet<TaskKeyAct>();
        }

        [Key]
        public Guid Id { get; set; }
        public int Process { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime DueDate { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? CompleteDate { get; set; }
        public Guid LocationId { get; set; }
        public Guid LawId { get; set; }

        [ForeignKey("LawId")]
        [InverseProperty("Tasks")]
        public virtual Law Law { get; set; } = null!;
        [ForeignKey("LocationId")]
        [InverseProperty("Tasks")]
        public virtual Location Location { get; set; } = null!;
        [InverseProperty("Task")]
        public virtual ICollection<Notification> Notifications { get; set; }
        [InverseProperty("Task")]
        public virtual ICollection<TaskKeyAct> TaskKeyActs { get; set; }
    }
}
