using SWFC.Domain.Common.Validation;

namespace SWFC.Application.Common.Validation;

public interface ICommandValidator<in TCommand>
{
    ValidationResult Validate(TCommand command);
}
