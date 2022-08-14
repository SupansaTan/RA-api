using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("Employee")]
    public partial class Employee
    {
        public Employee()
        {
            Duties = new HashSet<Duty>();
            Loggings = new HashSet<Logging>();
            Notifications = new HashSet<Notification>();
            Responsibilities = new HashSet<Responsibility>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(255)]
        public string Ssn { get; set; } = null!;
        [StringLength(255)]
        public string FirstName { get; set; } = null!;
        [StringLength(255)]
        public string LastName { get; set; } = null!;
        [Column(TypeName = "timestamp without time zone")]
        public DateTime CreateAt { get; set; }
        [StringLength(255)]
        public string? Email { get; set; }
        [StringLength(255)]
        public string? Password { get; set; }
        public bool? DarkTheme { get; set; }
        public bool NotificationStatus { get; set; }
        public int AdvanceNotify { get; set; }

        [InverseProperty("Emp")]
        public virtual ICollection<Duty> Duties { get; set; }
        [InverseProperty("Emp")]
        public virtual ICollection<Logging> Loggings { get; set; }
        [InverseProperty("Emp")]
        public virtual ICollection<Notification> Notifications { get; set; }
        [InverseProperty("Emp")]
        public virtual ICollection<Responsibility> Responsibilities { get; set; }
    }
}
