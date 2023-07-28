using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using Models.BlockTypes;
using Models.MediaTypes;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Models.PageTypes
{
  [ContentType(
      GroupName = "Pages",
      Order = 100,
      DisplayName = "Settings page",
      GUID = "9F73160F-6839-4285-8A27-05F90DD700FD")]
  public class SettingsPageTypeModel : BasePage
  {
    [CultureSpecific]
    [Display(
        Name = "Very Important Secret",
        Order = 10)]
    public virtual string? VeryImportantSecret { get; set; }

    [ScaffoldColumn(false)]
    public override string ComponentName => "SettingsPage";
  }
}