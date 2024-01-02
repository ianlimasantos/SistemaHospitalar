using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Models
{
    public enum MotivoCancelamento
    {
        [Description("O paciente desistiu")]
        PacienteDesistiu,

        [Description("O médico cancelou")]
        MedicoCancelou,

        [Description("Outros")]
        Outros

    }
}
