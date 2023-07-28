using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace Models.BlockTypes
{
  [ContentType(
      GroupName = "Blocks",
      Order = 1,
      DisplayName = "Text block",
      GUID = "D6445D92-F388-4939-9CFC-D1562182D744")]
  public class TextBlockTypeModel : BlockData
  {
    [CultureSpecific]
    [Display(
        Name = "Heading",
        Order = 10)]
    public virtual string Heading { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Text body",
        Order = 30)]
    public virtual XhtmlString TextBody { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Block link",
        Order = 40)]
    public virtual LinkItem Link { get; set; }

    [CultureSpecific]
    [Display(
      Name = "Just a secret",
      Order = 9000)]
    public virtual string? Private_BlockTest { get; set; }
  }
}