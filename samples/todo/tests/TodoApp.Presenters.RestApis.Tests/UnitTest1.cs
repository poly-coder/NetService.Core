using System.Reflection;
using NetService.Testing.Mappings;

namespace TodoApp.Presenters.RestApis.Tests;

public class MapperTests
{
    [Theory]
    [MemberData(nameof(MapperIsNonPrivate_Data))]
    public void MapperIsNonPrivate(MethodInfo method)
    {
        Assert.False(
            method.IsPrivate,
            $"{method.DeclaringType!.FullName}.{method.Name} should not be private.");
    }

    public static IEnumerable<object?[]> MapperIsNonPrivate_Data()
    {
        return TodoAppPresentersRestApis.Assembly
            .GetMapperMethods()
            .Select(method => new object?[] { method });
    }
}
