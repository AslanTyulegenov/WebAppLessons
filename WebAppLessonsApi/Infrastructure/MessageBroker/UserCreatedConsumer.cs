using MassTransit;
using WebAppLessonsApi.Application.Consumers;

namespace WebAppLessonsApi.Infrastructure.MessageBroker;

public class UserCreatedConsumer : IConsumer<UserCreatedEvent>
{
    private readonly ILogger<UserCreatedConsumer> _logger;

    public UserCreatedConsumer(ILogger<UserCreatedConsumer> logger)
    {
        _logger = logger;
    }
    
    public Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
        _logger.LogInformation("Consumer created {@Consumer}", context.Message);
        
        return Task.CompletedTask;
    }
}

public class UserCreatedConsumer2 : IConsumer<UserCreatedEvent>
{
    private readonly ILogger<UserCreatedConsumer2> _logger;

    public UserCreatedConsumer2(ILogger<UserCreatedConsumer2> logger)
    {
        _logger = logger;
    }
    
    public Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
        _logger.LogInformation("Consumer created {@Consumer}", context.Message);
        
        return Task.CompletedTask;
    }
}