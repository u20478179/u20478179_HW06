using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using HW06.Models;
using PagedList.Mvc;
using PagedList;
using System.Xml.Linq;

namespace HW06.Models
{
    public class ViewModel
    {

        public IEnumerable<HW06.Models.order> ListOrders { get; set; }
        public IEnumerable<HW06.Models.order_items> Listitems { get; set; }

        public int order_id { get; set; }
        public Nullable<int> customer_id { get; set; }
        public byte order_status { get; set; }
        public System.DateTime order_date { get; set; }
        public System.DateTime required_date { get; set; }
        public Nullable<System.DateTime> shipped_date { get; set; }
        public int store_id { get; set; }
        public int staff_id { get; set; }

        public int product_id { get; set; }
        public string product_name { get; set; }
        public int brand_id { get; set; }
        public int category_id { get; set; }
        public short model_year { get; set; }
        public decimal list_price { get; set; }


        //public List<order> Orders { get; set; }

        //public List<order_items> Items { get; set; }







        //public ViewModel(IEnumerable<order> listOrders)
        //{
        //    Orders = new List<order>();
        //    Items = new List<order_items>();
        //    ListOrders = listOrders;
        //    foreach (var order in listOrders)
        //    {
        //        if (!Orders.Contains(order.order_id))
        //        {
        //            Orders.Add(order.order_id);
        //        }
        //        if (!Items.Contains(order.order_id))
        //        {
        //            Items.Add(order.order_id);
        //        }
        //    }
        //}
    }
}