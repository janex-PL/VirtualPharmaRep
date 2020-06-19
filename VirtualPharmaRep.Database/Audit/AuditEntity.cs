using System;

namespace VirtualPharmaRep.Database.Audit
{
    public class AuditEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string TableName { get; set; }
        public DateTime DateTime { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
    }
}
