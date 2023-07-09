using MassTransit;
using WebAppLessonsApi.Application.Abstractions;

namespace WebAppLessonsApi.Infrastructure.MessageBroker;

internal sealed class EvenPublisher : IEvenPublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public EvenPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public Task Publish<T>(T message, CancellationToken cancellationToken = default) where T : class
    {
        return _publishEndpoint.Publish(message, cancellationToken);
    }
}