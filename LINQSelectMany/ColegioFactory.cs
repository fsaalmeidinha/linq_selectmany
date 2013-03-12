using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQSelectMany
{
    public class ColegioFactory
    {
        static int idProfessor = 1;
        public static List<Colegio> GerarColegios(int numColegios = 12)
        {
            List<Colegio> colegios = new List<Colegio>();
            for (int i = 0; i < numColegios; i++)
            {
                colegios.Add(new Colegio()
                {
                    ID = i + 1,
                    Professores = GerarProfessores()
                });
            }

            return colegios;
        }

        private static List<Professor> GerarProfessores(int numProfs = 10)
        {
            List<Professor> professores = new List<Professor>();
            for (int i = 0; i < numProfs; i++)
            {
                professores.Add(new Professor()
                {
                    ID = idProfessor++,
                    MateriasConhecidas = EscolherMateriasRandomicamente()
                });
            }

            return professores;
        }

        static Random rand = new Random();
        static int numMateriasDiferentes = 3;
        private static List<Materia> EscolherMateriasRandomicamente()
        {
            int numMaterias = rand.Next(1, numMateriasDiferentes + 1);
            HashSet<Materia> materias = new HashSet<Materia>();

            for (int indMateriaRandomica = 0; indMateriaRandomica < numMaterias; indMateriaRandomica++)
            {
                materias.Add((Materia)rand.Next(1, numMateriasDiferentes + 1));
            }

            return materias.ToList();
        }
    }
}
