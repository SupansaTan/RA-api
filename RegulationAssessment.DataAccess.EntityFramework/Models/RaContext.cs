using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    public partial class RaContext : DbContext
    {
        public RaContext()
        {
        }

        public RaContext(DbContextOptions<RaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tasks> Task { get; set; }
    }
}
