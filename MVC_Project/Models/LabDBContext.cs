using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_Project.Models;

public partial class LabDBContext : DbContext
{
    public LabDBContext()
    {
    }

    public LabDBContext(DbContextOptions<LabDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Call> Calls { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Program> Programs { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PAVLISPC;Database=unipi_project;Trusted_Connection=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.Admins).HasConstraintName("FK_admin_users");
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasOne(d => d.PhoneNumberNavigation).WithMany(p => p.Bills).HasConstraintName("FK_bills_phones");
        });

        modelBuilder.Entity<Call>(entity =>
        {
            entity.HasOne(d => d.PhoneNumberNavigation).WithMany(p => p.Calls).HasConstraintName("FK_calls_phones");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasOne(d => d.PhoneNumberNavigation).WithMany(p => p.Clients).HasConstraintName("FK_clients_phones");

            entity.HasOne(d => d.User).WithMany(p => p.Clients).HasConstraintName("FK_clients_users");
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasOne(d => d.ProgramNameNavigation).WithMany(p => p.Phones).HasConstraintName("FK_phones_programs");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.Sellers).HasConstraintName("FK_sellers_users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
