using System;

namespace Jf.Abp.RabbitMQ;

public interface IEventRabbitMqProvider
{
    string GetName(Type eventType);
    string GetQueue(Type eventType);
}
