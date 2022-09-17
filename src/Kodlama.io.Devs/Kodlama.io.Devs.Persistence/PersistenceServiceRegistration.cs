using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Persistence.Contexts;
using Kodlama.io.Devs.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                options.UseSqlServer(
                                                    configuration.GetConnectionString("KodlamaioDevsConnectionString")));
            services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
            services.AddScoped<ILanguageTechnologyRepository, LanguageTechnologyRepository>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<ISocialRepository, SocialRepository>();


            //Security
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();



            return services;
        }
    }
}
