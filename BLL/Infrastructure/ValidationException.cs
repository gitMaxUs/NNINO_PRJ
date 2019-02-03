using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Infrastructure
{
    public class ValidationException : Exception
    {
        //This property allows you to save the name of the property of the model,
        // which is incorrect and does not pass validation.
        public string Property
        {
            get;
            protected set;
        }

        public ValidationException(string message, string prop)
            : base(message)
        {
            Property = prop;
        }
    }
}
