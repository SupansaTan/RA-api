using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("Role")]
    public partial class Role
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; } = null!;
    }
}
