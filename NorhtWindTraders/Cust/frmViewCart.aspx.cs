using NorhtWindTraders.App_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorhtWindTraders.Cust
{
    public partial class frmViewCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PageItems();
            }
        }

        private void PageItems()
        {
            getCategoriesMenu();
            if (this.ProductID > 0)
            {
                AddToCart();
                getProductsFromCart();
                getProductQty(this.ProductID);
                this.ddlQty.SelectedValue = this.Quantity.ToString();
                this.TotalinCart.Text = this.ddlQty.SelectedValue;
                UpdateOrders();


            }
            else
            {
                CartRepository repo = new CartRepository();
                string htmlCode_1 = "", htmlCode_2 = "";
                foreach (var i in repo.GetCartItems())
                {
                    htmlCode_1 += "<hr /><div class=\"row \">"
                                 + "<div class=\"col-lg-2 col-md-2 col-md-2\">"
                                 + "<img src=\"../Content/images/Products/" + i.ProductID + ".jpg\" style=\"width:80px; height:120px\" class=\"img-thumbnail\"/></div>"
                                 + "<div class=\"col-lg-1 col-md-2 col-sm-2\"><p>" + i.ProductName + "</p></div>"
                                 


                   + "<div class=\"col-lg-1 col-md-2 col-sm-2\"><i class=\"fa fa-times\"></i></div>"
                                 + "<div class=\"col-lg-2 col-md-1 col-sm-1\"><p>" + Convert.ToDecimal(i.UnitPrice).ToString(("#,##0.00")) + "</p></div>"
                                 + "<div class=\"col-lg-1 col-md-2 col-sm-2\">"
                                 + "<button type=\"button\" class=\"btn btn-danger btn-circle btn-sm\">"
                                 + "<i class=\"fa fa-trash-o fa-sm\"></i></button></div>";

                }
                this.litHTML_1.Text = htmlCode_1;
                //this.litHTML_2.Text = htmlCode_2;
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

        public int Quantity
        {
            get
            {
                if (Request.QueryString["qty"] != null)
                {
                    return Convert.ToInt32(Request.QueryString["qty"]);
                }
                else
                    return 0;
            }
        }

        public void getProductQty(int prodId)
        {
            ProductRepository prod = new ProductRepository();
           
            var p = prod.GetProduct(prodId);

            List<ListItem> item = new List<ListItem>();

            for (int i = 0; i < Convert.ToInt32(p.UnitsInStock) - 1; i++)
            {
                item.Add(new ListItem((i + 1).ToString(), (i + 1).ToString()));
            }
            this.ddlQty.Items.AddRange(item.ToArray());
 
        }
        
        private void AddToCart()
        {
            CartRepository repo = new CartRepository();
            Cart items = new Cart();
            var product = repo.GetProduct(this.ProductID);
            items.ProductID = product.ProductID;
            items.ProductName = product.ProductName;
            items.ProductQuantity = Convert.ToInt16(this.Quantity);
            items.UnitPrice = product.UnitPrice;

            repo.InsertProductToCart(items);
        }

        private void getProductsFromCart()
        {   CartRepository repo = new CartRepository();
            if (this.ProductID < 0)
            {
                
                string htmlCode_1 = "", htmlCode_2 = "";
                foreach (var i in repo.GetCartItems())
                {
                    htmlCode_1 += "<hr /><div class=\"row \">"
                                 + "<div class=\"col-lg-2 col-md-2 col-md-2\">"
                                 + "<img src=\"../Content/images/Products/" + i.ProductID + ".jpg\" style=\"width:80px; height:120px\" class=\"img-thumbnail\"/></div>"
                                 + "<div class=\"col-lg-1 col-md-2 col-sm-2\"><p>" + i.ProductName + "</p></div>"
                                 + "<div class=\"col-lg-2 col-md-2 col-sm-2\">"


                   + "<div class=\"col-lg-1 col-md-2 col-sm-2\"><i class=\"fa fa-times\"></i></div>"
                                 + "<div class=\"col-lg-2 col-md-1 col-sm-1\"><p>" + Convert.ToDecimal(i.UnitPrice).ToString(("#,##0.00")) + "</p></div>"
                                 + "<div class=\"col-lg-1 col-md-2 col-sm-2\">"
                                 + "<button type=\"button\" class=\"btn btn-danger btn-circle btn-sm\">"
                                 + "<i class=\"fa fa-trash-o fa-sm\"></i></button>";

                }
                this.litHTML_1.Text = htmlCode_1;//this.litHTML_2.Text = htmlCode_2;
            }
            
        }


        protected void  UpdateOrders()
        {
            CartRepository repo = new CartRepository();
            foreach (var i in repo.GetCartItems())
            {
                decimal qtyofItem;
                qtyofItem = decimal.Parse(this.ddlQty.SelectedValue);
                decimal total = Convert.ToDecimal(i.UnitPrice) * qtyofItem;
                this.TotalinCart.Text = total.ToString(("#,##0.00"));
            }

       
        }
        protected void Update(object sender, EventArgs e)
        {
            CartRepository repo = new CartRepository();
            foreach (var i in repo.GetCartItems())
            {
                decimal qtyofItem;
                qtyofItem = decimal.Parse(this.ddlQty.SelectedValue);
                decimal total = Convert.ToDecimal(i.UnitPrice) * qtyofItem;
                this.TotalinCart.Text = total.ToString(("#,##0.00"));
            }


        }

        protected void PlaceOrders(object sender, EventArgs e)
        {
            CartRepository repo = new CartRepository();
            foreach (var i in repo.GetCartItems())
            {
                decimal qtyofItem;
                qtyofItem = decimal.Parse(this.ddlQty.SelectedValue);
                decimal total = Convert.ToDecimal(i.UnitPrice) * qtyofItem;
                this.TotalinCart.Text = total.ToString(("#,##0.00"));
            }


        }

    }
}