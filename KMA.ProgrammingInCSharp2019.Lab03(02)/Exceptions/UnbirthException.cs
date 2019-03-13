using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.ProgrammingInCSharp2019.Lab03_02_.Exceptions
{
    internal class UnbirthException :Exception
    {
        public UnbirthException(string message)
            : base(message){}
    }
}
