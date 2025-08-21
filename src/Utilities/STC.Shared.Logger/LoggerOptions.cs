namespace STC.Shared.Logger;

public record LoggerOptions
{
    public string ApplicationName { get; set; } = null!;
    public string ExchangeName { get; set; } = null!;
    public int BatchPostingLimit { get; set; }
    public RabbitMqLoggerOptions RabbitMqOptions { get; set; } = null!;
}