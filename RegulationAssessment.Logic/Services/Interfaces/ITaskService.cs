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
        Task<List<TaskListSortByProcessDto>> GetTaskListByLocationId(Guid locationId);
        Task<bool> UpdateTask(TaskResult task);
    }
}
