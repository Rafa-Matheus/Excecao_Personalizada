using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excecao_Personalizada
{
    class NumeroNegativoException : Exception
    {

        public NumeroNegativoException(int number) : base($"\nO número {number} não é positivo!\n") { }
    }
}
