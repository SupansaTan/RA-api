using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Keyless]
    [Table("Duty")]
    public partial class Duty
    {
        public Guid Id { get; set; }
        public Guid EmpId { get; set; }
        public Guid RoleId { get; set; }
        public Guid? LocationId { get; set; }
    }
}
