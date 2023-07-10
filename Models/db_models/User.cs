using System;
using System.Collections.Generic;

#nullable disable

namespace James_Thew.Models.db_models
{
    public partial class User
    {
        public User()
        {
            Announcements = new HashSet<Announcement>();
            Comments = new HashSet<Comment>();
            ContestEntries = new HashSet<ContestEntry>();
            Contests = new HashSet<Contest>();
            Feedbacks = new HashSet<Feedback>();
            Recipes = new HashSet<Recipe>();
            Tips = new HashSet<Tip>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfilePic { get; set; }
        public string MembershipType { get; set; }
        public bool? PaymentStatus { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ContestEntry> ContestEntries { get; set; }
        public virtual ICollection<Contest> Contests { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<Tip> Tips { get; set; }
    }
}
