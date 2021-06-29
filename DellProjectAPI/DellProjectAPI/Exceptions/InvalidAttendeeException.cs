using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DellProjectAPI.Exceptions
{
    public class InvalidAttendeeException : Exception
    {
        public InvalidAttendeeException(string message) : base(message)
        {

        }

        public InvalidAttendeeException(string message, Exception e) : base(message, e)
        {

        }

    }
}
