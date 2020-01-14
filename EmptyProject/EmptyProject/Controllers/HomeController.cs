using EmptyProject.Interfaces;
using EmptyProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmptyProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            var students = _studentRepository.GetAll();
            return View(students);
        }

        public IActionResult Details(int id)
        {
            var student = _studentRepository.Get(id);
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            var isSuccessful = _studentRepository.Add(student);
            if (isSuccessful)
                return RedirectToAction("Index");

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _studentRepository.Get(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var isSuccessful = _studentRepository.Edit(student);

            if (isSuccessful)
                return RedirectToAction("Index");

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _studentRepository.Get(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var isSuccessful = _studentRepository.Delete(id);

            if (isSuccessful)
                RedirectToAction("Index");

//          return RedirectToAction("ConfirmDelete", new { id = id });
            return RedirectToAction("Index");
        }
    }
}
