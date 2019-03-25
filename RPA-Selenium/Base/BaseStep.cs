using RPAFramework.Config;
using RPAFramework.Helpers;

namespace RPAFramework.Base
{
    public abstract class BaseStep : Base
    {
        
        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.Aut);
            LogHelpers.Write("Opened the browser !!!");
        }
    }
}
