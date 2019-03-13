using System;


namespace KMA.ProgrammingInCSharp2019.Lab03_02_.Exceptions
{
    internal class WrongEmailException : Exception
    {
        public WrongEmailException(string message)
            : base(message){}
    }
}
