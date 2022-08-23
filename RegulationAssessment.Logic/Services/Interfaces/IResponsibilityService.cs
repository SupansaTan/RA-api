using RegulationAssessment.DataAccess.EntityFramework.Models;
using RegulationAssessment.Logic.DomainModel;

namespace RegulationAssessment.Logic.Services.Interfaces
{
    public interface IResponsibilityService
    {
        List<ResponsibilityDto> GetResponsibilityList();
        Task<ResponsibilityDto> GetResponsibilityById(Guid id);
        Task<Responsibility> AddResponsibility(Responsibility resp);
    }
}
