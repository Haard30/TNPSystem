using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TnpSystem.CoordinatorPortal
{
    public partial class ViewDocs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string FilePath = null;

            FilePath = Request.QueryString["fn"];

            if (FilePath != null)
            {
                string path = Server.MapPath(FilePath);
                Image1.ImageUrl = FilePath;
            }
            else
            {
                Response.Write("No Document Uploaded");
            }
        }
    }
}