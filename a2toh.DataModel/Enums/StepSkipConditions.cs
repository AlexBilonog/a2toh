using T4TS;

namespace FRS.Common.Enums
{
    [TypeScriptEnum]
    public enum StepSkipConditions
    {
        Company = 1,
        Department = 2,
        CostCenter = 3,
        EventType = 4,
        EventDuration = 5,
        TotalParticipants = 6,
        NotParticipated = 7,
        Participated = 8,
        TotalCostPlanned = 9,
        TotalCostActual = 10,
        BasicField = 11
    }
}
