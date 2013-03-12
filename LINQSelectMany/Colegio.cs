using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQSelectMany
{
    public class Colegio
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public List<Professor> Professores { get; set; }

        public Colegio()
        {
            Professores = new List<Professor>();
        }
    }
}
