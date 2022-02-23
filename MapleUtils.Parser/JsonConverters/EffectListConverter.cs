using MapleUtils.Parser.Constants;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MapleUtils.Parser.JsonConverters
{
    public class EffectListConverter : JsonConverter<IList<(StatEnum, int)>>
    {
        public override IList<(StatEnum, int)> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, IList<(StatEnum, int)> list, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            foreach (var item in list)
            {
                writer.WriteStartObject();
                writer.WriteNumber(item.Item1.ToString(), item.Item2);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }
    }
}
