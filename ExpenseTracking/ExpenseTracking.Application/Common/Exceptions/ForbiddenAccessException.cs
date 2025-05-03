using System;

namespace ExpenseTracking.Application.Common.Exceptions;

public class ForbiddenAccessException : Exception
{
    public ForbiddenAccessException() : base("Bu işleme erişiminiz yok.") { }
}