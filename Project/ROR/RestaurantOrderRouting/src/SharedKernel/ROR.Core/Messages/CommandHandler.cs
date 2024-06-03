using FluentValidation.Results;
using ROR.Core.Data;
using System.Threading.Tasks;

namespace ROR.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        protected async Task<ValidationResult> SaveChanges(IUnitOfWork uow)
        {
            if (!await uow.Commit())
            {
                AddError("Something went wrong saving data");
            }

            return ValidationResult;
        }
    }
}
