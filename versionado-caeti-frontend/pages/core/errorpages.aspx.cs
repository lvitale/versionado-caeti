using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace versionado_caeti_frontend.pages.core
{
    public partial class errorpages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String mensaje=(String)HttpContext.Current.Session["message"];
            if (mensaje != null) {
                txtError.Text = mensaje;
            }
        }
    }
}