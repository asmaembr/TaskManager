using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TPEF.Data;

namespace TaskManager.Controllers
{
    public class MyTaskController : Controller
    {
        private readonly ApplicationDBContext _db;

        private int user;
        public MyTaskController(ApplicationDBContext db)
        {
            _db = db;
     
        }



        public IActionResult Index()
        {
            user = TempData.ContainsKey("UserId") ? (int)TempData["UserId"] : 0;
            var objTaskList = _db.Tasks.ToList();
            var userTask = new List<MyTask>();
            foreach (var item in objTaskList)
            {
                if(item.Iduser == user) { userTask.Add(item); }
                
            }

            return View(userTask);
            //return View();
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(MyTask T)
        {
            _db.Tasks.Add(new MyTask( T.Title, T.Description,T.DueDate,user));
            _db.SaveChanges();
            return RedirectToAction("Index");
            //return View(Emp);
        }



        public IActionResult Delete(int id)
        {
            var taskToDelete = _db.Tasks.Find(id);

            if (taskToDelete == null)
            {
                return NotFound();
            }

            return View(taskToDelete);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var taskToDelete = _db.Tasks.Find(id);

            if (taskToDelete == null)
            {
                return NotFound();
            }

            _db.Tasks.Remove(taskToDelete);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var taskToEdit = _db.Tasks.Find(id);

            if (taskToEdit == null)
            {
                return NotFound();
            }

            return View(taskToEdit); // Retourne la vue de modification avec les détails de la tâche
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MyTask editedTask)
        {
            if (ModelState.IsValid)
            {
                _db.Tasks.Update(editedTask);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(editedTask); // Retourne la vue de modification si le modèle n'est pas valide
        }

    }
}
       