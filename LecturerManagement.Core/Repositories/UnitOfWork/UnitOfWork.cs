using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Data;
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

namespace LecturerManagement.Core.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LecturerManagementSystemDbContext _context;

        private IAccountRepository _accountRepository;
        private IAdvancedLearningRepository _advancedLearningRepository;
        private IClassRepository _classRepository;
        private IDynamicClassFactorRepository _dynamicClassFactorRepository;
        private IGraduationThesisRepository _graduationThesisRepository;
        private ILecturerRepository _lecturerRepository;
        private ILecturerScientificResearchRepository _lecturerScientificResearchRepository;
        private IMachineRoomRepository _machineRoomRepository;
        private IPositionRepository _positionRepository;
        private IScientificResearchGuideRepository _scientificResearchGuideRepository;
        private IStandardTimeRepository _standardTimeRepository;
        private ISubjectDepartmentRepository _subjectDepartmentRepository;
        private ISubjectRepository _subjectRepository;
        private ISubjectTypeRepository _subjectTypeRepository;
        private ITeachingRepository _teachingRepository;
        private ITrainingSystemRepository _trainingSystemRepository;



        public UnitOfWork(LecturerManagementSystemDbContext context)
        {
            _context = context;
        }

        public IAdvancedLearningRepository AdvancedLearnings => _advancedLearningRepository ??= new AdvancedLearningRepository(_context);

        public IClassRepository Classes => _classRepository ??= new ClassRepository(_context);

        public IDynamicClassFactorRepository DynamicClassFactors => _dynamicClassFactorRepository ??= new DynamicClassFactorRepository(_context);

        public IGraduationThesisRepository GraduationThesises => _graduationThesisRepository ??= new GraduationThesisRepository(_context);

        public ILecturerRepository Lecturers => _lecturerRepository ??= new LecturerRepository(_context);

        public ILecturerScientificResearchRepository LecturerScientificResearches => _lecturerScientificResearchRepository ??= new LecturerScientificResearchRepository(_context);

        public IMachineRoomRepository MachineRooms => _machineRoomRepository ??= new MachineRoomRepository(_context);

        public IPositionRepository Positions => _positionRepository ??= new PositionRepository(_context);

        public IScientificResearchGuideRepository ScientificResearchGuides => _scientificResearchGuideRepository ??= new ScientificResearchGuideRepository(_context);

        public IStandardTimeRepository StandardTimes => _standardTimeRepository ??= new StandardTimeRepository(_context);

        public ISubjectDepartmentRepository SubjectDepartments => _subjectDepartmentRepository ??= new SubjectDepartmentRepository(_context);

        public ISubjectRepository Subjects => _subjectRepository ??= new SubjectRepository(_context);

        public ISubjectTypeRepository SubjectTypes => _subjectTypeRepository ??= new SubjectTypeRepository(_context);

        public ITeachingRepository Teachings => _teachingRepository ??= new TeachingRepository(_context);

        public ITrainingSystemRepository TrainingSystems => _trainingSystemRepository ??= new TrainingSystemRepository(_context);

        public IAccountRepository Accounts => _accountRepository ??= new AccountRepository(_context);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                _context.Dispose();
            }
        }

        public async Task<bool> Save() => await _context.SaveChangesAsync() > 0;


    }
}
