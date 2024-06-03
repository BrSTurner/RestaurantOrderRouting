using FluentValidation.Results;

namespace ROR.Core.Services
{
    public abstract class BaseService
    {
        protected ValidationResult ValidationResult { get; set; }
        public BaseService()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }
    }
}
