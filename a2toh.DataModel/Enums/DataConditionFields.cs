using T4TS;

namespace FRS.Common.Enums
{
    [TypeScriptEnum]
    public enum DataConditionFields
    {
        EventNo = 1,
        Company = 2,
        Department = 3,
        CostCenter = 4,
        Name = 5,
        ProjectNumber = 6,
        EventType = 7,
        Reason = 8,
        StartDate = 9,
        FinishDate = 10,
        Sport = 11,
        CurrentWorkflowStep = 12,
        LastChangeDateTime = 13,
        Event = 14,
        PlannedAttendees = 15,
        ActualAttendees = 16,
        PlannedCosts = 17,
        ActualCosts = 18,
        BasicField = 19,
        CreationUser = 20 // special technical value
    }
}
