using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeContatos
{
    public class TelefoneException:Exception
    {
        public TelefoneException(string msg):base(msg)
        {
            
        }
    }
}
