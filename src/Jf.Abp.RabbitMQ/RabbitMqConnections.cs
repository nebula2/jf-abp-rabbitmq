﻿using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using RabbitMQ.Client;
using Volo.Abp;

namespace Jf.Abp.RabbitMQ;

[Serializable]
public class RabbitMqConnections : Dictionary<string, ConnectionFactory>
{
    public const string DefaultConnectionName = "Default";

    [NotNull]
    public ConnectionFactory Default {
        get => this[DefaultConnectionName];
        set => this[DefaultConnectionName] = Check.NotNull(value, nameof(value));
    }

    public RabbitMqConnections()
    {
        Default = new ConnectionFactory();
    }

    public ConnectionFactory GetOrDefault(string connectionName)
    {
        return TryGetValue(connectionName, out var connectionFactory) ? connectionFactory : Default;
    }
}
