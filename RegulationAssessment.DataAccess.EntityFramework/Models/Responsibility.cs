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
        public Guid? EmpId { get; set; }
        public int Cost { get; set; }
        public DateTime DueDate { get; set; }
        public Guid TaskKeyActId { get; set; }
        public bool Status { get; set; }

        [ForeignKey("EmpId")]
        [InverseProperty("Responsibilities")]
        public virtual Employee? Emp { get; set; }
        [ForeignKey("TaskKeyActId")]
        [InverseProperty("Responsibilities")]
        public virtual TaskKeyAct TaskKeyAct { get; set; } = null!;
        [InverseProperty("Resp")]
        public virtual ICollection<Logging> Loggings { get; set; }
    }
}
