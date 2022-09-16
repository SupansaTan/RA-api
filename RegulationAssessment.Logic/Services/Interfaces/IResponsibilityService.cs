using RegulationAssessment.DataAccess.EntityFramework.Models;
using RegulationAssessment.Logic.DomainModel;

namespace RegulationAssessment.Logic.Services.Interfaces
{
    public interface IResponsibilityService
    {
        Task<ResponsibilityListDto> GetTrackingDataByLocationId(Guid locationId);
    }
}
