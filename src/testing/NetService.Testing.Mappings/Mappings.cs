using System.Reflection;

namespace NetService.Testing.Mappings;

public static class Mappings
{
    public static IEnumerable<Type> GetMapperTypes(
        this IEnumerable<Assembly> assemblies,
        string mapperPostfix = "Mapper") =>
        from assembly in assemblies
        from type in assembly.GetTypes()
        where type.IsClass && type.Name.EndsWith(mapperPostfix)
        select type;

    public static IEnumerable<Type> GetMapperTypes(
        this Assembly assembly,
        string mapperPostfix = "Mapper") =>
        new[] { assembly }
            .GetMapperTypes(mapperPostfix);

    public static IEnumerable<MethodInfo> GetMapperMethods(
        this IEnumerable<Type> types,
        string mapPrefix = "MapTo") =>
        from type in types
        from method in type.GetMethods(
            BindingFlags.Static |
            BindingFlags.Public |
            BindingFlags.NonPublic)
        where method.Name.StartsWith(mapPrefix)
        select method;

    public static IEnumerable<MethodInfo> GetMapperMethods(
        this IEnumerable<Assembly> assemblies,
        string mapperPostfix = "Mapper",
        string mapPrefix = "MapTo") =>
        assemblies
            .GetMapperTypes(mapperPostfix)
            .GetMapperMethods(mapPrefix);

    public static IEnumerable<MethodInfo> GetMapperMethods(
        this Assembly assembly,
        string mapperPostfix = "Mapper",
        string mapPrefix = "MapTo") =>
        new[] { assembly }
            .GetMapperMethods(mapperPostfix, mapPrefix);
}
