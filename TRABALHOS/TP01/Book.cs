using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

//Matheus Penteado CB3031501
//Joao Victor Sinopolli 3032094

namespace TP01
{
    internal class Book
    {
        private string name;
        private Author[] auths;
        private double price;
        private int qty = 0;

        public Book(string name, Author[] auths, double price)
        {
            this.name = name;
            this.auths = auths;
            this.price = price;
        }

        public Book(string name, Author[] auths, double price, int qty)
        {
            this.name = name;
            this.auths = auths;
            this.price = price;
            this.qty = qty;
        }

        public string getName()
        {
            return name;
        }

        public Author[] getAuthors()
        {
            return auths;
        }

        public double getPrice()
        {
            return price;
        }

        public void setPrice(double price)
        {
            this.price = price;
        }

        public int getQty()
        {
            return qty;
        }

        public void setQty(int qty)
        {
            this.qty = qty;
        }

        public override string ToString()
        {
            string authorsStr = string.Join(", ", Array.ConvertAll(auths, author => author.ToString()));
            return $"Book[name={name}, authors={{ {authorsStr} }}, price={price}, qty={qty}]";
        }

        public string getAuthorNames()
        {
            return string.Join(", ", Array.ConvertAll(auths, author => author.GetName()));
        }
    }
}
