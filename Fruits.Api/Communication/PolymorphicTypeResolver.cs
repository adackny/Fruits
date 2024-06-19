using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Fruits.Api;

public class PolymorphicTypeResolver : DefaultJsonTypeInfoResolver
{
    public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
    {
        //JsonTypeInfo jsonTypeInfo = base.GetTypeInfo(type, options);

        //Error o = new ValidationError(null, null, null);

        //Type baseErrorType = typeof(Error);
        //if (jsonTypeInfo.Type == baseErrorType)
        //{
        //    var errorDerivedTypes = typeof(Error).Assembly
        //        .GetTypes()
        //        .Where(t => t.IsAssignableTo(baseErrorType))
        //        .Select(t => new JsonDerivedType(t));

        //    jsonTypeInfo.PolymorphismOptions = new JsonPolymorphismOptions
        //    {
        //        IgnoreUnrecognizedTypeDiscriminators = true,
        //        UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization,
        //    };

        //    foreach (var derived in errorDerivedTypes)
        //    {
        //        jsonTypeInfo.PolymorphismOptions.DerivedTypes.Add(derived);
        //    }
        //}

        //return jsonTypeInfo;

        return base.GetTypeInfo(type, options);
    }
}
