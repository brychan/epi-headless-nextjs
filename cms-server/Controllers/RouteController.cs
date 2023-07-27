using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;
using Models.PageTypes;
using System.Collections.Generic;
using System.Text.Json;
using EPiServer.Core.Internal;
using EPiServer.Filters;
using SixLabors.ImageSharp;
using EPiServer.DataAbstraction;
using EPiServer.DataAbstraction.Internal;
using EPiServer.Globalization;
using EPiServer.Framework.Localization;
using EPiServer.ServiceLocation;
using EPiServer.Cms.Shell;

namespace Controllers
{
  [Route("routes")]
  [ApiController]
  public class RouteController : ControllerBase
  {
    private readonly IContentLoader _contentLoader;
    private readonly IUrlResolver _urlResolver;
    private readonly IContentRepository _contentRepository;

    public RouteController(
        IContentLoader contentLoader,
        IUrlResolver urlResolver,
        IContentRepository contentRepository)
    {
      _contentLoader = contentLoader;
      _urlResolver = urlResolver;
      _contentRepository = contentRepository;
    }

    [HttpGet("get")]
    public IActionResult GetRoutes()
    {
      var startPageData = _contentRepository.Get<IContent>(ContentReference.StartPage) as ILocalizable;

      var availableLanguages = startPageData?.ExistingLanguages;

      var pagesList = new List<PageData>();

      foreach(var language in availableLanguages)
      {
        var startPage = _contentLoader.Get<PageData>(ContentReference.StartPage, language);
        var startPageChildren = _contentLoader.GetChildren<PageData>(ContentReference.StartPage, language).ToList();
        pagesList.Add(startPage);
        pagesList.AddRange(startPageChildren);
      }
         
      var routes = pagesList
          .Select(pageData =>
          {
            var absoluteUrl = _urlResolver.GetUrl(pageData);
            var uri = new Uri(absoluteUrl);
            var hostName = uri.GetLeftPart(UriPartial.Authority);
            var relativeUrl = absoluteUrl.Remove(absoluteUrl.IndexOf(hostName), hostName.Length);

            return new
            {
              PageName = pageData.Name,
              VirtualPath = relativeUrl
            };
          });

      return Ok(routes);
    }
  }
}
