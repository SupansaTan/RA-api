using RegulationAssessment.Logic.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskResult = RegulationAssessment.DataAccess.EntityFramework.Models.Task;

namespace RegulationAssessment.Logic.Services.Interfaces
{
    public interface ITaskService
    {
        List<TaskDto> GetRelevantTaskList();
        List<TaskDto> GetApproveRelevantTaskList();
        List<TaskDto> GetConsistanceTaskList();
        List<TaskDto> GetApproveConsistanceTaskList();
        List<TaskDto> GetResponseTaskList();
        List<TaskDto> GetDoneTaskList();
        Task<List<TaskItemDto>> GetTaskListByEmpId(Guid empId);
        Task<List<TaskListSortByProcessDto>> GetTaskListByLocationId(Guid locationId, string searchTerms);
        Task<bool> UpdateTaskRelevant(TaskAssessmentDto model);
        Task<bool> UpdateTaskApproveRelevant(TaskAssessmentDto model);
        Task<bool> UpdateTaskConsistance(TaskAssessmentDto model);
        Task<bool> UpdateTaskApproveConsistance(TaskAssessmentDto model);
        Task<bool> UpdateTaskResponse(TaskAssessmentDto model);
        Task<bool> UpdateTaskApproveResponse(TaskAssessmentDto model);
        Task<TaskDataDto> GetTaskById(Guid taskId);
        Task<TaskInfoDto> GetTaskDetail(Guid taskId);
    }
}
