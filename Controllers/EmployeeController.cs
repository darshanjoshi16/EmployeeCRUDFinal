
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //it is a static list which can be accessed from anywhere in the controller
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee{
                    Id=1,
                    FirstName="Akiwa",
                    LastName="Kurusato",
                    Role="Full Stack Developer",
                    Department="Web Services",
                    Salary= 25000
                },

             new Employee{
                    Id=2,
                    FirstName="Alex",
                    LastName="Kuhnsann",
                    Role="Blockchain Developer",
                    Department="Research and Development",
                    Salary= 45000
                },
        };

        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;

        }

        //it creates the HTTP get method
        [HttpGet]

        //it is a method which will return the fetched action result which means it will get the data in list with 200 Status
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        { return Ok(await _context.Employees.ToListAsync()); }

        [HttpGet("{Id}")]
        //it is a method which will fetch the data in terms of actionresult but it will fetch the single entry instead of whole list
        public async Task<ActionResult<Employee>> GetEmployee(int Id)
        {
            var emp = await _context.Employees.FindAsync(Id);

            if (emp == null)
            {
                return BadRequest("Sorry! Employee is not found");
            }
            return Ok(emp);
        }


        //it creates the HTTP post method
        [HttpPost]

        //it is a post method which will take data from user and it will include POST request in the list
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }

        //it creates the HTTP Put method
        [HttpPut]

        //it is a put method which will take data from user and it will include POST request in the list
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee request)
        {
            //it will take the id from user and then find the particular object
            var dbEmp = await _context.Employees.FindAsync(request.Id);

            //checking if that data object exists
            if (dbEmp == null)
            {
                return BadRequest("Sorry! Employee is not found");
            }

            //update the data as the user wants to
            dbEmp.FirstName = request.FirstName;
            dbEmp.LastName = request.LastName;
            dbEmp.Role = request.Role;
            dbEmp.Department = request.Department;

            //adding the data into list
            employees.Add(dbEmp);

            //saving the changes
            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.ToListAsync());
        }

        //it will create HTTP Delete method
        [HttpDelete("{Id}")]


        //it is a method which will take the id as input parameter and will delete that data object
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int Id)
        {
            //it will create a variable to store and compare the input with existing data
            var Emp = await _context.Employees.FindAsync(Id);

            //checking for emptyness
            if (Emp == null)
            {
                return BadRequest("Sorry! Employee is not found");
            }
            //removing the requested object
            _context.Employees.Remove(Emp);

            //saving the changes
            await _context.SaveChangesAsync();
            //return the whole list
            return Ok(await _context.Employees.ToListAsync());
        }

    }

}
