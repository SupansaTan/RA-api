﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.DomainModel
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public string Notation { get; set; }
        public int Process { get; set; }
        public bool Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CompleteDate { get; set; }
    }
}