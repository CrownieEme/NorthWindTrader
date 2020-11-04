using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorhtWindTraders.App_DAL;
using System.Collections;

namespace NorhtWindTraders
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetDeals();
            }
        }

        private void GetDeals()
        {
            ProductRepository prod = new ProductRepository();

            string HtmlCode = "";

            foreach (var p in prod.GetProductDeals(6))
            {

                HtmlCode += "<div class=\"col-lg-4 col-sm-4 hero-feature text-center\">"
                                + "<div class=\"thumbnail\">"
                                + "<h5><b>" + p.ProductName + "<b></h5>"
                                + "<a href=\"#\" class=\"link-p\" style=\"overflow: hidden;\">"
                                + "<img src=\"Content/images/Products/" + p.ProductID + ".jpg\" class=\"img-thumbnail\" ></a></img>"
                                + "<a href=\"#\">Details:" + p.QuantityPerUnit + "</a>"
                                + "<br />"
                                + "<p>Price: $" + Convert.ToDecimal(p.UnitPrice).ToString(("#,##0.00")) + "</p>"
                                + "<a class=\"btn btn-info\" href=\"/Cust/frmProduct.aspx?pid="+p.ProductID+"\">Details</a></div></div>";

            }

            this.litHtmlCode.Text = HtmlCode;
        }
    }
}

