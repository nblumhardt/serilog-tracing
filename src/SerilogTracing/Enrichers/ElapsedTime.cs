﻿using Serilog.Core;
using Serilog.Events;
using SerilogTracing.Interop;

namespace SerilogTracing.Enrichers;

internal class ElapsedTime: ILogEventEnricher
{
    public ElapsedTime(string propertyName)
    {
        _propertyName = propertyName;
    }
    
    readonly string _propertyName;
    
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        if (logEvent.TryGetElapsed(out var elapsed))
        {
            logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty(_propertyName, elapsed.Value));
        }
    }
}
