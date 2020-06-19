namespace VirtualPharmaRep.Data.Entities
{
    public class EntityRequest
    {
        public int Id { get; set; }
        public ApplicationEntities ApplicationEntity { get; set; }
        public HttpMethods HttpMethod { get; set; }
    }
    public enum ApplicationEntities
    {
        None = -1, Clinic, Doctor, DoctorEmployment, Drug, DrugCategory, DrugProperty, DrugPropertyReport, DrugReport, Team, TeamMember, Visit
    }
    public enum HttpMethods
    {
        None = -1, Get, Post, Put, Delete
    }
}
