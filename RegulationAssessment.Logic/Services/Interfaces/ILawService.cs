using RegulationAssessment.DataAccess.EntityFramework.Models;
using RegulationAssessment.Logic.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.Services.Interfaces
{
    public interface ILawService
    {
        LawListDto GetLawList(LawListFilterDto model);
        Task<Law> AddLaw(Law law);
        LawDetailDto GetLawbyId(Guid lawid);
        Task<LawDetailDto> GetLawDetailByTaskId(Guid taskId);
    }
}
