using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBudget.Models
{
    public class SBResult
    {
        public bool Result { get; set; }

        public object Data { get; set; }

        public string Message { get; set; }

        public static SBResult Success(object data = null, string message = "")
        {
            return new SBResult
            {
                Data = data,
                Message = message,
                Result = true
            };
        }

        public static SBResult Error(string message, object data = null)
        {
            return new SBResult
            {
                Data = data,
                Message = message,
                Result = false
            };
        }
    }
}
