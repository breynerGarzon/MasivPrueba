using System;
using System.Runtime.Serialization;

namespace RuletaWebApi.Entidades.Exepciones
{
    public class RuletaException : Exception
    {
        public RuletaException()
        {
        }

        public RuletaException(string message) : base(message)
        {
        }

        public RuletaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RuletaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}