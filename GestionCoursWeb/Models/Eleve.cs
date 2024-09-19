using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCours.Model
{
    public  class Eleve
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public string Email { get; set; }   
               
        public string Address { get; set; } 

        public string Ville { get; set; }

        public string CodePostal { get; set; }  

        public List<Promotion> Promotions { get;  } = new List<Promotion>();

        public override string ToString()
        {
            return $"{Prenom} {Nom} ";
        }
    }
}
