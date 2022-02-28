using LecturerManagement.Core.Repositories.AccountRepo;
using LecturerManagement.Core.Repositories.AdvancedLearningRepo;
using LecturerManagement.Core.Repositories.ClassRepo;
using LecturerManagement.Core.Repositories.DynamicClassFactorRepo;
using LecturerManagement.Core.Repositories.GraduationThesisRepo;
using LecturerManagement.Core.Repositories.LecturerRepo;
using LecturerManagement.Core.Repositories.LecturerScientificResearchRepo;
using LecturerManagement.Core.Repositories.MachineRoomRepo;
using LecturerManagement.Core.Repositories.PositionRepo;
using LecturerManagement.Core.Repositories.ScientificResearchGuideRepo;
using LecturerManagement.Core.Repositories.StandardTimeRepo;
using LecturerManagement.Core.Repositories.SubjectDepartmentRepo;
using LecturerManagement.Core.Repositories.SubjectRepo;
using LecturerManagement.Core.Repositories.SubjectTypeRepo;
using LecturerManagement.Core.Repositories.TeachingRepo;
using LecturerManagement.Core.Repositories.TrainingSystemRepo;
using System;
using System.Threading.Tasks;

namespace LecturerManagement.Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        IAdvancedLearningRepository AdvancedLearnings { get; }
        IClassRepository Classes { get; }
        IDynamicClassFactorRepository DynamicClassFactors { get; }
        IGraduationThesisRepository GraduationThesises { get; }
        ILecturerRepository Lecturers { get; }
        ILecturerScientificResearchRepository LecturerScientificResearches { get; }
        IMachineRoomRepository MachineRooms { get; }
        IPositionRepository Positions { get; }
        IScientificResearchGuideRepository ScientificResearchGuides { get; }
        IStandardTimeRepository StandardTimes { get; }
        ISubjectDepartmentRepository SubjectDepartments { get; }
        ISubjectRepository Subjects { get; }
        ISubjectTypeRepository SubjectTypes { get; }
        ITeachingRepository Teachings { get; }
        ITrainingSystemRepository TrainingSystems { get; }

        Task<bool> Save();
    }
}