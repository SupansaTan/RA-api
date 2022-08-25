using RegulationAssessment.Logic.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.Services.Interfaces
{
    public interface INotificationService
    {
        Task<List<NotificationDto>> GetNotificationByEmpId(Guid empId);
        Task<List<NotificationDateDto>> GetNotificationDateByEmpId(Guid empId);
    }
}
