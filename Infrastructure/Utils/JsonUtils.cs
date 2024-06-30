using Newtonsoft.Json;

public static class JsonUtils
{
    public static T Deserialize<T>(string json)
    {
        var result = JsonConvert.DeserializeObject<T>(json);
        if (result == null)
        {
            throw new InvalidOperationException("Deserialization returned null");
        }
        return result;
    }
}
