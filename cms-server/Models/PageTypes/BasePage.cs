using EPiServer.Core;

namespace Models.PageTypes
{
  public abstract class BasePage : PageData
  {
    public abstract string ComponentName { get; }
  }
}