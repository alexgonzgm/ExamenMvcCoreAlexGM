using ExamenMvcCoreAlexGM.Data;
using ExamenMvcCoreAlexGM.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ExamenMvcCoreAlexGM.Repositories
{
    #region Procedure
//    create procedure addcoche
//(@marca nvarchar(30) , @modelo nvarchar(30),@conductor nvarchar(30),@imagen nvarchar(50))
//as
// insert into coches(idcoche , marca , modelo , conductor, imagen)
// values((select (Max(idcoche )+1) from coches) , @marca ,@modelo ,@conductor ,@imagen)
//go
    #endregion
    public class RepositoryCochesSql : IRepositoryCoches
    {
        private CochesContext context;
        public RepositoryCochesSql(CochesContext context)
        {
            this.context = context;
        }


        public void AddCoche(int id, string marca, string modelo, string conductor, string imagen)
        {
            string sql = "addcoche @marca , @modelo ,@conductor,@imagen";
            SqlParameter pmarca = new SqlParameter("@marca", marca);
            SqlParameter pmodelo = new SqlParameter("@modelo", modelo);
            SqlParameter pconductor = new SqlParameter("@conductor", conductor);
            SqlParameter pimagen = new SqlParameter("@imagen", imagen);
            this.context.Database.ExecuteSqlRaw(sql, pmarca, pmodelo, pconductor, pimagen);
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
