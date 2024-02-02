using System.ComponentModel.DataAnnotations;

namespace LinkCutter.Models;

public class Link
{
    [Key]
    public long Id { get; set; }

    public string FullLink { get; set; } = null!;
}