using MassTransit;
using Microsoft.Extensions.Options;
using WebAppLessonsApi.Application.Abstractions;
using WebAppLessonsApi.Infrastructure.MessageBroker;

namespace WebAppLessonsApi.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.Configure<MessageBrokerOptions>(builder.Configuration.GetSection("MessageBroker"));
        services.AddSingleton(sp => sp.GetRequiredService<IOptions<MessageBrokerOptions>>().Value);
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.AddConsumer<UserCreatedConsumer>();
            busConfigurator.AddConsumer<UserCreatedConsumer2>();
            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                var massageBrokerOptions = context.GetRequiredService<MessageBrokerOptions>();

                configurator.Host(new Uri(massageBrokerOptions.Host), hc =>
                {
                    hc.Username(massageBrokerOptions.Username);
                    hc.Password(massageBrokerOptions.Password);
                });
                
                configurator.ReceiveEndpoint(massageBrokerOptions.UserCreatedQueueName, endpointConfig =>
                {
                    endpointConfig.ConfigureConsumer<UserCreatedConsumer>(context);
                    endpointConfig.ConfigureConsumer<UserCreatedConsumer2>(context);
                });
            });
            
           
        });
        
        services.AddScoped<IEvenPublisher, EvenPublisher>();
        return services;
    }
}