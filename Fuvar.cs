using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat
{
    internal class Fuvar
    {
        string taxi_id;
        string indulas;
        int idotartam;
        double tavolsag;
        double viteldij;
        double borravalo;
        string fizetes_modja;

        public Fuvar(string sor)
        {
            string[] tomb = sor.Split(";");
            this.taxi_id = tomb[0];
            this.indulas = tomb[1];
            this.idotartam = int.Parse(tomb[2]);
            this.tavolsag = double.Parse(tomb[3]);
            this.viteldij = double.Parse(tomb[4]);
            this.borravalo = double.Parse(tomb[5]);
            this.fizetes_modja = tomb[6];
        }

        public string Taxi_id { get => taxi_id;}
        public string Indulas { get => indulas;}
        public int Idotartam { get => idotartam;}
        public double Tavolsag { get => tavolsag;}
        public double Viteldij { get => viteldij;}
        public double Borravalo { get => borravalo;}
        public string Fizetes_modja { get => fizetes_modja;}
    }
}
