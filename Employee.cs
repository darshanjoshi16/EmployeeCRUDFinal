namespace EmployeeCRUD
{
    public class Employee
    {
        //it will take the id of employee
        public int Id { get; set; }

        //it will contain the first name of employee
        public string FirstName { get; set; } = string.Empty;
        //it will contain the  last name of employee
        public string LastName { get; set; } = string.Empty;

        //it will contain the  role of employee
        public string Role { get; set; } = string.Empty;

        //it will contain the department of the employee
        public string Department { get; set; } = string.Empty;

        //it will contain the salary of the employee
        public float Salary { get; set; } = 0;
    }
}
