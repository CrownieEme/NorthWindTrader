using NorhtWindTraders.App_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorhtWindTraders.Cust
{
    public partial class frmCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                GetCategories();
            }
        }

        private void GetCategories()
        {
            CategoryBL CatBL = new CategoryBL();
            this.grdCategories.DataSource = CatBL.GetCategories();
            this.grdCategories.DataBind();
        }
    }
}