#region Initalize Configuration and Services
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpaceInfo.Application;
using SpaceInfo.Domain;
using SpaceInfo.NasaService.Models.DailyInfo;
using SpaceInfo.NasaService.Services;
using SpaceInfo.Persistence;

IConfiguration Configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

var NasaService = new NasaService(Configuration);

var serviceProvider = new ServiceCollection();
serviceProvider.AddDbContext<MainDbContext>(
    option => option.UseSqlServer(Configuration.GetConnectionString("MainDbContext")));
serviceProvider.AddTransient(typeof(IRepository<>), typeof(Repository<>));
var services = serviceProvider.BuildServiceProvider();
#endregion
#region dailyInfo
var dailyInfosRepository = services.GetRequiredService<IRepository<DailyInfo>>();
var dbDailyInfos = dailyInfosRepository.GetAll().ToList();
var date = DateTime.Now.AddDays(-30);
var dailyData = await NasaService.GetDailyInfos(date).ConfigureAwait(false);

if (dbDailyInfos.Count == 0)
{
    foreach (var item in dailyData.Data)
    {
        InsertInfosToDb(item);
    }
}
else
{
    var willInsertedInfos = dailyData.Data.Where(f => !dbDailyInfos.Exists(x => x.Date == f.Date)).ToList();
    var existedInfos = dailyData.Data.Where(f => dbDailyInfos.Exists(x => x.Date == f.Date)).ToList();
    foreach (var item in willInsertedInfos)
    {
        InsertInfosToDb(item);
    }
}

void InsertInfosToDb(DailyInfoModel item)
{
    var newInfo = new DailyInfo()
    {
        Copyright = item.Copyright,
        Date = item.Date,
        Explanation = item.Explanation,
        Hdurl = item.HdUrl,
        MediaType = item.MediaType,
        Title = item.Title,
        Url = item.Url,
    };
    dailyInfosRepository.Create(newInfo).Wait();
}

#endregion