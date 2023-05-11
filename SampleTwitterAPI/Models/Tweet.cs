using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleTwitterAPI.Models;
[Table("tweet")]
public class Tweet
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Comment("ID")]
    public int Id { get; set; }

    [Column("profile_id", TypeName = "int(11)")]
    [Comment("プロフィールID")]
    public int? ProfileId { get; set; }

    [Column("text", TypeName = "varchar(255)")]
    [Comment("ツイート内容")]
    public string? Text { get; set; }

    [Required]
    [Timestamp]
    [Column("created_at", TypeName = "timestamp")]
    [Comment("作成日時")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("ProfileId")]
    public Profile? Profile { get; set; }
}
