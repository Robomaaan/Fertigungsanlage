using System;

namespace Fertigungsanlage
{
    public class VerschleissException : Exception
    {
        public VerschleissException(string message)
            : base(message)
        {
        }
    }
}