using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioRocketSeat1.Enum
{
    /// <summary>
    /// Enum que representa os diferentes programas disponíveis para o usuário selecionar no menu principal.
    /// </summary>
    public enum Programs
    {
        Boas_Vindas = 1,
        None_Completo = 2,
        Operacoes_Matematicas = 3,
        Quantidade_Caracteres = 4,
        Validador_Placas = 5,
        Formatos_Data = 6
    }

    /// <summary>
    /// Enum que representa os tipos de operações matemáticas disponíveis no programa de cálculo.
    /// </summary>
    public enum Operacao
    {
        Soma = 1,
        Subtracao = 2,
        Multiplicacao = 3,
        Divisao = 4,
        Media = 5,
    }
}
