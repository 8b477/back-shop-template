using FluentValidation;

using Microsoft.AspNetCore.Http;

namespace API_Shop.Validators
{
    internal static class ValidatorModelState
    {
        internal static async Task<IResult> ValidModelState<T>(T entity, IValidator<T> validator)
        {
            var validationResult = await validator.ValidateAsync(entity);
            return validationResult.IsValid
                ? Results.Ok()
                : Results.ValidationProblem(validationResult.ToDictionary());
        }
    }
}
