namespace ErpDDDBasico.Domain.ValueObject
{
    public class Endereco
    {
        public const int LogradouroMaxLenght = 100;
        public const int NumeroMaxLenght = 20;
        public const int ComplementoMaxLenght = 20;
        public const int BairroMaxLenght = 20;
        public const int CidadeMaxLenght = 20;

        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
    }
}