using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // Basic Void Commands
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }

    }
}
