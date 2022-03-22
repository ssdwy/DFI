using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI_UE4_Gruppe11
{
    class HabitatPflanze
    {
        //private Habitat habitat;
        //private Pflanze pflanze;
        private string habitat_be;
        private string pflanze_be;
        private string habitat_optimal_be;
        private bool ob_optimal;

        //public Habitat Habitat { get => habitat; set => habitat = value; }
        //public Pflanze Pflanze { get => pflanze; set => pflanze = value; }
        public string Habitat_be { get => habitat_be; set => habitat_be = value; }
        public string Pflanze_be { get => pflanze_be; set => pflanze_be = value; }
        public string Habitat_optimal_be { get => habitat_optimal_be; set => habitat_optimal_be = value; }
        public bool Ob_optimal { get => ob_optimal; set => ob_optimal = value; }

        //public HabitatPflanze(Habitat habitat, Pflanze pflanze, string habitat_optimal_be, bool ob_optimal)
        //{
        //    this.Habitat = habitat;
        //    this.Pflanze = pflanze;
        //    pflanze_be = pflanze.Pfl_Bezeichnung;
        //    habitat_be = habitat.Hab_Bezeichnung;
        //    this.Habitat_optimal_be = habitat_optimal_be;
        //    this.Ob_optimal = ob_optimal;

        //}
        public HabitatPflanze(string habitat_be, string pflanze_be, string habitat_optimal_be, bool ob_optimal)
        {
            this.habitat_be = habitat_be;
            this.pflanze_be = pflanze_be;
            this.habitat_optimal_be = habitat_optimal_be;
            this.ob_optimal = ob_optimal;
        }
    }
}
