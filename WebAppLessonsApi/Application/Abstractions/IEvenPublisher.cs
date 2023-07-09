namespace WebAppLessonsApi.Application.Abstractions;

public interface IEvenPublisher
{
    Task Publish<T>(T message, CancellationToken cancellationToken = default) where T : class;
}