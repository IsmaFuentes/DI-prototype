using System;

namespace Prototype.models
{
    public class Detail
    {
        public Guid _id { get; set; }
        public string user { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public DateTime timestamp { get; set; }
        public string detailContent { get; set; }
    }
}
