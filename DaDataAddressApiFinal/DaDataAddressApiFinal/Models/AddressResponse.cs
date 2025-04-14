using System.Text.Json.Serialization;

public class AddressResponse
{
    [JsonPropertyName("source")]
    public string Source { get; set; } = string.Empty;

    [JsonPropertyName("result")]
    public string Result { get; set; } = string.Empty;

    [JsonPropertyName("postal_code")]
    public string PostalCode { get; set; } = string.Empty;

    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    [JsonPropertyName("region")]
    public string Region { get; set; } = string.Empty;

    [JsonPropertyName("city")]
    public string City { get; set; } = string.Empty;

    [JsonPropertyName("settlement")]
    public string? Settlement { get; set; } = string.Empty;

    [JsonPropertyName("street")]
    public string Street { get; set; } = string.Empty;

    [JsonPropertyName("house")]
    public string House { get; set; } = string.Empty;

    [JsonPropertyName("flat")]
    public string? Flat { get; set; }

    
}
