using T4TS;

namespace FRS.Common.Enums
{
    [TypeScriptEnum]
    public enum CostAllocationStatuses
    {
        NotCommitted = 1,
        PartiallyCommitted = 2,
        Committed = 3
    }
}
