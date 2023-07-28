using EPiServer.ContentApi.Core.Serialization.Internal;
using EPiServer.ContentApi.Core.Serialization;
using EPiServer.ServiceLocation;
using Models.PageTypes;
using EPiServer.Web.Routing;
using EPiServer.Core.Internal;

[ServiceConfiguration(typeof(IContentFilter), Lifecycle = ServiceInstanceScope.Singleton)]
internal class CustomContentFilter : ContentFilter<IContent>
{

  public override void Filter(IContent content, ConverterContext converterContext)
  {
    /*
     * Idea to filter all CMS Properties that contain "Private_" from being sent in the response.
     * This filter runs before the CustomContentApiModelFilter.
     */
    var properties = content.Property.ShallowCopy();
    foreach(var property in properties.Where(property => property.Name.Contains("Private_")))
    {
      content.Property.Remove(property.Name);
    }
  }
}
