using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("Duty")]
    public partial class Duty
    {
        [Key]
        public Guid Id { get; set; }
        public Guid EmpId { get; set; }
        public Guid RoleId { get; set; }
        public Guid? LocationId { get; set; }

        [ForeignKey("EmpId")]
        [InverseProperty("Duties")]
        public virtual Employee Emp { get; set; } = null!;
        [ForeignKey("LocationId")]
        [InverseProperty("Duties")]
        public virtual Location? Location { get; set; }
        [ForeignKey("RoleId")]
        [InverseProperty("Duties")]
        public virtual Role Role { get; set; } = null!;
    }
}
