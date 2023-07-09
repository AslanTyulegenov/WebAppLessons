namespace WebAppLessonsApi.Application.Consumers;

public record UserCreatedEvent(string Firstname, string Lastname, int Age);