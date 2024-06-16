using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class DateTimeConverter : JsonConverter<DateTime>
{
    private const string Format = "dd-MM-yyyy"; // Adjust to match your specific format if needed

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if(reader.TokenType == JsonTokenType.String && DateTime.TryParse(reader.GetString(), out DateTime value))
        {
            return value;
        }

        throw new JsonException($"Unable to convert \"{reader.GetString()}\" to {typeof(DateTime)}");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format));
    }
}
