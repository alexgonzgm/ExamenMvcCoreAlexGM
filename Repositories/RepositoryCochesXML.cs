using ExamenMvcCoreAlexGM.Helpers;
using ExamenMvcCoreAlexGM.Models;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExamenMvcCoreAlexGM.Repositories
{
    public class RepositoryCochesXML : IRepositoryCoches
    {
        private PathProvider pathProvider;
        private XDocument docxml;
        private string path;
        public RepositoryCochesXML(PathProvider pathProvider)
        {
            this.pathProvider = pathProvider;
            this.path = this.pathProvider.MapPath("coches.xml", Folders.Documents);
            this.docxml = XDocument.Load(path);
        }

        public void AddCoche(int id, string marca, string modelo, string conductor, string imagen)
        {
            XElement elemtCoche = new XElement("coche");
            XElement elemetId = new XElement("idcoche", id);
            XElement elemetmarca = new XElement("marca", marca);
            XElement elemetmodelo = new XElement("modelo", modelo);
            XElement elemetconductor = new XElement("conductor", conductor);
            XElement elemetimagen = new XElement("imagen", imagen);
            elemtCoche.Add(elemetId);
            elemtCoche.Add(elemetmarca);
            elemtCoche.Add(elemetmodelo);
            elemtCoche.Add(elemetconductor);
            elemtCoche.Add(elemetimagen);

            this.docxml.Element("coches").Add(elemtCoche);
            this.docxml.Save(this.path);
        }

        public void DeleteCoche(int id)
        {
            var consulta = from datos in docxml.Descendants("coche")
                           where datos.Element("idcoche").Value == id.ToString()
                           select datos;
            XElement coche = consulta.FirstOrDefault();
            coche.Remove();
            this.docxml.Save(path);
        }

        public void UpdateCoche(int id, string marca, string modelo, string conductor, string imagen)
        {
            var consulta = from datos in this.docxml.Descendants("coche")
                           where datos.Element("idcoche").Value == id.ToString()
                           select datos;
            XElement elemtCoche = consulta.FirstOrDefault();
            elemtCoche.Element("marca").Value = marca;
            elemtCoche.Element("modelo").Value = modelo;
            elemtCoche.Element("conductor").Value = conductor;
            elemtCoche.Element("imagen").Value = imagen;
            this.docxml.Save(path);
        }

        public Coche FindCoche(int id)
        {
            var consulta = from datos in docxml.Descendants("coche")
                           where datos.Element("idcoche").Value == id.ToString()
                           select new Coche
                           {
                               IdCoche = int.Parse(datos.Element("idcoche").Value),
                               Marca = datos.Element("marca").Value,
                               Modelo = datos.Element("modelo").Value,
                               Conductor = datos.Element("conductor").Value,
                               Imagen = datos.Element("imagen").Value
                           };
            Coche coche = consulta.FirstOrDefault();
            return coche;

        }
        public List<Coche> GetCoches()
        {
            var consulta = from datos in docxml.Descendants("coche")
                           select new Coche
                           {
                               IdCoche = int.Parse(datos.Element("idcoche").Value),
                               Marca = datos.Element("marca").Value,
                               Modelo = datos.Element("modelo").Value,
                               Conductor = datos.Element("conductor").Value,
                               Imagen = datos.Element("imagen").Value
                           };
            
            return consulta.ToList();
        }

       

       
    }
}
