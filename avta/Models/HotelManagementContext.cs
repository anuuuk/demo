using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace avta.Models;

public partial class HotelManagementContext : DbContext
{
    public HotelManagementContext()
    {
    }

    public HotelManagementContext(DbContextOptions<HotelManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CleaningSchedule> CleaningSchedules { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<GuestService> GuestServices { get; set; }

    public virtual DbSet<Integration> Integrations { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomAccess> RoomAccesses { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<StatisticsHotel> StatisticsHotels { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=hotel_management;Encrypt=True;TrustServerCertificate=True; Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CleaningSchedule>(entity =>
        {
            entity.ToTable("Cleaning_Schedule");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CleaningDate)
                .HasColumnType("datetime")
                .HasColumnName("cleaning_date");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Room).WithMany(p => p.CleaningSchedules)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK_Cleaning_Schedule_Rooms");

            entity.HasOne(d => d.User).WithMany(p => p.CleaningSchedules)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Cleaning_Schedule_Users");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Guests__3213E83F403A343E");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(50)
                .HasColumnName("document_number");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<GuestService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Guest_Se__3213E83F88224D7C");

            entity.ToTable("Guest_Services");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.Reservation).WithMany(p => p.GuestServices)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("FK_Guest_Services_Reservations1");

            entity.HasOne(d => d.Service).WithMany(p => p.GuestServices)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_Guest_Services_Services1");
        });

        modelBuilder.Entity<Integration>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IntegrationDetails)
                .HasMaxLength(50)
                .HasColumnName("integration_details");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Keycards__3213E83F01B10BF5");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");

            entity.HasOne(d => d.Reservation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("FK_Payments_Reservations");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3213E83FB953C5A6");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CheckInDate)
                .HasColumnType("datetime")
                .HasColumnName("check_in_date");
            entity.Property(e => e.CheckOutDate)
                .HasColumnType("datetime")
                .HasColumnName("check_out_date");
            entity.Property(e => e.GuestId).HasColumnName("guest_id");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_price");

            entity.HasOne(d => d.Guest).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.GuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservations_Guests");

            entity.HasOne(d => d.Room).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservations_Rooms");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rooms__3213E83FEEC90B81");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .HasColumnName("category");
            entity.Property(e => e.Floor)
                .HasMaxLength(10)
                .HasColumnName("floor");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.PricePerNight)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price_per_night");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        modelBuilder.Entity<RoomAccess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Room_Acc__3213E83F65677D6B");

            entity.ToTable("Room_Access");

            entity.Property(e => e.Id)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("id");
            entity.Property(e => e.AccessCardCode)
                .HasMaxLength(50)
                .HasColumnName("access_card_code");
            entity.Property(e => e.GuestId).HasColumnName("guest_id");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.Guest).WithMany(p => p.RoomAccesses)
                .HasForeignKey(d => d.GuestId)
                .HasConstraintName("FK_Room_Access_Rooms");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomAccesses)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK_Room_Access_Rooms1");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Services__3213E83F5D1E69A1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<StatisticsHotel>(entity =>
        {
            entity.ToTable("Statistics_hotel");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adr)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("adr");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.OccupancyRate)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("occupancy_rate");
            entity.Property(e => e.Revenue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("revenue");
            entity.Property(e => e.Revpar)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("revpar");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F94B64A64");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsFirstLogin).HasColumnName("isFirstLogin");
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
