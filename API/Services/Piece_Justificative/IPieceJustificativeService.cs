using Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
   public interface IPieceJustificativeService
    {
        PieceJustificative GetById(int Id);
        void AddPieceJustificative(PieceJustificative P);
        IEnumerable<PieceJustificative> GetPieceJustificatives();
    }
}
