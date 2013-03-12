using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQSelectMany
{
    public class Professor
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public List<Materia> MateriasConhecidas { get; set; }
    }
}
