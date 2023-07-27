using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using Models.MediaTypes;

namespace Models.BlockTypes
{
  [ContentType(
      GroupName = "Blocks",
      Order = 1,
      DisplayName = "Text and Image block",
      GUID = "1DE3940F-4E69-4A59-B467-0CCF07E443EF")]
  public class TextAndImageBlockTypeModel : BlockData
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
        Name = "Image",
        Order = 20)]
    [UIHint(UIHint.Image)]
    [AllowedTypes(typeof(ImageFileTypeModel))]
    public virtual ContentReference BlockImage { get; set; }
  }
}