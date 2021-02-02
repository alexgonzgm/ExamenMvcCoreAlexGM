using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenMvcCoreAlexGM.Models;
using ExamenMvcCoreAlexGM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExamenMvcCoreAlexGM.Controllers
{
    public class CochesController : Controller
    {

        private IRepositoryCoches repository;
        public CochesController(IRepositoryCoches repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(this.repository.GetCoches());
        }
        [HttpPost]
        public IActionResult Index(string modelo)
        {
            if (modelo != null)
            {
                var filtro = modelo.ToUpper();
                return View(this.repository.GetCoches().Where(x => x.Modelo.Contains(filtro)));
            }
            else
            {
                return View(this.repository.GetCoches());
            }
           
           
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Coche coche)
        {
            this.repository.AddCoche(coche.IdCoche, coche.Marca, coche.Modelo, coche.Conductor,coche.Imagen);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            return View(this.repository.FindCoche(id));
        }

        public IActionResult Edit(int id)
        {
            Coche coche = this.repository.FindCoche(id);
            return View(coche);
        }
        [HttpPost]
        public IActionResult Edit(Coche car)
        {
            this.repository.UpdateCoche(car.IdCoche, car.Marca, car.Modelo, car.Conductor, car.Imagen);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Coche coche = this.repository.FindCoche(id);
            return View(coche);
        }
        [HttpPost]
        public IActionResult Delete(int idcoche , string modelo)
        {
            this.repository.DeleteCoche(idcoche);
            return RedirectToAction(nameof(Index));
        }

    }
}