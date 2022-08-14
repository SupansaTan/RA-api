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
            if (!string.IsNullOrEmpty(model.Catagory))
            {
                var keyword = model.Catagory.Trim().ToLower();
                lawList = lawList.Where(x => x.Catagory.ToLower().Contains(keyword));
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
                lawList = lawList.Where(x => x.EnforceDate.GetValueOrDefault().Date == model.EnforceDate.GetValueOrDefault().Date);
            }
            if (model.IsFilterByCancelDate)
            {
                lawList = lawList.Where(x => x.CancelDate.GetValueOrDefault().Date == model.CancelDate.GetValueOrDefault().Date);
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
    }
}
