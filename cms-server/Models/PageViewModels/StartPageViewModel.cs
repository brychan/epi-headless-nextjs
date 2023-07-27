using Models.PageTypes;

namespace Models.PageViewModels
{
  public class StartPageViewModel
  {
    private readonly StartPageTypeModel _startPageType;

    public StartPageViewModel(StartPageTypeModel startPageType)
    {
      this._startPageType = startPageType;
    }
    public string SiteName => _startPageType.SiteName;
  }
}