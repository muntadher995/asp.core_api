using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentControler : ControllerBase
    {
        List<Student_list> students = new List<Student_list>();
        public StudentControler()
        {
            students.Add(new Student_list

            {
                Id = 1,
                Name = "ahmed",
                Email = "ahmed@gmail.com",

                Address = "cairo",
                Phone = "0781666",
            });


            students.Add(new Student_list

            {
                Id = 2,
                Name = "Ali",
                Email = "Ali@gmail.com",

                Address = "baghdad",
                Phone = "078188766",
            });

            students.Add(new Student_list

            {
                Id = 3,
                Name = "zaid",
                Email = "zaid@gmail.com",

                Address = "kut",
                Phone = "07815566",
            });

        }
        [HttpGet]
        public List<Student_list> Get()
        {
            return students;
        }


        [HttpGet("{id}")]
        public ActionResult<Student_list> Getbyid(int id)
        {
            var Stname = students.FirstOrDefault(s => s.Id == id);
            if(Stname == null)
            {
                return NotFound();
            }
            return Stname;
        }

        [HttpPost]
        public ActionResult Post ([FromBody] Student_list student)
        {

            if (ModelState.IsValid)

            {



                students.Add(student);
                return CreatedAtAction(nameof(Getbyid), new { id = student.Id }, student);
            
            
            
            
            }
            
            
                return BadRequest();
            
           
        }

        [HttpPut("{id}")]

        public ActionResult Put (int id, [FromBody] Student_list student)
        {
            var sitem=students.Find(s => s.Id == id);
            if(sitem == null)

            
                return NotFound();
            

            foreach(var item in students)
                if(item.Id ==id)
                {
                    item.Name = student.Name;
                }
            return Ok();


        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var sitem = students.Find(s => s.Id == id);
            if (sitem == null)
                return NotFound();
            students.Remove(sitem);

            return Ok();    
        }




    }

    }

