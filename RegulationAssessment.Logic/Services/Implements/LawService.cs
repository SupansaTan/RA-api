using Microsoft.EntityFrameworkCore;
using RegulationAssessment.DataAccess.Dapper.Interface;
using RegulationAssessment.DataAccess.EntityFramework.Models;
using RegulationAssessment.DataAccess.EntityFramework.UnitOfWork.Interface;
using RegulationAssessment.Logic.DomainModel;
using RegulationAssessment.Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.Services.Implements
{
    public class LawService : ILawService
    {
        private readonly IEntityUnitOfWork _entityUnitOfWork;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly string QUERY_PATH;

        public LawService(
            IEntityUnitOfWork entityUnitOfWork,
            IDapperUnitOfWork dapperUnitOfWork
            )
        {
            QUERY_PATH = this.GetType().Name.Split("Service")[0] + "/";
            _entityUnitOfWork = entityUnitOfWork;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        public LawListDto GetLawList(LawListFilterDto model)
        {
            var lawList = _entityUnitOfWork.LawRepository.GetAll();

            // search by keyword
            if (!string.IsNullOrEmpty(model.Keyword))
            {
                var keyword = model.Keyword.Trim().ToLower();
                lawList = lawList.Where(x => x.Title.ToLower().Contains(keyword));
            }

            // filter by catagory
            if (!string.IsNullOrEmpty(model.LegislationType))
            {
                var keyword = model.LegislationType.Trim().ToLower();
                lawList = lawList.Where(x => x.LegislationType.ToLower().Contains(keyword));
            }

            // filter by act type
            if (!string.IsNullOrEmpty(model.ActType))
            {
                var keyword = model.ActType.Trim().ToLower();
                lawList = lawList.Where(x => x.ActType.ToLower().Contains(keyword));
            }

            // filter by legislation unit
            if (!string.IsNullOrEmpty(model.LegislationUnit))
            {
                var keyword = model.LegislationUnit.Trim().ToLower();
                lawList = lawList.Where(x => x.LegislationUnit.ToLower().Contains(keyword));
            }

            // filter by date
            if (model.IsFilterByAnnounceDate)
            {
                lawList = lawList.Where(x => x.AnnounceDate.Date == model.AnnounceDate.GetValueOrDefault().Date);
            }
            if (model.IsFilterByEnforceDate)
            {
                lawList = lawList.Where(x => x.EnforceDate == model.EnforceDate.GetValueOrDefault().Date);
            }
            if (model.IsFilterByCancelDate)
            {
                lawList = lawList.Where(x => x.CancelDate == model.CancelDate.GetValueOrDefault().Date);
            }

            var result = new LawListDto()
            {
                TotalLaw = lawList.Count(),
                LawList = lawList.OrderBy(x => x.Title).Select(x => new LawDto()
                {
                    LawId = x.Id,
                    Title = x.Title,
                    LegislationType = x.LegislationType
                }).ToList()
            };
            return result;
        }

        public async Task<LawDetailDto> GetLawbyId(Guid lawid)
        {
            var lawDetail = await _entityUnitOfWork.LawRepository.GetSingleAsync(x => x.Id == lawid);
            if (lawDetail == null)
            {
                throw new ArgumentException("Law does not exist.");
            }
            else
            {
                var systems = await _entityUnitOfWork.RelatedSystemRepository.GetAll(x => x.LawId == lawid)
                                                                  .Select(x => x.SystemId)
                                                                  .ToListAsync();
                List<string> systemList = new List<string>();
                foreach (var system in systems)
                {
                    var sys = await _entityUnitOfWork.SystemRepository.GetSingleAsync(x => x.Id == system);
                    systemList.Add(sys.Name);
                }

                return new LawDetailDto()
                {
                    Id = lawDetail.Id,
                    Title = lawDetail.Title,
                    AnnounceDate = lawDetail.AnnounceDate,
                    EnforceDate = lawDetail.EnforceDate,
                    CancelDate = lawDetail.CancelDate,
                    PdfUrl = lawDetail.PdfUrl,
                    Catagory = lawDetail.Catagory,
                    ActType = lawDetail.ActType,
                    LegislationType = lawDetail.LegislationType,
                    LegislationUnit = lawDetail.LegislationUnit,
                    SystemList = systemList
                };
            }
        }

        public async Task<LawDetailDto> GetLawDetailByTaskId(Guid taskId)
        {
            var task = await _entityUnitOfWork.TaskRepository.GetSingleAsync(x => x.Id == taskId, x => x.Location);
            if (task == null)
            {
                throw new ArgumentException("Task does not exist.");
            }
            else
            {
                var lawDetail = await _entityUnitOfWork.LawRepository.GetSingleAsync(x => x.Id == task.LawId);
                if (lawDetail == null)
                {
                    throw new ArgumentException("Law does not exist.");
                }
                else
                {
                    var systems = await _entityUnitOfWork.RelatedSystemRepository.GetAll(x => x.LawId == task.LawId)
                                                                      .Select(x => x.SystemId)
                                                                      .ToListAsync();
                    List<string> systemList = new List<string>();
                    foreach (var system in systems)
                    {
                        var sys = await _entityUnitOfWork.SystemRepository.GetSingleAsync(x => x.Id == system);
                        systemList.Add(sys.Name);
                    }

                    return new LawDetailDto()
                    {
                        Id = task.Id,
                        Title = lawDetail.Title,
                        LocationName = task.Location.Name,
                        AnnounceDate = lawDetail.AnnounceDate,
                        EnforceDate = lawDetail.EnforceDate,
                        CancelDate = lawDetail.CancelDate,
                        PdfUrl = lawDetail.PdfUrl,
                        Catagory = lawDetail.Catagory,
                        ActType = lawDetail.ActType,
                        LegislationType = lawDetail.LegislationType,
                        LegislationUnit = lawDetail.LegislationUnit,
                        SystemList = systemList
                    };
                }
            }
        }

        public async Task<Law> AddLaw(Law law)
        {
            _entityUnitOfWork.LawRepository.Add(law);
            await _entityUnitOfWork.SaveAsync();
            return law;
        }

        public List<NameDataDto> GetActTypeName()
        {
            var data = _entityUnitOfWork.LawRepository.GetAll()
                .OrderBy(x => x.ActType)
                .Select(x => new NameDataDto()
                {
                    name = x.ActType
                }).Distinct().ToList();
            return data;
        }

        public List<NameDataDto> GetLegislationUnitName()
        {
            var data = _entityUnitOfWork.LawRepository.GetAll()
                .OrderBy(x => x.LegislationUnit)
                .Select(x => new NameDataDto()
                {
                    name = x.LegislationUnit
                }).Distinct().ToList();
            return data;
        }

    }
}
