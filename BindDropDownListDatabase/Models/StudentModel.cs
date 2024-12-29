using Microsoft.AspNetCore.Mvc.Rendering;

namespace BindDropDownListDatabase.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public List<SelectListItem>  StudentsList { get; set; }
    }
}
