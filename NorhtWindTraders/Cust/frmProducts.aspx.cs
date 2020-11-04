using NorhtWindTraders.App_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorhtWindTraders.Cust
{
    public partial class frmProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (this.CategoryID == 0)
                {
                    getProducts(1);
                    getCategoriesMenu();
                }
                else
                {                    
                    getCategoriesMenu();
                    getProducts(this.CategoryID);
                }
            }
        }

        public int CategoryID
        {
            get
            {
                if (Request.QueryString["cid"] != null)
                {
                    return Convert.ToInt32(Request.QueryString["cid"]);
                }
                else
                    return 0;
            }
        }
        private void getCategoriesMenu()
        {
            CategoryRepository cat = new CategoryRepository();
            string HtmlCode = "";

            foreach (var c in cat.GetCategories())
            {

                HtmlCode += "<a href=\"frmProducts.aspx?cid=" + (c.CategoryID.ToString()) + "\" class=\"list-group-item\">" + c.CategoryName + "</a>";
            }
            this.litHtmlCatCode.Text = HtmlCode;
        }

        private void getProducts(int catid)
        {
            ProductRepository prod = new ProductRepository();
            string HtmlCode = "";

            foreach (var p in prod.GetProductByCategoryID(catid))
            {

                HtmlCode += "<div class=\"row\">"
                                + "<div class=\"col-lg-9 col-md-6\">"
                                + "<div class=\"col-md-2\">"
                                + "<img src=\"../Content/images/Products/" + p.ProductID + ".jpg \" class=\"img-rounded\" style=\"width: 100px\" />"
                                + "</div>"
                                + "<div class=\"col-md-7\">"
                                + "<a href=<a href=\"frmProduct.aspx?pid=" + p.ProductID + "\"><h3>" + p.ProductName + "</h3></a>"
                                + "<hr />"
                                + "<h4>Price: $" + Convert.ToDecimal(p.UnitPrice).ToString(("#,##0.00")) + "</h4>"
                                + "</div>"
                                + "</div>"
                                + "<div class=\"col-md-3\"><br /> <br />"
                                + "<p><a href=\"frmProduct.aspx?pid=" + p.ProductID + "\" class=\"btn btn-primary btn-lg\" role=\"button\">Details</a></div></div><hr />";
            }

            this.litHtmlProdCode.Text = HtmlCode;
        }
    }
}