﻿using RegulationAssessment.Common.Helper;
using RegulationAssessment.DataAccess.Dapper.Interface;
using RegulationAssessment.DataAccess.EntityFramework.Models;
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
    internal class ResponsibilityService : IResponsibilityService
    {
        private readonly IEntityUnitOfWork _entityUnitOfWork;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly string QUERY_PATH;

        public ResponsibilityService(
            IEntityUnitOfWork entityUnitOfWork,
            IDapperUnitOfWork dapperUnitOfWork
            )
        {
            QUERY_PATH = this.GetType().Name.Split("Service")[0] + "/";
            _entityUnitOfWork = entityUnitOfWork;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        public List<ResponsibilityDto> GetResponsibilityList()
        {
            return _entityUnitOfWork.ResponsibilityRepository.GetAll()
                                                    .Select(x => new ResponsibilityDto()
                                                    {
                                                        Id = x.Id,
                                                        EmpId = (Guid)x.EmpId,
                                                        Cost = x.Cost,
                                                        DueDate = x.DueDate,
                                                        TaskKeyActId = x.TaskKeyActId,
                                                        Status = x.Status
                                                    }).ToList();
        }

        public async Task<ResponsibilityDto> GetResponsibilityById(Guid id) 
        {
            var data = _entityUnitOfWork.ResponsibilityRepository.GetSingle(x => x.Id == id);
            var resp = new ResponsibilityDto()
            {
                Id = data.Id,
                EmpId = (Guid)data.EmpId,
                Cost = data.Cost,
                DueDate = data.DueDate,
                TaskKeyActId = data.TaskKeyActId,
                Status = data.Status,
            };
            return resp;
        }

        public async Task<Responsibility> AddResponsibility(Responsibility resp)
        {
            _entityUnitOfWork.ResponsibilityRepository.Add(resp);
            await _entityUnitOfWork.SaveAsync();
            return resp;
        }

        public async Task<ResponsibilityListDto> GetTrackingDataByLocationId(Guid locationId)
        {
            var location = _entityUnitOfWork.LocationRepository.GetSingle(x => x.Id == locationId);
            if (location == null)
            {
                throw new ArgumentException("Location does not exist.");
            }
            else
            {
                var query = QueryService.GetCommand(QUERY_PATH + "GetTrackingData",
                            new ParamCommand { Key = "_locationId", Value = locationId.ToString() }
                        );
                var data = (await _dapperUnitOfWork.RARepository.QueryAsync<ResponsibilityDetailDto>(query)).ToList();
                var DoneTask = data.Where(x => x.Status == true).Select(x =>
                   new ResponsibilityDetailDto()
                   {
                       TaskId = x.TaskId,
                       TaskTitle = x.TaskTitle,
                       DueDate = x.DueDate,
                       Status = x.Status,
                       EmployeeName = x.EmployeeName,
                       DatetimeStatus = x.DatetimeStatus,
                   }
                   ).ToList();
                var InProgessTask = data.Where(x => x.Status == false).Select(x =>
                   new ResponsibilityDetailDto()
                   {
                       TaskId = x.TaskId,
                       TaskTitle = x.TaskTitle,
                       DueDate = x.DueDate,
                       Status = x.Status,
                       EmployeeName = x.EmployeeName,
                       DatetimeStatus = x.DatetimeStatus,
                   }
                   ).ToList();
                var result = new ResponsibilityListDto()
                {
                    LocationName = location.Name,
                    DoneTask = DoneTask,
                    InProgressTask = InProgessTask,
                };
                return result;
            }
        }
    }
}
