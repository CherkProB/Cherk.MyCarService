namespace Cherk.MyCarService;

public sealed class Startup
{
    private const string CorsPolicyName = "AllowAll";
    
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    } 
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        
        services.AddCors(policy => 
            policy.AddPolicy(CorsPolicyName, builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            ));
    }
    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseCors(CorsPolicyName);
        
        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
        });
    }
}
