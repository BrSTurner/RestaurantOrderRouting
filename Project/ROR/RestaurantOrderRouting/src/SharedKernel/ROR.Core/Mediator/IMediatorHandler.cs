using FluentValidation.Results;
using ROR.Core.Messages;
using System.Threading.Tasks;

namespace ROR.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
