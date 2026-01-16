using System.ComponentModel.DataAnnotations.Schema;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities;

[Table("records")]
public class Record : WithOwnerEntity, IRecord
{
    [Column("record_id")] public int Id { get; set; }
    [Column("code")] public string Code { get; set; } = string.Empty;
    [Column("name")] public string? Title { get; set; }
    [Column("description")] public string? Description { get; set; }
    [Column("external_link")] public string? ExternalLink { get; set; }
    [Column("category_id")] public int? CategoryId { get; set; }
    public IEnumerable<Period>? Periods { get; set; }

    public Category? Category { get; set; }
    public RecordMeta? Meta { get; set; }
}