namespace EmployeeInformation.DAL.Entities
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set;}
        public virtual string Email { get; set; }
        public virtual string Address { get; set; }
        public virtual Designation EmployeeDesignation { get; set; }
    }
    
}
