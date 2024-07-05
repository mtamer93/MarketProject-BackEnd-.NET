using ApplicationCore.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SeedData
{
    public class ProductSeedData : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Elma",
                    Price = 20.0,
                    Quantity = 500,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Karpuz",
                    Price = 100.0,
                    Quantity = 75,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Muz",
                    Price = 50.0,
                    Quantity = 60,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 4,
                    Name = "IPhone 14",
                    Price = 50000.0,
                    Quantity = 20,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 5,
                    Name = "Samsung Galaxy S24",
                    Price = 45000.0,
                    Quantity = 35,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 6,
                    Name = "Huawei Mate 50 Pro",
                    Price = 40000.0,
                    Quantity = 30,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 7,
                    Name = "Beyaz Peynir",
                    Price = 340.0,
                    Quantity = 100,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 8,
                    Name = "Tereyağ",
                    Price = 270.0,
                    Quantity = 60,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 9,
                    Name = "Kangal Sucuk",
                    Price = 750.0,
                    Quantity = 50,
                    CategoryId = 3
                }
            );
        }
    }
}
