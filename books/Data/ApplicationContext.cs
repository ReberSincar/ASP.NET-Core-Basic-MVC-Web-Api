using System;
using books.Models;

namespace books.Data
{
    public static class ApplicationContext
    {
        public static List<BookModel> Books { get; set; }
        static ApplicationContext()
        {
            Books = new List<BookModel>() {
                new BookModel(){Id = 1, Title = "Suç ve Ceza", Price = 250},
                new BookModel(){Id = 2, Title = "Beyaz Geceler", Price = 100},
                new BookModel(){Id = 3, Title = "İnsancıklar", Price = 200},
            };
        }
    }
}

