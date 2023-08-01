using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace James_thew_2.Models.DB_Models
{
    public partial class james_thew_recipesContext : DbContext
    {
        public james_thew_recipesContext()
        {
        }

        public james_thew_recipesContext(DbContextOptions<james_thew_recipesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Contest> Contests { get; set; }
        public virtual DbSet<ContestEntry> ContestEntries { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Step> Steps { get; set; }
        public virtual DbSet<TblAdmin> TblAdmins { get; set; }
        public virtual DbSet<Tip> Tips { get; set; }
        public virtual DbSet<User> Users { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=.;Database=james_thew_recipes;User Id=sa;Password=aptech");
                optionsBuilder.UseSqlServer("Server=DESKTOP-HMGIG1I\\SQLEXPRESS;Database=james_thew_recipes;Trusted_Connection=true;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.Property(e => e.AnnouncementId).HasColumnName("AnnouncementID");

                entity.Property(e => e.AnnouncementDate).HasColumnType("date");

                entity.Property(e => e.AnnouncementText).HasColumnType("text");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Announcem__UserI__3C69FB99");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.CommentDate).HasColumnType("date");

                entity.Property(e => e.CommentText).HasColumnType("text");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK__Comments__Recipe__440B1D61");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Comments__UserID__4316F928");
            });

            modelBuilder.Entity<Contest>(entity =>
            {
                entity.Property(e => e.ContestId).HasColumnName("ContestID");

                entity.Property(e => e.ContestDescription).HasColumnType("text");

                entity.Property(e => e.ContestTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Contests)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Contests__UserID__33D4B598");
            });

            modelBuilder.Entity<ContestEntry>(entity =>
            {
                entity.HasKey(e => e.EntryId)
                    .HasName("PK__ContestE__F57BD2D7E1650755");

                entity.Property(e => e.EntryId).HasColumnName("EntryID");

                entity.Property(e => e.ContestId).HasColumnName("ContestID");

                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.TipId).HasColumnName("TipID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Contest)
                    .WithMany(p => p.ContestEntries)
                    .HasForeignKey(d => d.ContestId)
                    .HasConstraintName("FK__ContestEn__Conte__36B12243");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.ContestEntries)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK__ContestEn__Recip__38996AB5");

                entity.HasOne(d => d.Tip)
                    .WithMany(p => p.ContestEntries)
                    .HasForeignKey(d => d.TipId)
                    .HasConstraintName("FK__ContestEn__TipID__398D8EEE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ContestEntries)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ContestEn__UserI__37A5467C");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.FeedbackDate).HasColumnType("date");

                entity.Property(e => e.FeedbackText).HasColumnType("text");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK__Feedback__Recipe__403A8C7D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Feedback__UserID__3F466844");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.IngredientName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK__Ingredien__Recip__2B3F6F97");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.RecipeImage).IsUnicode(false);

                entity.Property(e => e.RecipeTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Recipes__Categor__286302EC");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Recipes__UserID__276EDEB3");
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.Property(e => e.StepId).HasColumnName("StepID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Steps)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK__Steps__RecipeID__2E1BDC42");
            });

            modelBuilder.Entity<TblAdmin>(entity =>
            {
                entity.HasKey(e => e.AId)
                    .HasName("PK__tbl_admi__566AFA9AD48CBE26");

                entity.ToTable("tbl_admin");

                entity.Property(e => e.AId).HasColumnName("a_id");

                entity.Property(e => e.AEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("a_email");

                entity.Property(e => e.AName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("a_name");

                entity.Property(e => e.APassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("a_password");
            });

            modelBuilder.Entity<Tip>(entity =>
            {
                entity.Property(e => e.TipId).HasColumnName("TipID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.TipText).HasColumnType("text");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tips)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Tips__UserID__30F848ED");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MembershipType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePic)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Profile_pic");

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
