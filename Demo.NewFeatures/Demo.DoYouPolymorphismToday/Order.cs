using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DoYouPolymorphismToday
{
    class Order
    {
        public Order(Customer customer)
        {
            ID = Guid.NewGuid().ToString();
            m_Customer = customer;
            m_Products = new List<Product>();
        }

        public readonly string ID;

        private Customer m_Customer;

        private List<Product> m_Products;
        public void AddProduct(Product product)
        {
            m_Products.Add(product);
        }

        public double TotalAmount()
        {
            double totalAmount = 0.0;

            foreach (Product product in m_Products)
                totalAmount += product.Price;

            return totalAmount * m_Customer.Discount;
        }

        public override string ToString()
        {
            return $@"Dear {m_Customer.Name}
                   Total amount of order ID 
                    is {TotalAmount().ToString()}";
        }
    }

    internal abstract class Product
    {
        public abstract double Price { get; internal set; }
    }

    abstract class Customer
    {
        public abstract string Name { get; }

        public abstract double Discount { get; }
    }

    class SuperVipCustomer : Customer
    {
        public SuperVipCustomer(string name)
        {
            m_Name = name;
        }

        private string m_Name;
        public override string Name
        {
            get { return m_Name; }
        }

        private const double c_Discount = 0.65;
        public override double Discount
        {
            get { return c_Discount; }
        }

        public override string ToString()
        {
            return "Name: " + m_Name + "[SuperVip]";
        }
    }

    class VipCustomer : Customer
    {
        // Code here
        public override string Name => throw new NotImplementedException();

        public override double Discount => throw new NotImplementedException();
    }

    class NormalCustomer : Customer
    {
        // Code here
        public override string Name => throw new NotImplementedException();

        public override double Discount => throw new NotImplementedException();
    }
}
