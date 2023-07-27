using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using Models.BlockTypes;

namespace Models.MediaTypes
{
  [ContentType(GUID = "868493e9-062f-49fd-98e0-6580dbf17ce7")]
  [MediaDescriptor(ExtensionString = "jpg,jpeg,png,gif")]
  public class ImageFileTypeModel : ImageData
  {
    [CultureSpecific]
    public virtual string AltText { get; set; }
  }

}