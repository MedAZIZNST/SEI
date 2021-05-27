using API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Entities
{
    public class Demande
    {
        public Demande()
        {
            Piece_Justificative = new HashSet<PieceJustificative>();

        }

        public int Id { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public String comment { get; set; }
        public int nbj { get; set; }
       
        public int etat { get; set; } // 1 valider 2 rejeter 3 enattent
         
       
        public DateTime? Created_at_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int TypeCongeId { get; set; }
        public virtual TypeConge TypeConge { get; set; }

        public virtual ICollection<PieceJustificative> Piece_Justificative { get; set; }

    }
}
