using HastaneListesiApp.Repository.Configuration;
using HastaneListesiApp.Services.Configurations;
using HastaneListesiApp.WebService.CustomFilters;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers().AddNewtonsoftJson(opt => { opt.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore; opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; });
builder.Services.Configure<ApiBehaviorOptions>(option =>
{
    option.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.RegisterRepositories();
builder.Services.RegisterAutoMapper();
builder.Services.RegisterValidations();
builder.Services.RegisterServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped(typeof(CustomFilterAttribute<,,>));
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
