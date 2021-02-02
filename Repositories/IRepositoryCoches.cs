using ExamenMvcCoreAlexGM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenMvcCoreAlexGM.Repositories
{
   public interface IRepositoryCoches
    {
        List<Coche> GetCoches();
        Coche FindCoche(int id);
        void DeleteCoche(int id);
        void AddCoche(int id, string marca, string modelo , string conductor ,string imagen);  
        void UpdateCoche(int id, string marca, string modelo, string conductor, string imagen);
     
    }
}
