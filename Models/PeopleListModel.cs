using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend_Project.Models
{
    public class PeopleListModel : PageModel
    {
        public List<Person> people { get; set; } = new List<Person>();
        public Person person { get; set; } = new Person();
    }
}
