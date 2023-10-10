using FluentValidation;
using FluentValidation.Results;
using LivroDeReceitas.Core.Application.Request.Usuario;
using LivroDeReceitas.Core.Shared.Resources;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LivroDeReceitas.Core.Application.Validators.Usuario
{
    public class UsuarioRegistrarValidator : AbstractValidator<UsuarioRegistrarRequest>
    {
        public UsuarioRegistrarValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty()
                .WithMessage(u => string.Format(CultureInfo.CurrentCulture, MensagensDeErros.LDR_0000001, nameof(u.Nome)));

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage(u => string.Format(CultureInfo.CurrentCulture, MensagensDeErros.LDR_0000001, nameof(u.Email)));

            When(u => !string.IsNullOrEmpty(u.Email), () =>
            {
                RuleFor(u => u.Email).EmailAddress()
                .WithMessage(u => string.Format(CultureInfo.CurrentCulture, MensagensDeErros.LDR_0000002, nameof(u.Email)));
            });

            When(u => !string.IsNullOrEmpty(u.Telefone), () =>
            {
                RuleFor(u => u.Telefone).Custom((telefone, context) =>
                {
                    string padrao = "[0-9]{2} [1-9]{1} [0-9]{4}-[0-9]{4}";
                    var result = Regex.IsMatch(telefone, padrao);

                    if (!result) context.AddFailure(new ValidationFailure(nameof(telefone), string.Format(CultureInfo.CurrentCulture, MensagensDeErros.LDR_0000002, nameof(telefone))));
                });
            });
        }
    }
}
