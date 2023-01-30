using FluentValidation;
using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace DevSecOps.backoffice.App.Dto;

public class DtoBase
{
    [JsonIgnore] public bool Valid { get; private set; }
    [JsonIgnore] public bool Invalid => !Valid;
    [JsonIgnore] public int DayId { get; set; }
    [JsonIgnore] public ValidationResult ValidationResult { get; private set; }

    protected void Validar<TModel>(TModel model, AbstractValidator<TModel> validator)
    {
        ValidationResult = validator.Validate(model);
        Valid = ValidationResult.IsValid;
    }
}