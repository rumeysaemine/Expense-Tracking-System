using System;

namespace ExpenseTracking.Application.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException()
        : base() { }

    public NotFoundException(string message)
        : base(message) { }

    public NotFoundException(string name, object key)
        : base($"'{name}' ({key}) bulunamadı.") { }
}