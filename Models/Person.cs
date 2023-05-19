using Microsoft.AspNetCore.Mvc;

namespace Frontend_Project.Models
{
    public class Person
    {
        [BindProperty]
        public string fullname { get; set; }

        [BindProperty]
        public string nickname { get; set; }
    }
}
