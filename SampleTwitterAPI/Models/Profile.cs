using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SampleTwitterAPI.Models;
[Table("profile")]
public class Profile
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Comment("ID")]
    public int Id { get; set; }

    [Column("twitter_id", TypeName = "varchar(50)")]
    [Comment("ツイッターID")]
    public string? TwitterId { get; set; }

    [Column("name", TypeName = "varchar(255)")]
    [Comment("名前")]
    public string? Name { get; set; }

    [Column("profile_img", TypeName = "varchar(255)")]
    [Comment("プロフィール画像")]
    public string? ProfileImg { get; set; }

    [Column("profile_bg_img", TypeName = "varchar(255)")]
    [Comment("プロフィール背景画像")]
    public string? ProfileBgImg { get; set; }

    [Column("profile_text", TypeName = "varchar(255)")]
    [Comment("プロフィール文")]
    public string? ProfileText { get; set; }

    [Column("follow_count", TypeName = "int(11)")]
    [Comment("フォロー数")]
    public int? FollowCount { get; set; }

    [Column("follower_count", TypeName = "int(11)")]
    [Comment("フォロワー数")]
    public int? FollowerCount { get; set; }

    [Required]
    [Timestamp]
    [Column("created_at", TypeName = "timestamp")]
    [Comment("作成日時")]
    public DateTime CreatedAt { get; set; }
}
