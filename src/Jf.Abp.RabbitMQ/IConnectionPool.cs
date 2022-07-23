using System;
using RabbitMQ.Client;

namespace Jf.Abp.RabbitMQ;

public interface IConnectionPool : IDisposable
{
    IConnection Get(string connectionName = null);
}
