using System;

namespace DTOs;

public class AlbumDTO
{
    public long Id { get; set;}
    public string? Name { get; set; }
    public DateTime CreationDate { get; set; }
    public Visibility Visibility { get; set; }
    public long CreatorId { get; set; }

}
