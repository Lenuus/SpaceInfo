#region Initalize Configuration and Services
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpaceInfo.Application;
using SpaceInfo.Domain;
using SpaceInfo.NasaService.Models.DailyInfo;
using SpaceInfo.NasaService.Models.NearObject;
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
#region NearObject 
var startDate = DateTime.Now.AddDays(-3);
var endDate = DateTime.Now;
var nearEarthObjectRepository = services.GetRequiredService<IRepository<NearEarthObject>>();
var closeApproachDataRepository = services.GetRequiredService<IRepository<CloseApproachData>>();
var missDistanceRepository = services.GetRequiredService<IRepository<MissDistance>>();
var diameterRepository = services.GetRequiredService<IRepository<Diameter>>();
var kilometerRepository = services.GetRequiredService<IRepository<Kilometers>>();
var milesRepository = services.GetRequiredService<IRepository<Miles>>();
var feetRepository = services.GetRequiredService<IRepository<Feet>>();
var metersRepository = services.GetRequiredService<IRepository<Meters>>();
var velocityRepository = services.GetRequiredService<IRepository<RelativeVelocity>>();

var dbNearEarthObject = nearEarthObjectRepository.GetAll().ToList();
var nearObjects = await NasaService.GetNearObjects(startDate, endDate).ConfigureAwait(false);
var willAddObjects = nearObjects.Data.Where(f => !dbNearEarthObject.Exists(x => x.Id == f.Id)).ToList();
var i = 0;
foreach (var item in willAddObjects)
{
    i++;
    Console.WriteLine($"{i}. Sayfa başlatıldı.");
    await InsertObjectToDb(item).ConfigureAwait(false);
}
async Task InsertObjectToDb(NearEarthObjectModel item)
{
    var newObject = new NearEarthObject
    {
        AbsoluteMagnitudeH = item.AbsoluteMagnitudeH,
        Name = item.Name,
        NasaJplUrl = item.NasaJplUrl,
        NeoReferenceId = item.NeoReferenceId,
        Id = item.Id,
        IsPotentiallyHazardous = item.IsPotentiallyHazardous,
        InsertedDate = DateTime.Now,

    };
    await nearEarthObjectRepository.Create(newObject).ConfigureAwait(false);

    var newLinks = new Links
    {
        NearEarthObjectId = item.Id,
        Self = item.Links.Self,
        Previous = item.Links.Previous,
        Next = item.Links.Next,
        InsertedDate = DateTime.Now,
    };
    var newDimaters = new Diameter
    {
        NearEarthObjectId = item.Id,
        InsertedDate = DateTime.Now,

    };
    await diameterRepository.Create(newDimaters).ConfigureAwait(false);
    var newKilometers = new Kilometers
    {
        DiameterId = newDimaters.Id,
        EstimatedDiameterMax = item.Diameter.Kilometers.EstimatedDiameterMax,
        EstimatedDiameterMin = item.Diameter.Kilometers.EstimatedDiameterMin,
        InsertedDate = DateTime.Now,
    };
    await kilometerRepository.Create(newKilometers).ConfigureAwait(false);
    var newMiles = new Miles
    {
        DiameterId = newDimaters.Id,
        EstimatedDiameterMax = item.Diameter.Miles.EstimatedDiameterMax,
        EstimatedDiameterMin = item.Diameter.Miles.EstimatedDiameterMin,
        InsertedDate = DateTime.Now,

    };
    await milesRepository.Create(newMiles).ConfigureAwait(false);
    var newFeets = new Feet
    {
        DiameterId = newDimaters.Id,
        EstimatedDiameterMin = item.Diameter.Feet.EstimatedDiameterMin,
        EstimatedDiameterMax = item.Diameter.Feet.EstimatedDiameterMax,
        InsertedDate = DateTime.Now,
    };
    await feetRepository.Create(newFeets).ConfigureAwait(false);
    var newMeters = new Meters
    {
        DiameterId = newDimaters.Id,
        EstimatedDiameterMax = item.Diameter.Meters.EstimatedDiameterMax,
        EstimatedDiameterMin = item.Diameter.Meters.EstimatedDiameterMin,
        InsertedDate = DateTime.Now,
    };
    await metersRepository.Create(newMeters).ConfigureAwait(false);

    foreach (var closeApproachData in item.CloseApproachDataModel)
    {
        var newCloseApproachData = new CloseApproachData
        {

            CloseApproachDate = closeApproachData.CloseApproachDate,
            EpochDateCloseApproach = closeApproachData.EpochDateCloseApproach,
            CloseApproachDateFull = closeApproachData.CloseApproachDateFull,
            NearEarthObjectId = item.Id,
            OrbitingBody = closeApproachData.OrbitingBody,
            InsertedDate = DateTime.Now,
        };
        await closeApproachDataRepository.Create(newCloseApproachData).ConfigureAwait(false);
        var newMissDistance = new MissDistance
        {
            Id = Guid.NewGuid(),
            CloseApproachDataId = newCloseApproachData.Id,
            Astronomical = closeApproachData.MissDistance.Astronomical,
            Lunar = closeApproachData.MissDistance.Lunar,
            Kilometers = closeApproachData.MissDistance.Kilometers,
            Miles = closeApproachData.MissDistance.Miles,
            InsertedDate = DateTime.Now,
        };
        await missDistanceRepository.Create(newMissDistance).ConfigureAwait(false);
        var newRelativeVelocity = new RelativeVelocity
        {
            CloseApproachDataId = newCloseApproachData.Id,
            KilometersPerSecond = closeApproachData.RelativeVelocity.KilometersPerSecond,
            KilometersPerHour = closeApproachData.RelativeVelocity.KilometersPerHour,
            MilesPerHour = closeApproachData.RelativeVelocity.MilesPerHour,
            InsertedDate = DateTime.Now,
        };
        await velocityRepository.Create(newRelativeVelocity).ConfigureAwait(false);
    }
}
#endregion

#region SearchNasa
var search = "Space";
var searchNasa = await NasaService.GetSearchMaterials(search).ConfigureAwait(false);
return 0;
#endregion