using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    public class CreateTable <T> where T : City, new()
    {
        private List<T> Cities { get; set; } = new List<T>();
        public void AddCity(string name) => Cities.Add(new T()
        {
            c_id = Cities.Count + 1,
            c_name = name
        });
        public List<T> GetCities() => Cities;
        public List<T> GetCitiesByName(string name) => Cities.Where(elem => elem.c_name.Contains(name)).ToList();
    }
}
