using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard_MK4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Dashboard_MK4.Models.V2_Models;
using Dashboard_MK4.Models.V2_Repository;
using Dashboard_MK4.Models.V2_DataManager;
using Dashboard_MK4.Models.V3_Models;
using Dashboard_MK4.Models.V3_DataManager;
using Dashboard_MK4.Models.V3_Repository;

namespace Dashboard_MK4
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
            // Email service implementation having issue with authentication from the client side
            // unable to authenticate into email servers
            /*
            var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();*/

            string prodEnvDb = Configuration["ConnectionString:Azure_Server_DB"];
            string devEnvDb = Configuration["ConnectionString:JTFA_DB"];
            string envDb = devEnvDb;

            services.AddDbContext<JobCard_TaskDescriptions_Context>(opts => opts.UseSqlServer(envDb));
            services.AddDbContext<JTFA_Task_Description_Context>(opts => opts.UseSqlServer(envDb));
            services.AddScoped<ITaskDescription_Data_Repository<TaskDescription>, TaskDescription_Data_Manager>();
            services.AddScoped<IJobCardV3DataRepository<JobCardV3>, JobCardV3_Manager>();
            services.AddDbContext<JTFA_Client_Context>(opts => opts.UseSqlServer(envDb));
            services.AddScoped<IJTFA_Client_Data_Repository<JTFA_Client>, JTFA_Client_Manager>();
            services.AddDbContext<Vehicle_Context>(opts => opts.UseSqlServer(envDb));
            services.AddScoped<IVehicleDataRepository<Vehicle>, Vehicle_Manager>();
            services.AddScoped<IJTFA_Client_Data_Repository<JTFA_Client>, JTFA_Client_Manager>();
            services.AddControllers();

            // Throws error that  max json length is exceeded this method allows it to be ignored without making changes to the model
            // https://stackoverflow.com/questions/59199593/net-core-3-0-possible-object-cycle-was-detected-which-is-not-supported
            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //

            app.UseDeveloperExceptionPage();

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
