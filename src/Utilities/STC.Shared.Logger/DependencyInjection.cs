using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.RabbitMQ;

namespace STC.Shared.Logger;

public static class DependencyInjection
{
    public static IServiceCollection AddLoggerDependencies(this IServiceCollection services,
        ILoggingBuilder loggingBuilder,
        Action<LoggerOptions> options)
    {
        LoggerOptions opt = new();
        options.Invoke(obj: opt);

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.RabbitMQ(
                hostnames: [opt.RabbitMqOptions.HostName],
                port: opt.RabbitMqOptions.Port,
                username: opt.RabbitMqOptions.UserName,
                password: opt.RabbitMqOptions.Password,
                exchange: opt.ExchangeName,
                autoCreateExchange: true,
                queueLimit: 1,
                deliveryMode: RabbitMQDeliveryMode.Durable,
                batchPostingLimit: opt.BatchPostingLimit,
                clientProvidedName: opt.ApplicationName
            ).CreateLogger();

        loggingBuilder.ClearProviders().AddSerilog(logger: Log.Logger);

        return services;
    }
}