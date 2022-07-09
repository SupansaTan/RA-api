using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("Responsibility")]
    public partial class Responsibility
    {
        public Responsibility()
        {
            Loggings = new HashSet<Logging>();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid? EmployeeId { get; set; }
        public int Cost { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime DueDate { get; set; }
        public Guid KeyActId { get; set; }
        public bool Status { get; set; }

        [ForeignKey("KeyActId")]
        [InverseProperty("Responsibilities")]
        public virtual KeyAction KeyAct { get; set; } = null!;
        [InverseProperty("KeyActNavigation")]
        public virtual ICollection<Logging> Loggings { get; set; }
    }
}
