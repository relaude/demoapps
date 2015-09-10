using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Northwind
{
    public class Categories
    {
        [Key]// Primary key 
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte?[] Picture { get; set; }
    }

    public class Products
    {
        [Key]// Primary key
        public int ProductID { get; set; } 

        public string ProductName { get; set; }
        public int? SupplierID { get; set; }

        // Foreign key 
        public int? CategoryID { get; set; }

        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }

    public class Customers
    {
        [Key]// Primary key 
        public string CustomerID { get; set; }

        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        // Navigation property 
        public virtual ICollection<Orders> Orders { get; set; }
    }

    public class Orders
    {
        [Key]// Primary key 
        public int OrderID { get; set; }

        // Foreign key 
        public string CustomerID { get; set; }

        // Foreign key 
        public int? EmployeeID { get; set; }

        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        // Navigation properties
        public virtual Customers Customers { get; set; }

        // Navigation property 
        public virtual ICollection<Order_Details> Order_Details { get; set; }
    }

    [Table("Order Details")]
    public class Order_Details
    {
        [Key, Column(Order = 1)]// Foreign key 
        public int OrderID { get; set; }

        [Key, Column(Order = 2)]// Foreign key 
        public int ProductID { get; set; }

        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public decimal Discount { get; set; }

        // Navigation properties
        public virtual Orders Orders { get; set; }
        public virtual Products Products { get; set; }
    }
}
