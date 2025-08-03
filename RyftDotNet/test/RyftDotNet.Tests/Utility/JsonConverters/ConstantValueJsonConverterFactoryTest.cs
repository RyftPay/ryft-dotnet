using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Utility.JsonConverters;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Utility.JsonConverters
{
    public sealed class ConstantValueJsonConverterFactoryTest
    {
        private readonly ConstantValueJsonConverterFactory factory = new ConstantValueJsonConverterFactory();

        [Theory, MemberData(nameof(AllConstantValueTypes))]
        public void CanConvert_ShouldReturnTrue_ForConstantValueSubType(Type type)
            => factory.CanConvert(type).ShouldBeTrue();

        [Theory, MemberData(nameof(AllConstantValueTypes))]
        public void CreateConverter_ShouldWork_ForConstantValueSubType(Type type)
        {
            Func<JsonConverter> action = () => factory.CreateConverter(type, JsonSerializerOptions.Default);
            action.ShouldNotThrow();
        }

        public static TheoryData<Type> AllConstantValueTypes()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(d => d.GetTypes())
                .Where(type => typeof(ConstantValue).IsAssignableFrom(type) && type != typeof(ConstantValue));
            var data = new TheoryData<Type>();
            foreach (var type in types)
            {
                data.Add(type);
            }
            return data;
        }
    }
}
