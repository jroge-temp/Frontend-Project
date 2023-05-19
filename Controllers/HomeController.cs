using Frontend_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Frontend_Project.Controllers
{
    public class HomeController : Controller
    {
        public PeopleListModel PeopleListModel { get; set; } = new PeopleListModel();

        public HomeController()
        {
            if (PeopleListModel.people.Count == 0)
            {
                PeopleListModel.people = this.GetPeopleFromBackend();
            }
        }

        public IActionResult Index()
        {
            return View(PeopleListModel);
        }

        [HttpPost]
        public ActionResult Index(Person person)
        {
            this.PostPersonToBackend(person);
            return RedirectToAction("Index");
        }

        private List<Person> GetPeopleFromBackend()
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:5203/api/people").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var people = JsonConvert.DeserializeObject<List<Person>>(content);
            return people;
        }

        private void PostPersonToBackend(Person person)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(person);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync("http://localhost:5203/api/people", data).Result;
            var content = response.Content.ReadAsStringAsync().Result;
        }
    }
}