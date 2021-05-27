using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Entities
{
    public class PieceJustificative
    {
        public PieceJustificative()
        {
        }

        public int Id { get; set; }
        public String NomPiece { get; set; }
        public String TypeFormatPiece { get; set; }
        public DateTime? Updated_at { get; set; }
        public int DemandeId { get; set; }
        public virtual Demande Demande { get; set; }


    }
}
