using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Data;
using LecturerManagement.Core.Repositories.AdvancedLearningRepo;
using LecturerManagement.Core.Repositories.AuthenRepo;
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
using LecturerManagement.Core.Repositories.UnitOfWork;
using LecturerManagement.Services.AccountService;
using LecturerManagement.Services.AdvancedLearningService;
using LecturerManagement.Services.ClassService;
using LecturerManagement.Services.GraduationThesisService;
using LecturerManagement.Services.LecturerScientificResearchService;
using LecturerManagement.Services.LecturerService;
using LecturerManagement.Services.MachineRoomService;
using LecturerManagement.Services.PositionService;
using LecturerManagement.Services.ScientificResearchGuideService;
using LecturerManagement.Services.StandardTimeService;
using LecturerManagement.Services.SubjectDepartmentService;
using LecturerManagement.Services.SubjectService;
using LecturerManagement.Services.SubjectTypeService;
using LecturerManagement.Services.TeachingService;
using LecturerManagement.Services.TrainingSystemService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace LecturerManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LecturerManagementSystemDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //DI UnitOfwork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //DI Repository

            services.AddScoped<IAuthRepository, AuthRepository>();

            services.AddScoped<IAdvancedLearningRepository, AdvancedLearningRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IDynamicClassFactorRepository, DynamicClassFactorRepository>();
            services.AddScoped<IGraduationThesisRepository, GraduationThesisRepository>();
            services.AddScoped<ILecturerRepository, LecturerRepository>();
            services.AddScoped<ILecturerScientificResearchRepository, LecturerScientificResearchRepository>();
            services.AddScoped<IMachineRoomRepository, MachineRoomRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IScientificResearchGuideRepository, ScientificResearchGuideRepository>();
            services.AddScoped<IStandardTimeRepository, StandardTimeRepository>();
            services.AddScoped<ISubjectDepartmentRepository, SubjectDepartmentRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<ISubjectTypeRepository, SubjectTypeRepository>();
            services.AddScoped<ITeachingRepository, TeachingRepository>();
            services.AddScoped<ITrainingSystemRepository, TrainingSystemRepository>();

            //DI Service
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAdvancedLearningService, AdvancedLearningService>();
            services.AddScoped<IClassService, ClassService>();
            //services.AddScoped<IDynamicClassFactorService, DynamicClassFactorRepository>();
            services.AddScoped<IGraduationThesisService, GraduationThesisService>();
            services.AddScoped<ILecturerService, LecturerService>();
            services.AddScoped<ILecturerScientificResearchService, LecturerScientificResearchService>();
            services.AddScoped<IMachineRoomService, MachineRoomService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IScientificResearchGuideService, ScientificResearchGuideService>();
            services.AddScoped<IStandardTimeService, StandardTimeService>();
            services.AddScoped<ISubjectDepartmentService, SubjectDepartmentService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ISubjectTypeService, SubjectTypeService>();
            services.AddScoped<ITeachingService, TeachingService>();
            services.AddScoped<ITrainingSystemService, TrainingSystemService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LecturerManagermentCodeFirst.API", Version = "v1" });
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LecturerManagement.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
