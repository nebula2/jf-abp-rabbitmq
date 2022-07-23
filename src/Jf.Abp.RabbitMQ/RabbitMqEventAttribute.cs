using JetBrains.Annotations;
using System;
using System.Linq;
using Volo.Abp;

namespace Jf.Abp.RabbitMQ;

[AttributeUsage(AttributeTargets.Class)]

public class RabbitMqEventAttribute : Attribute, IEventRabbitMqProvider
{
    public virtual string Queue { get; set; }
    public virtual string Name { get; }

    public RabbitMqEventAttribute([CanBeNull] string name) => Name = Check.NotNullOrWhiteSpace(name, nameof(name));

    public static string GetQueueOrDefault([NotNull] Type eventType)
    {
        Check.NotNull(eventType, nameof(eventType));

        return eventType
            .GetCustomAttributes(true)
            .OfType<IEventRabbitMqProvider>()
            .FirstOrDefault()
            ?.GetQueue(eventType);
    }

    public static string GetNameOrDefault<TEvent>() => GetNameOrDefault(typeof(TEvent));

    public static string GetNameOrDefault([NotNull] Type eventType)
    {
        Check.NotNull(eventType, nameof(eventType));

        return eventType
                   .GetCustomAttributes(true)
                   .OfType<IEventRabbitMqProvider>()
                   .FirstOrDefault()
                   ?.GetName(eventType)
               ?? eventType.FullName;
    }

    public string GetName(Type eventType) => Name;

    public string GetQueue(Type eventType) => Queue;
}
