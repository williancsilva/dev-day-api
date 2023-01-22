using DevSecOps.backoffice.Configurations;
using DevSecOps.backoffice.Filters;
using DevSecOps.backoffice.LogHelper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var origins = configuration.GetSection("Origins").GetChildren().Select(x => x.Value).ToArray();
var endPointAccessControl = configuration["EndPointAccessControl"];
var enabledLog = Convert.ToBoolean(configuration["EnabledLog"]);

builder.Services.AddCors(cors =>
{
    cors.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins(origins)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

builder.Services.IntegrateDependencyResolver();

builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthenticationHandler", null);

//builder.Services.AddAuthorization(options => { options.AddPolicy("Operar", policy => policy.RequireClaim("Operadores", new string[] { "consultar", "bloquear" })); });
builder.Services.AddAuthorization();

builder.Services.AddMvcCore(options => options.Filters.Add<NotificationFilter>());
builder.Services.AddMvcCore(options => options.Filters.Add<LogFilter>());

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.IntegrateSwagger().AddMediatR(typeof(Program));

var app = builder.Build();


app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        if (context.Response.StatusCode == StatusCodes.Status500InternalServerError)
        {
            var ex = context.Features.Get<IExceptionHandlerFeature>();
            if (ex != null && enabledLog)
                await ServiceLog.GravaLog(ex.Error.ToString(), context.Request.Path, context.Request.Method);

            context.Response.ContentType = Text.Plain;

            await context.Response.WriteAsync("Estamos enfrentando problema. Tente novamente mais tarde ou procure o administrador do sistema.");
        }
    });
});


app.Use((context, next) =>
{
    context.Request.EnableBuffering();
    return next();
});

app.UseCors("AllowSpecificOrigin");

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();

    app.UseSwaggerUI(c => { c.SwaggerEndpoint("v1/swagger.json", "Daycoval backoffice - Cliente Api - V1"); });
}

app.MapControllers();

app.Run();