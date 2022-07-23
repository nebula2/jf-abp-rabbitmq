using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.EventBus;
using Volo.Abp.Modularity;
using Volo.Abp.RabbitMQ;

namespace Jf.Abp.RabbitMQ;

[DependsOn(
    typeof(AbpEventBusModule),
    typeof(AbpRabbitMqModule))]
public class JfAbpRabbitMqModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        Configure<AbpRabbitMqEventBusOptions>(configuration.GetSection("RabbitMQ:EventBus"));
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        context
            .ServiceProvider
            .GetRequiredService<RabbitMqDistributedEventBus>()
            .Initialize();
    }
}
