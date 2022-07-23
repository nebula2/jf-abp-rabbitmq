using System;

namespace Jf.Abp.RabbitMQ;

public interface IChannelPool : IDisposable
{
    IChannelAccessor Acquire(string channelName = null, string connectionName = null);
}
