using NorhtWindTraders.App_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorhtWindTraders.Cust
{
    public partial class frmProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                getProduct(this.ProductID);
            }
        }

        public int ProductID
        {
            get
            {
                if (Request.QueryString["pid"] != null)
                {
                    return Convert.ToInt32(Request.QueryString["pid"]);
                }
                else
                    return 0;
            }
        }

        public void getProduct(int prodId)
        {
            ProductRepository prod = new ProductRepository();
            string HtmlCode = "";
            
            var p = prod.GetProduct(prodId);

            List<ListItem> item = new List<ListItem>();
            
            for (int i = 0; i < Convert.ToInt32(p.UnitsInStock)-1;i++ )
            {
                item.Add(new ListItem((i + 1).ToString(),(i + 1).ToString()));
            }
            this.ddlQty.Items.AddRange(item.ToArray());

            HtmlCode = "<div class=\"col-lg-3 col-md-3 col-sm-2 col-md-offset-4\">"
                            + "<img src=\"../Content/images/Products/" + p.ProductID + ".jpg\" style=\"width: 150px\" />"
                            + "</div>"
                            + "<div class=\"col-lg-3 col-md-3 col-sm-2\">"
                            + "<h2>" + p.ProductName + "</h2>"
                            + "<hr />"
                            + "<p>Details: " + p.QuantityPerUnit + "</p>"
                            + "<p>Select Quantity: ";

            this.litHtmlCode_1.Text = HtmlCode;

            
            HtmlCode = "<p>Price: $<b>" + Convert.ToDecimal(p.UnitPrice).ToString(("#,##0.00")) + "</b></p><hr />";
                          
            this.litHtmlCode_3.Text = HtmlCode;
                
        }

        protected void btnCart_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("frmViewCart.aspx?pid=" + Request.QueryString["pid"] + "&qty=" + this.ddlQty.SelectedValue);
        }

       

       
    }
}