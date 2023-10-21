using System.ComponentModel.DataAnnotations;

namespace TP_Principal_G4.Validations
{
    internal class IsEspecieAttribute : ValidationAttribute
    {
        public IsEspecieAttribute(string errorMessage) : base(errorMessage)
        {
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string? especie = value as string; // casteo el dato enviado

                if(especie != null)
                {
                    especie = especie.Trim().ToLower(); // convierto todo el string a minúscula

                    if(especie != "perro" && especie != "gato") // si la especie enviada no es correcta, arroja un mensaje de error
                        return new ValidationResult(base.ErrorMessage);
                }
            }

            return ValidationResult.Success!;
        }
    }
}
