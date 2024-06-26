using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Play.Common.Settings;
using Play.Identity.Service.Entities;

namespace Play.Identity.Service;

public static class DependencyInjection
{
    public static IServiceCollection AddMongodbIdentitySettings(this IServiceCollection services, IConfiguration configuration)
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
        BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));
        var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
        var mongoDbSettings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();

        services.AddDefaultIdentity<ApplicationUser>()
                  .AddRoles<ApplicationRole>()
                   .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>
                   (
                      mongoDbSettings.ConnectionString,
                      serviceSettings.ServiceName
                   );
        return services;
    }
}
