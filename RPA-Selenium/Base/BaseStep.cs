using RPAFramework.Config;
using RPAFramework.Helpers;

namespace RPAFramework.Base
{
    public abstract class BaseStep : Base
    {
        
        public virtual void NavigateSite(string url)
        {
            DriverContext.Browser.GoToUrl(url);
            LogHelpers.Write("Opened the browser !!!");
        }
    }
}
