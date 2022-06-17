using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    [Table("Task")]
    public partial class Tasks
    {
        [Key]
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        [StringLength(255)]
        public string Notation { get; set; }
        public int Process { get; set; }
        public bool Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CompleteDate { get; set; }
    }
}