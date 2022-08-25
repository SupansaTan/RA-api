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
    public class LocationService : ILocationService
    {
        private readonly IEntityUnitOfWork _entityUnitOfWork;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly string QUERY_PATH;

        public LocationService(
            IEntityUnitOfWork entityUnitOfWork,
            IDapperUnitOfWork dapperUnitOfWork
            )
        {
            QUERY_PATH = this.GetType().Name.Split("Service")[0] + "/";
            _entityUnitOfWork = entityUnitOfWork;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        public async Task<List<LocationListDto>> GetLocationListByEmpId(Guid employeeId)
        {
            var employee = await _entityUnitOfWork.EmployeeRepository.GetSingleAsync(x => x.Id == employeeId);
            if (employee == null)
            {
                throw new ArgumentException("Employee does not exist.");
            }
            else
            {
                var query = QueryService.GetCommand(QUERY_PATH + "getLocationListByEmpId",
                            new ParamCommand { Key = "_employeeId", Value = employeeId.ToString() }
                        );
                return (await _dapperUnitOfWork.RARepository.QueryAsync<LocationListDto>(query)).ToList();
            }
        }
    }
}
