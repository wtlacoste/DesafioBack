using System;

namespace DesafioBackendAPI.Domain.Common;

public record struct AuditableEntity(DateTime Created, string CreatedBy, DateTime? LastModified, string LastModifiedBy) { }