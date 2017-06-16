using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EasyFunFinder.Data
{
    public partial class EasyFunFinderContext : DbContext
    {
        public EasyFunFinderContext(DbContextOptions<EasyFunFinderContext> options) : base(options) { }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<BusinessFeature> BusinessFeature { get; set; }
        public virtual DbSet<BusinessStatus> BusinessStatus { get; set; }
        public virtual DbSet<BusinessType> BusinessType { get; set; }
        public virtual DbSet<Entertainer> Entertainer { get; set; }
        public virtual DbSet<EntertainerCategory> EntertainerCategory { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventTime> EventTime { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<GeoPointArea> GeoPointArea { get; set; }
        public virtual DbSet<GeoPointBusiness> GeoPointBusiness { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Keys> Keys { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonRole> PersonRole { get; set; }
        public virtual DbSet<ProductBrand> ProductBrand { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserEmailBlacklist> UserEmailBlacklist { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<UserProfileBusinessType> UserProfileBusinessType { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<XBusinessToArea> XBusinessToArea { get; set; }
        public virtual DbSet<XBusinessToBusinessType> XBusinessToBusinessType { get; set; }
        public virtual DbSet<XBusinessToFeature> XBusinessToFeature { get; set; }
        public virtual DbSet<XBusinessToProductBrand> XBusinessToProductBrand { get; set; }
        public virtual DbSet<XBusinessTypeToBusinessFeature> XBusinessTypeToBusinessFeature { get; set; }
        public virtual DbSet<XEntertainerToEvent> XEntertainerToEvent { get; set; }
        public virtual DbSet<XEntertainerToGenre> XEntertainerToGenre { get; set; }
        public virtual DbSet<XEntertainerToPerson> XEntertainerToPerson { get; set; }
        public virtual DbSet<XEntityToImage> XEntityToImage { get; set; }
        public virtual DbSet<XEventToEventType> XEventToEventType { get; set; }
        public virtual DbSet<XUserToEntertainer> XUserToEntertainer { get; set; }
        public virtual DbSet<XUserToEvent> XUserToEvent { get; set; }
        public virtual DbSet<XUserToPerson> XUserToPerson { get; set; }
        public virtual DbSet<XUserToUserRole> XUserToUserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasIndex(e => e.City)
                    .HasName("IX_Area_City");

                entity.HasIndex(e => e.GooglePlaceId)
                    .HasName("IX_Area_GooglePlaceID");

                entity.HasIndex(e => e.Lat)
                    .HasName("IX_Place_Lat");

                entity.HasIndex(e => e.Lng)
                    .HasName("IX_Place_Lng");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Area_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Pcode)
                    .HasName("IX_Place_PCode");

                entity.HasIndex(e => e.State)
                    .HasName("IX_Place_State");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("IX_Area_UniqueID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City).HasMaxLength(128);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnType("char(2)");

                entity.Property(e => e.County).HasMaxLength(50);

                entity.Property(e => e.GooglePlaceId)
                    .HasColumnName("GooglePlaceID")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Pcode)
                    .HasColumnName("PCode")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnType("char(2)");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .HasDefaultValueSql("newid()");

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.Area)
                    .HasForeignKey(d => d.State)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Area_State");
            });

            modelBuilder.Entity<Business>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("IX_Business_EMail");

                entity.HasIndex(e => e.GooglePlaceId)
                    .HasName("IX_Business_GooglePlaceID");

                entity.HasIndex(e => e.Lat)
                    .HasName("IX_Business_Lat");

                entity.HasIndex(e => e.Lng)
                    .HasName("IX_Business_Long");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Business_Name");

                entity.HasIndex(e => e.Pcode)
                    .HasName("IX_Business_PCode");

                entity.HasIndex(e => e.State)
                    .HasName("IX_Business_State");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("IX_Business_UniqueID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address1).HasColumnType("varchar(128)");

                entity.Property(e => e.Address2).HasColumnType("varchar(128)");

                entity.Property(e => e.City).HasColumnType("varchar(128)");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.CountryCode).HasColumnType("char(2)");

                entity.Property(e => e.County).HasMaxLength(50);

                entity.Property(e => e.CreationDateTime).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.GooglePlaceId)
                    .HasColumnName("GooglePlaceID")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Pcode)
                    .HasColumnName("PCode")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Phone1).HasColumnType("varchar(15)");

                entity.Property(e => e.Phone2).HasColumnType("varchar(15)");

                entity.Property(e => e.State).HasColumnType("char(2)");

                entity.Property(e => e.Status).HasDefaultValueSql("1");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .HasDefaultValueSql("newid()");

                entity.Property(e => e.WebsiteUrl)
                    .HasColumnName("WebsiteURL")
                    .HasColumnType("varchar(512)");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Business)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Business_Person");

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.Business)
                    .HasForeignKey(d => d.State)
                    .HasConstraintName("FK_Business_State");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Business)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BusinessCore_BusinessStatus");
            });

            modelBuilder.Entity<BusinessFeature>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_BusinessCategory_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<BusinessStatus>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment).HasColumnType("varchar(50)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<BusinessType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Entertainer>(entity =>
            {
                entity.HasIndex(e => e.EntertainerCategoryId)
                    .HasName("IX_Entertainer_EntertainerCategoryID");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Entertainer_Name");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("IX_Entertainer_UniqueID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.CreationDateTime).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.EntertainerCategoryId).HasColumnName("EntertainerCategoryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Phone).HasColumnType("varchar(15)");

                entity.Property(e => e.UniqueId).HasColumnName("UniqueID");

                entity.Property(e => e.WebsiteUrl)
                    .HasColumnName("WebsiteURL")
                    .HasColumnType("varchar(512)");

                entity.HasOne(d => d.EntertainerCategory)
                    .WithMany(p => p.Entertainer)
                    .HasForeignKey(d => d.EntertainerCategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Entertainer_EntertainerCategory");
            });

            modelBuilder.Entity<EntertainerCategory>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_EntertainerCategory_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasIndex(e => e.BusinessId)
                    .HasName("IX_Event_BusinessID");

                entity.HasIndex(e => e.ContactId)
                    .HasName("IX_Event_ContactID");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Event_Name");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("IX_Event_UniqueID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.CreationDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UniqueId).HasColumnName("UniqueID");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Event_Business");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Event_Person");
            });

            modelBuilder.Entity<EventTime>(entity =>
            {
                entity.HasIndex(e => e.EventId)
                    .HasName("IX_EventTime_EventID");

                entity.HasIndex(e => e.StartTime)
                    .HasName("IX_EventTime_StartTime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventTime)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_EventTime_Event");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_Genre_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GeoPointArea>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<GeoPointBusiness>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasIndex(e => e.AddedByUserId)
                    .HasName("IX_Image_AddedByUserID");

                entity.HasIndex(e => e.DateTimeAdded)
                    .HasName("IX_Image_DateTimeAdded");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddedByUserId).HasColumnName("AddedByUserID");

                entity.Property(e => e.Bytes).IsRequired();

                entity.Property(e => e.DateTimeAdded).HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .HasColumnType("varchar(128)")
                    .HasDefaultValueSql("'getid()'");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Title).HasMaxLength(128);

                entity.HasOne(d => d.AddedByUser)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.AddedByUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Image_User");
            });

            modelBuilder.Entity<Keys>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnType("varchar(500)");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => e.Email1)
                    .HasName("IX_Person_EMail1");

                entity.HasIndex(e => e.Email2)
                    .HasName("IX_Person_EMail2");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("IX_Person_UniqueID")
                    .IsUnique();

                entity.HasIndex(e => new { e.LastName, e.FirstName })
                    .HasName("IX_Person_Name");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreationDateTime).HasColumnType("datetime");

                entity.Property(e => e.Email1)
                    .HasColumnName("EMail1")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.Email2)
                    .HasColumnName("EMail2")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Phone1).HasColumnType("varchar(20)");

                entity.Property(e => e.Phone2).HasColumnType("varchar(20)");

                entity.Property(e => e.UniqueId).HasColumnName("UniqueID");
            });

            modelBuilder.Entity<PersonRole>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_PersonRole_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProductBrand>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_ProductBrand_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasIndex(e => e.CountryCode)
                    .HasName("IX_State_Country");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("char(2)");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.CookieId)
                    .HasName("IX_User_CookieID")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("IX_User_EMail")
                    .IsUnique();

                entity.HasIndex(e => e.UniqueId)
                    .HasName("IX_User_UniqueID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CookieId).HasColumnName("CookieID");

                entity.Property(e => e.CreationDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMail")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IsBusinessUser).HasDefaultValueSql("0");

                entity.Property(e => e.LastLoginDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PasswordHash).HasMaxLength(256);

                entity.Property(e => e.PasswordSalt).HasDefaultValueSql("newid()");

                entity.Property(e => e.UniqueId).HasColumnName("UniqueID");
            });

            modelBuilder.Entity<UserEmailBlacklist>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK_UserEMailBlacklist");

                entity.ToTable("UserEMailBlacklist");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.BlackListedDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasIndex(e => e.DefaultProfile)
                    .HasName("IX_UserProfile_DefaultProfile");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserNamedProfile_UserID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BusinessTypeId).HasColumnName("BusinessTypeID");

                entity.Property(e => e.ProfileName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Radius).HasDefaultValueSql("0");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProfile)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserProfile_User");
            });

            modelBuilder.Entity<UserProfileBusinessType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BusinessTypeId).HasColumnName("BusinessTypeID");

                entity.Property(e => e.UserProfileId).HasColumnName("UserProfileID");

                entity.HasOne(d => d.BusinessType)
                    .WithMany(p => p.UserProfileBusinessType)
                    .HasForeignKey(d => d.BusinessTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserProfileBusinessType_BusinessType");

                entity.HasOne(d => d.UserProfile)
                    .WithMany(p => p.UserProfileBusinessType)
                    .HasForeignKey(d => d.UserProfileId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserProfileBusinessCategory_UserProfile");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<XBusinessToArea>(entity =>
            {
                entity.HasKey(e => new { e.BusinessId, e.AreaId })
                    .HasName("PK_xBusinessCore_to_Place");

                entity.ToTable("xBusiness_to_Area");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.XBusinessToArea)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_xBusinessCore_to_Place_Place");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.XBusinessToArea)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_xBusinessCore_to_Place_BusinessCore");
            });

            modelBuilder.Entity<XBusinessToBusinessType>(entity =>
            {
                entity.HasKey(e => new { e.BusinessId, e.BusinessTypeId })
                    .HasName("PK_xBusinessType_to_BusinessCategory");

                entity.ToTable("xBusiness_to_BusinessType");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.BusinessTypeId).HasColumnName("BusinessTypeID");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.XBusinessToBusinessType)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_xBusiness_to_BusinessType_Business");

                entity.HasOne(d => d.BusinessNavigation)
                    .WithMany(p => p.XBusinessToBusinessType)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_xBusinessType_to_BusinessCategory_BusinessType");
            });

            modelBuilder.Entity<XBusinessToFeature>(entity =>
            {
                entity.HasKey(e => new { e.BusinessId, e.BusinessFeatureId })
                    .HasName("PK_xBusiness_to_Category");

                entity.ToTable("xBusiness_to_Feature");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.BusinessFeatureId).HasColumnName("BusinessFeatureID");

                entity.HasOne(d => d.BusinessFeature)
                    .WithMany(p => p.XBusinessToFeature)
                    .HasForeignKey(d => d.BusinessFeatureId)
                    .HasConstraintName("FK_xBusiness_to_Category_BusinessCategory");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.XBusinessToFeature)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_xBusiness_to_Category_Business");
            });

            modelBuilder.Entity<XBusinessToProductBrand>(entity =>
            {
                entity.HasKey(e => new { e.BusinessId, e.ProductBrandId })
                    .HasName("PK_xBusiness_to_ProductBrand");

                entity.ToTable("xBusiness_to_ProductBrand");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.ProductBrandId).HasColumnName("ProductBrandID");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.XBusinessToProductBrand)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_xBusiness_to_ProductBrand_Business");

                entity.HasOne(d => d.ProductBrand)
                    .WithMany(p => p.XBusinessToProductBrand)
                    .HasForeignKey(d => d.ProductBrandId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_xBusiness_to_ProductBrand_ProductBrand");
            });

            modelBuilder.Entity<XBusinessTypeToBusinessFeature>(entity =>
            {
                entity.HasKey(e => new { e.BusinessTypeId, e.BusinessFeatureId })
                    .HasName("PK_xBusinessType_to_BusinessFeature");

                entity.ToTable("xBusinessType_to_BusinessFeature");

                entity.Property(e => e.BusinessTypeId).HasColumnName("BusinessTypeID");

                entity.Property(e => e.BusinessFeatureId).HasColumnName("BusinessFeatureID");

                entity.HasOne(d => d.BusinessFeature)
                    .WithMany(p => p.XBusinessTypeToBusinessFeature)
                    .HasForeignKey(d => d.BusinessFeatureId)
                    .HasConstraintName("FK_xBusinessType_to_BusinessFeature_BusinessFeature");

                entity.HasOne(d => d.BusinessType)
                    .WithMany(p => p.XBusinessTypeToBusinessFeature)
                    .HasForeignKey(d => d.BusinessTypeId)
                    .HasConstraintName("FK_xBusinessType_to_BusinessFeature_BusinessType");
            });

            modelBuilder.Entity<XEntertainerToEvent>(entity =>
            {
                entity.HasKey(e => new { e.EntertainerId, e.EventId })
                    .HasName("PK_xEntertainer_to_Event");

                entity.ToTable("xEntertainer_to_Event");

                entity.Property(e => e.EntertainerId).HasColumnName("EntertainerID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.HasOne(d => d.Entertainer)
                    .WithMany(p => p.XEntertainerToEvent)
                    .HasForeignKey(d => d.EntertainerId)
                    .HasConstraintName("FK_xEntertainer_to_Event_Entertainer");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.XEntertainerToEvent)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_xEntertainer_to_Event_Event");
            });

            modelBuilder.Entity<XEntertainerToGenre>(entity =>
            {
                entity.HasKey(e => new { e.EntertainerId, e.GenreId })
                    .HasName("PK_xEntertainer_to_Genre");

                entity.ToTable("xEntertainer_to_Genre");

                entity.Property(e => e.EntertainerId).HasColumnName("EntertainerID");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.HasOne(d => d.Entertainer)
                    .WithMany(p => p.XEntertainerToGenre)
                    .HasForeignKey(d => d.EntertainerId)
                    .HasConstraintName("FK_xEntertainer_to_Genre_Entertainer");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.XEntertainerToGenre)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK_xEntertainer_to_Genre_Genre");
            });

            modelBuilder.Entity<XEntertainerToPerson>(entity =>
            {
                entity.HasKey(e => new { e.EntertainerId, e.PersonId, e.PersonRoleId })
                    .HasName("PK_xEntertainer_to_Person");

                entity.ToTable("xEntertainer_to_Person");

                entity.Property(e => e.EntertainerId).HasColumnName("EntertainerID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.PersonRoleId).HasColumnName("PersonRoleID");

                entity.HasOne(d => d.Entertainer)
                    .WithMany(p => p.XEntertainerToPerson)
                    .HasForeignKey(d => d.EntertainerId)
                    .HasConstraintName("FK_xEntertainer_to_Person_Entertainer");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.XEntertainerToPerson)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_xEntertainer_to_Person_Person");

                entity.HasOne(d => d.PersonRole)
                    .WithMany(p => p.XEntertainerToPerson)
                    .HasForeignKey(d => d.PersonRoleId)
                    .HasConstraintName("FK_xEntertainer_to_Person_PersonRole");
            });

            modelBuilder.Entity<XEntityToImage>(entity =>
            {
                entity.HasKey(e => new { e.EntityId, e.ImageId })
                    .HasName("PK_xEntity_to_Image");

                entity.ToTable("xEntity_to_Image");

                entity.Property(e => e.EntityId).HasColumnName("EntityID");

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.HasOne(d => d.Entity)
                    .WithMany(p => p.XEntityToImage)
                    .HasPrincipalKey(p => p.UniqueId)
                    .HasForeignKey(d => d.EntityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_xEntity_to_Image_Business");

                entity.HasOne(d => d.EntityNavigation)
                    .WithMany(p => p.XEntityToImage)
                    .HasPrincipalKey(p => p.UniqueId)
                    .HasForeignKey(d => d.EntityId)
                    .HasConstraintName("FK_xEntity_to_Image_Entertainer");

                entity.HasOne(d => d.Entity1)
                    .WithMany(p => p.XEntityToImage)
                    .HasPrincipalKey(p => p.UniqueId)
                    .HasForeignKey(d => d.EntityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_xEntity_to_Image_Event");

                entity.HasOne(d => d.Entity2)
                    .WithMany(p => p.XEntityToImage)
                    .HasPrincipalKey(p => p.UniqueId)
                    .HasForeignKey(d => d.EntityId)
                    .HasConstraintName("FK_xEntity_to_Image_Person");

                entity.HasOne(d => d.Entity3)
                    .WithMany(p => p.XEntityToImage)
                    .HasPrincipalKey(p => p.UniqueId)
                    .HasForeignKey(d => d.EntityId)
                    .HasConstraintName("FK_xEntity_to_Image_User");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.XEntityToImage)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK_xEntity_to_Image_Image");
            });

            modelBuilder.Entity<XEventToEventType>(entity =>
            {
                entity.HasKey(e => new { e.EventId, e.EventTypeId })
                    .HasName("PK_xEvent_to_EventType");

                entity.ToTable("xEvent_to_EventType");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.XEventToEventType)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_xEvent_to_EventType_Event");

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.XEventToEventType)
                    .HasForeignKey(d => d.EventTypeId)
                    .HasConstraintName("FK_xEvent_to_EventType_EventType");
            });

            modelBuilder.Entity<XUserToEntertainer>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.EntertainerId })
                    .HasName("PK_xUser_to_Entertainer");

                entity.ToTable("xUser_to_Entertainer");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.EntertainerId).HasColumnName("EntertainerID");

                entity.HasOne(d => d.Entertainer)
                    .WithMany(p => p.XUserToEntertainer)
                    .HasForeignKey(d => d.EntertainerId)
                    .HasConstraintName("FK_xUser_to_Entertainer_Entertainer");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.XUserToEntertainer)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_xUser_to_Entertainer_User");
            });

            modelBuilder.Entity<XUserToEvent>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.EventId })
                    .HasName("PK_xUser_to_Event");

                entity.ToTable("xUser_to_Event");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.XUserToEvent)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_xUser_to_Event_Event");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.XUserToEvent)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_xUser_to_Event_User");
            });

            modelBuilder.Entity<XUserToPerson>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PersonId })
                    .HasName("PK_xUser_to_Person");

                entity.ToTable("xUser_to_Person");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.XUserToPerson)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_xUser_to_Person_Person");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.XUserToPerson)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_xUser_to_Person_User");
            });

            modelBuilder.Entity<XUserToUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.UserRoleId })
                    .HasName("PK_xUser_to_UserRole");

                entity.ToTable("xUser_to_UserRole");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.XUserToUserRole)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_xUser_to_UserRole_User");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.XUserToUserRole)
                    .HasForeignKey(d => d.UserRoleId)
                    .HasConstraintName("FK_xUser_to_UserRole_UserRole");
            });
        }
    }
}