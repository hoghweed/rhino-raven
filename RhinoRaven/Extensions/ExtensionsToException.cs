using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading;

namespace RhinoRaven.Extensions;

public static class ExtensionsToException
{
    public static string ToFormattedString(this Exception exception)
    {
        var messages = exception
          .GetAllExceptions()
          .Where(e => !string.IsNullOrWhiteSpace(e.Message))
          .Select(e => e.Message.Trim());
        string flattened = string.Join(Environment.NewLine + "    ", messages);
        return flattened;
    }

    private static IEnumerable<Exception> GetAllExceptions(this Exception exception)
    {
        yield return exception;

        if (exception is AggregateException aggregated)
        {
            foreach (var innerException in aggregated.InnerExceptions.SelectMany(e => e.GetAllExceptions()))
            {
                yield return innerException;
            }
        }
        else if (exception.InnerException != null)
        {
            foreach (var innerException in exception.InnerException.GetAllExceptions())
            {
                yield return innerException;
            }
        }
    }

}

