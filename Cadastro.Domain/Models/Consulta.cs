namespace Cadastro.Domain.Models
{
    public class Consulta
    {
        public long Id { get; private set; }
        public long MedicoId { get; private set; }
        public long PacienteId { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataUpdate { get; private set; }
        public bool Ativo { get; private set; }
        public MotivoCancelamento MotivoCancelamento { get; private set; }
        public virtual Medico Medico { get; private set; }
        public virtual Paciente Paciente { get; private set; }

        public Consulta(long medicoId, long pacienteId, DateTime dataInicio)
        {
         //   MedicoId = medicoId;
            PacienteId = pacienteId;
            DataInicio = dataInicio;
            DataCadastro = DateTime.Now;
            DataUpdate = DateTime.Now;
            Ativo = true;
        }   

        public void Atualizar(long medicoId, long pacienteId, DateTime dataInicio) 
        {
            MedicoId = medicoId;
            PacienteId = pacienteId;
            DataInicio = dataInicio;
            DataUpdate = DateTime.Now;
        }

        public void CancelarConsulta(MotivoCancelamento motivoCancelamento)
        {
            Ativo = false;
            MotivoCancelamento = motivoCancelamento;
        }
    }
}
