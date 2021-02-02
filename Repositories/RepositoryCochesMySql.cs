using ExamenMvcCoreAlexGM.Data;
using ExamenMvcCoreAlexGM.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenMvcCoreAlexGM.Repositories
{
    public class RepositoryCochesMySql : IRepositoryCoches
    {
        private CochesContext context;
        public RepositoryCochesMySql(CochesContext context)
        {
            this.context = context;
        }

        public void AddCoche(int id, string marca, string modelo, string conductor, string imagen)
        {
            Coche coche = new Coche();
            coche.IdCoche = id;
            coche.Marca = marca;
            coche.Modelo = modelo;
            coche.Conductor = conductor;
            coche.Imagen = imagen;
            this.context.Coches.Add(coche);
            this.context.SaveChanges();
        }

        public void DeleteCoche(int id)
        {
            Coche coche = this.FindCoche(id);
            this.context.Remove(coche);
            this.context.SaveChanges();
        }

        public Coche FindCoche(int id)
        {
            return this.context.Coches.Where(x => x.IdCoche == id).FirstOrDefault();
        }

        public List<Coche> GetCoches()
        {
            return this.context.Coches.ToList();
        }

        public void UpdateCoche(int id, string marca, string modelo, string conductor, string imagen)
        {
            Coche coche = FindCoche(id);
            coche.Marca = marca;
            coche.Modelo = modelo;
            coche.Conductor = conductor;
            coche.Imagen = imagen;
            this.context.SaveChanges();
        }
    }
}
