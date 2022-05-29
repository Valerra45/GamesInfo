using GamesInfo.Application.MapProfiles;
using GamesInfo.Application.Services.Genres.Queryes;
using GamesInfo.Core.Abstractions;
using GamesInfo.DataAccess;
using GamesInfo.DataAccess.Data;
using GamesInfo.DataAccess.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDbInitializer, DbInitializer>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

builder.Services.AddDbContext<GamesInfoDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseSnakeCaseNamingConvention();
    options.UseLazyLoadingProxies();
});

builder.Services.AddMediatR(typeof(GetAllGeneresQuery).Assembly);

builder.Services.AddAutoMapper(typeof(GamesInfoProfile).Assembly);

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

Initialize(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void Initialize(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<IDbInitializer>();
        service.Initialize();
    }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
}
