namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes.Count <= Suite.Capacidade )
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"A quantidade {hospedes.Count} de hospedes excedeu o Limite atual da suite, Capacidade limite da Suite é de {Suite.Capacidade} {(Suite.Capacidade > 1 ? "Hospedes" : "Hospede")}");

            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = 0;
            valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                var desconto = (valor * 10)/100;
                valor -= desconto;
            }

            return valor;
        }
    }
}