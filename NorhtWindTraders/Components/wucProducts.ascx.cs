using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorhtWindTraders.App_DAL;

namespace NorhtWindTraders.Components
{
    public partial class wucProducts : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetProductsByCat(1);
            }
        }

        public void GetProductsByCat(int catid)
        {
            ProductRepository prod = new ProductRepository();
            this.DataList1.DataSource = prod.GetProductByCategoryID(catid);
            this.DataList1.DataBind();

        }
    }
}