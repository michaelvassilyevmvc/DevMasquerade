using System.Text.Json;
using Shared;

namespace DevMasquerade.Application.Exceptions;

public class NotFoundException : Exception
{
    protected NotFoundException(Error[] errors)
        : base(JsonSerializer.Serialize(errors))
    {
    }
}