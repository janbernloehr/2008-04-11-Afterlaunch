using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;

public partial class _06___Lokalisierung_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture(selectLanguage.SelectedValue);
        }
        else
        {
            selectLanguage.Items.FindByValue(System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName).Selected = true;
        }
    }

    protected void selectLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture(selectLanguage.SelectedValue);
    }

}
