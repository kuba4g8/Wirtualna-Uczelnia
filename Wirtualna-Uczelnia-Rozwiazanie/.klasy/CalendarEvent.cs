using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualna_Uczelnia.klasy
{
    public class CalendarEvent
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime event_date { get; set; }
        public TimeSpan? event_time { get; set; }
        public TimeSpan? end_time { get; set; }
        public int teacher_id { get; set; }
        public string subject { get; set; }
        public int? group_id { get; set; }
        public string event_type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
