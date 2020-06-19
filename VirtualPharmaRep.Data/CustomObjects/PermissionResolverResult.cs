namespace VirtualPharmaRep.Data.CustomObjects
{
    public class PermissionResolverResult
    {
        public AccessLevel AccessLevel { get; set; }
        public SendRequest SendRequest { get; set; }
        public string UserId { get; set; }
    }
    public enum SendRequest
    {
        None, GlobalOnly, All
    }
    public enum AccessLevel
    {
        None, Private, Global
    }
}
