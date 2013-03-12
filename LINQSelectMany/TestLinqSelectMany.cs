using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQSelectMany
{
    public class TestLinqSelectMany
    {
        List<Colegio> colegios = null;
        public TestLinqSelectMany()
        {
            colegios = ColegioFactory.GerarColegios();
        }

        public void TestarSelectMany()
        {
            Materia materia = Materia.Matematica;

            List<Professor> professoresQueConhecemAMateria_ForEach = SelecionarProfessoresDosColegiosPorMateriaUtilizandoForEach(materia);
            List<Professor> professoresQueConhecemAMateria_SelectMany = SelecionarProfessoresDosColegiosPorMateriaUtilizandoForEach(materia);

            Console.WriteLine("Fizemos um teste, filtrando de todos os colégios, todos os professores que conhecem a matéria Matemátia para lecionar");
            Console.WriteLine("Filtramos de 2 formas, uma utilizando o ForEach outra utilizando o SelectMany");
            Console.WriteLine("Para provar que as 2 formas retornam o mesmo resultado, iremos printar os ids dos funcionários encontrados em cada um dos métodos");
            Console.WriteLine("{0}Utilizando ForEach:{0}{1}", Environment.NewLine, String.Join(", ", professoresQueConhecemAMateria_ForEach.Select(prof => prof.ID)));
            Console.WriteLine("{0}Utilizando Select Many:{0}{1}", Environment.NewLine, String.Join(", ", professoresQueConhecemAMateria_SelectMany.Select(prof => prof.ID)));
            Console.ReadKey();
        }

        private List<Professor> SelecionarProfessoresDosColegiosPorMateriaUtilizandoForEach(Materia materia)
        {
            List<Professor> professores = new List<Professor>();

            foreach (Colegio colegio in colegios)
            {
                foreach (Professor professor in FiltrarProfessoresQueConhecemMateria(colegio.Professores, materia))
                {
                    professores.Add(professor);
                }
            }

            return professores;
        }

        private List<Professor> SelecionarProfessoresDosColegiosPorMateriaUtilizandoSelectMany(Materia materia)
        {
            List<Professor> professoresQueConhecemAMateria = colegios.SelectMany(colegio => FiltrarProfessoresQueConhecemMateria(colegio.Professores, materia)).ToList();

            return professoresQueConhecemAMateria;
        }

        private List<string> SelecionarNomeDosProfessoresDosColegiosPorMateriaUtilizandoSelectMany(Materia materia)
        {
            List<string> nomesProfessoresQueConhecemAMateria = colegios.SelectMany(colegio => FiltrarProfessoresQueConhecemMateria(colegio.Professores, materia),
                                                                                   (professores, professor) => professor.Nome).ToList();

            return nomesProfessoresQueConhecemAMateria;
        }

        private List<Professor> FiltrarProfessoresQueConhecemMateria(List<Professor> professores, Materia materia)
        {
            return professores.Where(prof => prof.MateriasConhecidas.Contains(materia)).ToList();
        }
    }
}
