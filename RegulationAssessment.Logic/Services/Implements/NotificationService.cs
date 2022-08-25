using RegulationAssessment.Common.Helper;
using RegulationAssessment.DataAccess.Dapper.Interface;
using RegulationAssessment.DataAccess.EntityFramework.UnitOfWork.Interface;
using RegulationAssessment.Logic.DomainModel;
using RegulationAssessment.Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.Services.Implements
{
    public class NotificationService : INotificationService
    {
        private readonly IEntityUnitOfWork _entityUnitOfWork;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly string QUERY_PATH;

        public NotificationService(
            IEntityUnitOfWork entityUnitOfWork,
            IDapperUnitOfWork dapperUnitOfWork
            )
        {
            QUERY_PATH = this.GetType().Name.Split("Service")[0] + "/";
            _entityUnitOfWork = entityUnitOfWork;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        public async Task<List<NotificationDto>> GetNotificationByEmpId(Guid empId)
        {
            var employeeInfo = await _entityUnitOfWork.NotificationRepository.GetSingleAsync(x => x.EmpId == empId);
            if (employeeInfo == null)
            {
                throw new ArgumentException("Employee does not exist.");
            }
            else
            {
                var query = QueryService.GetCommand(QUERY_PATH + "getNotificationByEmpId",
                            new ParamCommand { Key = "_employeeId", Value = empId.ToString() }
                        );
                return (await _dapperUnitOfWork.RARepository.QueryAsync<NotificationDto>(query)).Skip(0).ToList();
            }
        }
    }
}
