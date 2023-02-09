using DesafioBackendAPI.Domain.Common;
using System.Threading.Tasks;

namespace DesafioBackendAPI.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
