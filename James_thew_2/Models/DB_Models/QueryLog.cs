using System;

namespace James_thew_2.Models.DB_Models
{
    public class QueryLog
    {
        public int log_id { get; set; }
        public string log_query { get; set; }
        public DateTime log_datetime { get; set; }
    }
}
