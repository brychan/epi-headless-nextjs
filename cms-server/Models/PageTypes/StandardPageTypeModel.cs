using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using Models.BlockTypes;
using Models.MediaTypes;
using System.ComponentModel.DataAnnotations;

namespace Models.PageTypes
{
  [ContentType(
      GroupName = "Pages",
      Order = 1,
      DisplayName = "Standard page",
      GUID = "580d24b7-1622-4a3b-b309-72adbbbd49c8")]
  public class StandardPageTypeModel : BasePage
  {
    [CultureSpecific]
    [Display(
        Name = "Heading",
        Order = 10)]
    public virtual string Heading { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Page link",
        Order = 20)]
    public virtual ContentReference Link { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Text body",
        Order = 30)]
    public virtual EPiServer.Core.XhtmlString TextBody { get; set; }

    [CultureSpecific]
    [Display(
      Name = "Content blocks",
      Description = "Put all content as blocks of information",
      Order = 40)]
    [AllowedTypes(
        typeof(TextBlockTypeModel),
        typeof(TextAndImageBlockTypeModel))]
    public virtual ContentArea? ContentBlocks { get; set; }

    [ScaffoldColumn(false)]
    public override string ComponentName => "StandardPage";
  }
}