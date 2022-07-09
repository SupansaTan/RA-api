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
            KeyActions = new HashSet<KeyAction>();
            Loggings = new HashSet<Logging>();
            Notifications = new HashSet<Notification>();
        }

        [Key]
        public Guid Id { get; set; }
        public int Process { get; set; }
        public bool? Status { get; set; }
        [Column(TypeName = "character varying")]
        public string? Notation { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime DueDate { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime CompleteDate { get; set; }
        public Guid LocationId { get; set; }

        [ForeignKey("LocationId")]
        [InverseProperty("Tasks")]
        public virtual Location Location { get; set; } = null!;
        [InverseProperty("Task")]
        public virtual ICollection<KeyAction> KeyActions { get; set; }
        [InverseProperty("Task")]
        public virtual ICollection<Logging> Loggings { get; set; }
        [InverseProperty("Task")]
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
