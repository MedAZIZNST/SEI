using System;

namespace Enums
{
    public enum WorkflowEnum
    {
        New = 1,
        Valid = 2,
        waiting = 3,
        Rejected = 4
    }

    public enum BonLivraisonEnum
    {
        EnAttent = 1,
        Annulée = 2,
        Terninée = 3,
    }

    public enum FactureEnum
    {
        NonPayée = 1,
        Partiellement = 2,
        Payée = 3,
    }
    public enum CmdEnum
    {
        EnAttent = 1,
        Annulée = 2,
        Prête = 3,
        Terminée = 4,
    }
}
