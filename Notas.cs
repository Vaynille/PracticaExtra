using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppCS1.ViewModels
{
    public class Notas
    {
        public Notas(string materia, decimal nota)
        {
            this.materia = materia;
            this.nota = nota;
        }
        public string materia { get; set; }
        public decimal nota { get; set; }
    }
}