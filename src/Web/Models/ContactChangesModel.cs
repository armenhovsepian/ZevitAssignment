using System;

namespace Web.Models
{
    public class ContactChangesModel
    {
        public int Id { get; set; }
        public string MetaData { get; set; }
        public string EventType { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
