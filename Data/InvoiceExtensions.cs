using BasicEfCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

public static class InvoiceExtensions
{
    public static void InvoiceModelBuilderConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoice>(b =>
        {
            b.ToTable("Invoices");
            b.HasKey(i => i.Id);
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.InvoiceNumber).HasColumnName("InvoiceNumber").HasColumnType("varchar(32)").IsRequired();
            b.Property(p => p.ContactName).HasColumnName("ContactName").HasMaxLength(32).IsRequired();
            b.Property(p => p.Description).HasColumnName("Description").HasMaxLength(256);
            // b.Property(p => p.Amount).HasColumnName("Amount").HasColumnType("decimal(18,2)").IsRequired();
            b.Property(p => p.Amount).HasColumnName("Amount").HasPrecision(18, 2);
            b.Property(p => p.InvoiceDate).HasColumnName("InvoiceDate").HasColumnType("datetimeoffset").IsRequired();
            b.Property(p => p.DueDate).HasColumnName("DueDate").HasColumnType("datetimeoffset").IsRequired();
            b.Property(p => p.Status).HasColumnName("Status").HasMaxLength(16).HasConversion(
                    v => v.ToString(),
                    v => (InvoiceStatus)Enum.Parse(typeof(InvoiceStatus), v));
            b.Property(p => p.InvoiceDate).HasDefaultValueSql("GETDATE()");
        });
    }
    public static void InvoiceModelSeedData(this ModelBuilder modelBuilder)
    {
              modelBuilder.Entity<Invoice>().HasData(
                new Invoice
                {
                    Id = Guid.Parse("a5c8762b-6f2c-4d98-85e5-7859f0ab1ad7"),
                    InvoiceNumber = "INV-001",
                    ContactName = "Iron Man",
                    Description = "Invoice for the first month",
                    Amount = 100,
                    InvoiceDate = new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero),
                    DueDate = new DateTimeOffset(2021, 1, 15, 0, 0, 0, TimeSpan.Zero),
                    Status = InvoiceStatus.AwaitPayment
                },
                new Invoice
                {
                    Id = Guid.Parse("a5c8762b-6f2c-4d98-85e5-7859f0ab1ad9"),
                    InvoiceNumber = "INV-002",
                    ContactName = "Captain America",

                    Description = "Invoice for the first month",
                    Amount = 200,
                    InvoiceDate = new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero),
                    DueDate = new DateTimeOffset(2021, 1, 15, 0, 0, 0, TimeSpan.Zero),
                    Status = InvoiceStatus.AwaitPayment
                },
                new Invoice
                {
                    Id = Guid.Parse("a5c8762b-6f2c-4d98-85e5-7859f0ab1ad8"),
                    InvoiceNumber = "INV-003",
                    ContactName = "Thor",
                    Description = "Invoice for the first month",
                    Amount = 300,
                    InvoiceDate = new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero),
                    DueDate = new DateTimeOffset(2021, 1, 15, 0, 0, 0, TimeSpan.Zero),
                    Status = InvoiceStatus.Draft
                });

    }
}