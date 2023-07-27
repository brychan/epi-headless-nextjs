using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using Models.MediaTypes;
using Models.BlockTypes;
using System.ComponentModel.DataAnnotations;

namespace Models.PageTypes
{
  [ContentType(
      GroupName = "Special pages",
      Order = 1,
      DisplayName = "Start page",
      GUID = "a0811d15-e0cd-40b6-a5bb-323cdf12b1b0")]
  public class StartPageTypeModel : BasePage
  {
    [CultureSpecific]
    [Display(
        Name = "Site name",
        Order = 10)]
    public virtual string SiteName { get; set; }

    [CultureSpecific]
    [Display(
    Name = "Hero heading",
    Order = 10)]
    public virtual string HeroHeading { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Hero Image",
        Order = 20)]
    [UIHint(UIHint.Image)]
    [AllowedTypes(typeof(ImageFileTypeModel))]
    public virtual ContentReference HeroBackgroundImage { get; set; }

    [CultureSpecific]
    [Display(
      Name = "Content blocks",
      Description = "Put all content as blocks of information",
      Order = 40)]
    [AllowedTypes(
      typeof(TextAndImageBlockTypeModel))]
    public virtual ContentArea? ContentBlocks { get; set; }

    [CultureSpecific]
    [Display(
      Name = "Top menu links",
      Description = "Links to display in the menu",
      Order = 500)]
    public virtual LinkItemCollection? MenuLinks { get; set; }

    [ScaffoldColumn(false)]
    public override string ComponentName => "StartPage";
  }
}