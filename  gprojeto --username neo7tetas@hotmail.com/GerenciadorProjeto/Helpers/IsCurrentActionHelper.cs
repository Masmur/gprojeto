using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;

namespace System.Web.Mvc.Html
{
    public static class ActionHelper
    {
        public static bool IsCurrentAction(this HtmlHelper helper, string actionName, string controllerName)
        {
            string currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];
            string currentActionName = (string)helper.ViewContext.RouteData.Values["action"];

            if (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase) && currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase))
                return true;

            return false;
        }

        public static bool IsCurrentAction(this HtmlHelper helper, string controllerName)
        {
            string currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];

            if (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase))
                return true;

            return false;
        }

        public static string RenderMenu(this HtmlHelper helper, string actionName, string controllerName)
        {
            return null;
        }

        public class ActionHelperMenuItem
        {
            private String _LinkText;
            private String _ControllerAction;
            private String _CssClass;
            private object[] _RouteValues;

            public String LinkText
            {
                get { return this._LinkText; }
                set { this._LinkText = value; }
            }

            public String ControllerAction
            {
                get { return this._ControllerAction; }
                set { this._ControllerAction = value; }
            }

            public String CssClass
            {
                get { return this._CssClass; }
                set { this._CssClass = value; }
            }

            public object[] RouteValues
            {
                get { return this._RouteValues; }
                set { this._RouteValues = value; }
            }

        }
    }

}
