using MapleUtils.Parser.Constants;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace MapleUtils.Parser.JsonConverters
{
    internal class EffectTupleConverter : JsonConverter<(StatEnum, int)?>
    {
        public override (StatEnum, int)? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, (StatEnum, int)? value, JsonSerializerOptions options)
        {
            if (!value.HasValue)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStartArray();
                writer.WriteStartObject();
                writer.WriteNumber(value.Value.Item1.ToString(), value.Value.Item2);
                writer.WriteEndObject();
                writer.WriteEndArray();
            }

        }
    }
}
