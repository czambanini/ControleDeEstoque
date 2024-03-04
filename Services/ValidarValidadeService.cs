using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    static class ValidarValidadeService
    {
        public static bool ValidarValidade(DateTime vencimento)
        {
            if (vencimento < DateTime.Now)
                return false;
            else return true;
        }


    }
}
