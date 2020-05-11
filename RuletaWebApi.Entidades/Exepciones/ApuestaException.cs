using System;
using System.Runtime.Serialization;

namespace RuletaWebApi.Entidades.Exepciones
{
    public class ApuestaException : Exception
    {
        public ApuestaException()
        {
        }

        public ApuestaException(string message) : base(message)
        {
        }

        public ApuestaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApuestaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}