using EPiServer.Cms.Shell;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.ContentApi.Core.DependencyInjection;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using EPiServer.Web;
using EPiServer.OpenIDConnect;
using EPiServer.ContentDefinitionsApi;
using EPiServer.ContentApi.Cms;

namespace back;

public class Startup
{
  private readonly IWebHostEnvironment _webHostingEnvironment;

  public Startup(IWebHostEnvironment webHostingEnvironment)
  {
    _webHostingEnvironment = webHostingEnvironment;
  }

  public void ConfigureServices(IServiceCollection services)
  {
    if (_webHostingEnvironment.IsDevelopment())
    {
      AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data"));

      services.Configure<SchedulerOptions>(options => options.Enabled = false);
    }

    services
        .AddCmsAspNetIdentity<ApplicationUser>()
        .AddCms()
        .AddAdminUserRegistration()
        .AddEmbeddedLocalization<Startup>()
        .ConfigureForExternalTemplates()
        .Configure<ExternalApplicationOptions>(options => options.OptimizeForDelivery = true);

    //services.AddHttpContextAccessor();

    services.Configure<DisplayOptions>(options =>
      {
        options
        .Add("full", "/displayoptions/full", "FullWidth", "FullWidth")
        .Add("wide", "/displayoptions/wide", "TwoThirdsWidth" , "TwoThirdsWidth")
        .Add("narrow", "/displayoptions/narrow", "OneThirdWidth", "OneThirdWidth");
      });


    services.AddOpenIDConnect<ApplicationUser>(
       useDevelopmentCertificate: true,
       signingCertificate: null,
       encryptionCertificate: null,
       createSchema: true,
       options =>
       {
         options.Applications.Add(new OpenIDConnectApplication
         {
           ClientId = "cli",
           ClientSecret = "cli",
           Scopes = { ContentDefinitionsApiOptionsDefaults.Scope, ContentDeliveryApiOptionsDefaults.Scope }, // Default scope from Content Definitions API
         });
       });

    // Add Delivery API to Application
    services
        .AddContentDeliveryApi(OpenIDConnectOptionsDefaults.AuthenticationScheme, options => {
          options.SiteDefinitionApiEnabled = true;
          options.DisableScopeValidation = false;
        })
        .WithSiteBasedCors();

    services.AddContentDefinitionsApi(OpenIDConnectOptionsDefaults.AuthenticationScheme, options => { });
    //.WithFriendlyUrl();
  }

  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
    }

    app.UseStaticFiles();
    app.UseRouting();

    app.UseCors(b => b
      .WithOrigins(new[] { "http://localhost:3000", "https://localhost:3001" })
      .WithExposedContentDeliveryApiHeaders()
      .WithExposedContentDefinitionApiHeaders()
      .AllowAnyMethod()
      .AllowAnyHeader()
      .AllowCredentials());

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapContent();
    });
  }
}