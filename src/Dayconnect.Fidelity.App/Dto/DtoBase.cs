using Dayconnect.Fidelity.App.Base;
using FluentValidation;
using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace Dayconnect.Fidelity.App.Dto
{
	public class DtoBase
	{
		[JsonIgnore]
		public bool Valid { get; private set; }
		[JsonIgnore]
		public bool Invalid => !Valid;

		[JsonIgnore]
		public ValidationResult ValidationResult { get; private set; }

		public bool Validar<TModel>(TModel model, AbstractValidator<TModel> validator)
		{
			ValidationResult = validator.Validate(model);
			return Valid = ValidationResult.IsValid;
		}
	}
}
