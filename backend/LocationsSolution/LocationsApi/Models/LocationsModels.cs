namespace LocationsApi.Models;

public record LocationsResponse
{
    public List<LocationItemResponse> _embedded { get; set; } = new();
}
public record LocationItemResponse
{
    public string Id { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string AddedBy { get; init; } = string.Empty;
    public DateTime AddedOn { get; init; }
}