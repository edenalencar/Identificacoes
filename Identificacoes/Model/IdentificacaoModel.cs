namespace Identificacoes.Model
{
    class IdentificacaoModel
    {
        private string nucleo;
        private string primeiroDigito;
        private string segundoDigito;
        private string filial;

        public string Nucleo { get => nucleo; set => nucleo = value; }
        public string PrimeiroDigito { get => primeiroDigito; set => primeiroDigito = value; }
        public string SegundoDigito { get => segundoDigito; set => segundoDigito = value; }
        public string Filial { get => filial; set => filial = value; }
    }
}
