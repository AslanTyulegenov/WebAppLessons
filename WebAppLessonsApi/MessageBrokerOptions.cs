﻿namespace WebAppLessonsApi;

public sealed class MessageBrokerOptions
{
    public string Host { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string UserCreatedQueueName { get; set; } = string.Empty;
}