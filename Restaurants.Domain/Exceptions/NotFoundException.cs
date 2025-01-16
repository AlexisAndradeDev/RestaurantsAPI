namespace Restaurants.Domain.Exceptions;

public class NotFoundException(string resourceType, string resourceId) : Exception($"Resource of type '{resourceType}' with ID {resourceId} does not exist.")
{
}
