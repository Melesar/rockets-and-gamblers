using System;

namespace RocketsAndGamblers.Server
{
    public class AzureException : Exception
    {
        public AzureException()
        {
        }

        public AzureException(string message) : base(message)
        {
        }
    }
}