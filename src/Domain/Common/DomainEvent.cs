﻿using System;
using System.Collections.Generic;

namespace DesafioBackendAPI.Domain.Common;

public interface IHasDomainEvent
{
    public List<DomainEvent> DomainEvents { get; set; }
}

public class DomainEvent
{
    public bool IsPublished { get; set; }
    public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;

}
