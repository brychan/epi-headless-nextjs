using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.ContentApi.Core.Serialization.Internal;
using EPiServer.ContentApi.Core.Serialization.Models;
using EPiServer.ContentApi.Core.Serialization;
using EPiServer.ServiceLocation;
using Microsoft.AspNetCore.Http;

[ServiceConfiguration(typeof(IContentApiModelFilter), Lifecycle = ServiceInstanceScope.Singleton)]
internal class CustomContentApiModelFilter : ContentApiModelFilter<ContentApiModel>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CustomContentApiModelFilter(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override void Filter(ContentApiModel contentApiModel, ConverterContext converterContext)
    {
    /*
     * Idea to filter all properties in the Json if it's a specific page that we want to keep private.
     */
    if (contentApiModel != null 
        && contentApiModel.ContentType != null 
        && contentApiModel.ContentType[0] == "Page" 
        && contentApiModel.ContentType[1] == "SettingsPageTypeModel")
      {
        contentApiModel.Changed = null;
        contentApiModel.Created = null;
        contentApiModel.ExistingLanguages = null;
        contentApiModel.Language = null;
        contentApiModel.MasterLanguage = null;
        contentApiModel.Name = null;
        contentApiModel.ParentLink = null;
        contentApiModel.RouteSegment = null;
        contentApiModel.Saved = null;
        contentApiModel.StartPublish = null;
        contentApiModel.Status = null;
        contentApiModel.StopPublish = null;
        contentApiModel.Url = null;
        contentApiModel.Properties = new Dictionary<string, object>();
    }


    /*
     * Bit adapted from https://docs.developers.optimizely.com/content-management-system/v1.5.0-content-delivery-api/docs/how-to-customize-data-returned-to-clients to .NET 6
     */
    //var httpContext = _httpContextAccessor.HttpContext;
    //if (httpContext == null)
    //{
    //    // Handle the case when HttpContext is not available (e.g., when not running in the context of a web request)
    //    return;
    //}

    //var selectedValues = httpContext.Request.Query["select"];
    //if (selectedValues.Count == 0)
    //{
    //    // No "select" query parameter present, return without filtering
    //    return;
    //}

    //var selectedParamValue = selectedValues.ToString();
    //var selectedProperties = string.IsNullOrWhiteSpace(selectedParamValue)
    //    ? new HashSet<string>()
    //    : new HashSet<string>(selectedParamValue.Split(',').Select(x => x.Trim()), StringComparer.OrdinalIgnoreCase);

    //try
    //{
    //    var dictProp = new Dictionary<string, object>();
    //    contentApiModel.Properties = contentApiModel.Properties.Where(entry => selectedProperties.Contains(entry.Key))
    //                                                             .ToDictionary(entry => entry.Key, entry => entry.Value);

    //    // Set those values below as null, and configure ContentApiOption.IncludeNullValues = false in Initialization
    //    // then, response data will not include those ones.
    //    contentApiModel.ExistingLanguages = null;
    //    contentApiModel.MasterLanguage = null;
    //    contentApiModel.ParentLink = null;
    //    contentApiModel.Language = null;
    //    contentApiModel.StartPublish = null;
    //    contentApiModel.StopPublish = null;
    //}
    //catch (Exception ex)
    //{
    //    // Properly handle exceptions, e.g., log the error or throw an appropriate custom exception
    //    Console.WriteLine(ex.Message);
    //}
  }
}
