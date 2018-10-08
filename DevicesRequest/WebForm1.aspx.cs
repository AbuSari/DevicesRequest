using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevicesRequest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utilities.KSUHSDomainUser KSUHSobject = new Utilities.KSUHSDomainUser("kK24342", "kk24342");

            Response.Write(KSUHSobject.IsValid);
            Response.Write("<br/>");
            Response.Write(KSUHSobject.UserID);
            Response.Write("<br/>");
            Response.Write(KSUHSobject.UserNameEng);
            Response.Write("<br/>");
            Response.Write(KSUHSobject.emailID);

        }
    }
}