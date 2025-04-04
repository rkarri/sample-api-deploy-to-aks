using BasicEfCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

public static class InvoiceItemExtensions
{
    public static void InvoiceItemModelBuilderConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InvoiceItem>(b =>
        {
            b.ToTable("InvoiceItems");
            b.Property(p => p.Id).HasColumnName(nameof(InvoiceItem.Id));
            b.Property(p => p.Name).HasColumnName(nameof(InvoiceItem.Name)).HasMaxLength(64).IsRequired();
            b.Property(p => p.Description).HasColumnName(nameof(InvoiceItem.Description)).HasMaxLength(256);
            b.Property(p => p.UnitPrice).HasColumnName(nameof(InvoiceItem.UnitPrice)).HasPrecision(8, 2);
            b.Property(p => p.Quantity).HasColumnName(nameof(InvoiceItem.Quantity)).HasPrecision(8, 2);
            b.Property(p => p.Amount).HasColumnName(nameof(InvoiceItem.Amount)).HasPrecision(18, 2);
            b.Property(p => p.InvoiceId).HasColumnName(nameof(InvoiceItem.InvoiceId));
            
        });
    }
   
}