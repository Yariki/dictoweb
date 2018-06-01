namespace DictoInfrasctructure.Dtos
{
    public class VariantDto
    {

        public VariantDto()
        {
            IsCorrect = false;
        }

        public string Translation { get; set; }

        public bool IsCorrect { get; set; }

    }
}