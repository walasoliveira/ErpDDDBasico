namespace ErpDDDBasico.Domain.ValueObject
{
    public class ContaBancaria
    {
        public const int AgenciaMaxLentgh = 10;
        public const int ContaMaxLentgh = 10;
        public string Agencia { get; set; }
        public string Conta { get; set; }
    }
}
