using SpaceInfo.Application;
using Microsoft.EntityFrameworkCore;
using SpaceInfo.Persistence;
using SpaceInfo.Persistence.Interceptors;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MainDbContext>(
    (sp, option) => option
                    .UseSqlServer(builder.Configuration.GetConnectionString("MainDbContext"))
                                                                           .AddInterceptors(sp.GetRequiredService<SoftDeleteInterceptor>())
                                                                           .AddInterceptors(sp.GetRequiredService<CreateInterceptor>())
                                                                           .AddInterceptors(sp.GetRequiredService<UpdateAuditInterceptor>()));

builder.Services.AddScoped<SoftDeleteInterceptor>();
builder.Services.AddScoped<CreateInterceptor>();
builder.Services.AddScoped<UpdateAuditInterceptor>();
builder.Services.AddControllers();
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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
