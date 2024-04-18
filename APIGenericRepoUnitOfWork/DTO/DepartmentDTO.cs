using APIGenericRepoUnitOfWork.Models;

namespace APIGenericRepoUnitOfWork.DTO
{
    public class DepartmentDTO
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int? Dept_Manager { get; set; }
        public int NumOfStudents { get; set; }

    }
}
