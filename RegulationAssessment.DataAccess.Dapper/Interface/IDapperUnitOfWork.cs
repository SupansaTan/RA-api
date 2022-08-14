using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.DataAccess.Dapper.Interface
{
    public interface IDapperUnitOfWork
    {
        IDapperRepository RARepository { get; set; }
    }
}
