using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartExpenseManager.Domain.Entities;

namespace SmartExpenseManager.Infrastructure.Persistence.Configurations;

public class LedgerEntryConfiguration : IEntityTypeConfiguration<LedgerEntry>
{
    public void Configure(EntityTypeBuilder<LedgerEntry> builder)
    {
        builder.ToTable("ledger_entries");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ExpenseId).IsRequired();
        builder.Property(x => x.LedgerAccountId).IsRequired();
        builder.Property(x => x.EntryDate).IsRequired();

        builder.OwnsOne(x => x.Amount, money =>
        {
            money.Property(m => m.Value)
                .HasColumnName("amount")
                .IsRequired();

            money.Property(m => m.Currency)
                .HasColumnName("currency")
                .HasMaxLength(3)
                .IsRequired();
        });

        builder.HasOne<Expense>()
            .WithMany()
            .HasForeignKey(x => x.ExpenseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<LedgerAccount>()
            .WithMany()
            .HasForeignKey(x => x.LedgerAccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
