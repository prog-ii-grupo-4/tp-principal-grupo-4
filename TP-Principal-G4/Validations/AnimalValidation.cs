namespace TP_Principal_G4.Validations
{
    internal class AnimalValidation
    {
        public const int MAX_LENGTH_NOMBRE = 100;
        public const int MAX_LENGTH_GENERO = 10;
        public const int MIN_RANGE_PESO = 1;
        public const int MAX_RANGE_PESO = 100;
        public const int MIN_RANGE_ALTURA = 1;
        public const int MAX_RANGE_ALTURA = 100;
        public const int MAX_LENGTH_DESCRIPCION = 200;
        public const int MAX_LENGTH_COLOR = 20;
        public const int MAX_LENGTH_ESPECIE = 20;

        public const string REQUIRED_MESSAGE = "Este campo es obligatorio.";
        public const string MAX_LENGTH_NOMBRE_MESSAGE = "Máximo 100 caracteres.";
        public const string MAX_LENGTH_GENERO_MESSAGE = "Máximo 10 caracteres.";
        public const string RANGE_PESO_MESSAGE = "El peso debe estar entre 1 y 100 kg.";
        public const string RANGE_ALTURA_MESSAGE = "La altura debe estar entre 1 y 100 cm.";
        public const string MAX_LENGTH_DESCRIPCION_MESSAGE = "Máximo 200 caracteres.";
        public const string MAX_LENGTH_COLOR_MESSAGE = "Máximo 20 caracteres.";
        public const string MAX_LENGTH_ESPECIE_MESSAGE = "Máximo 20 caracteres.";
    }
}
