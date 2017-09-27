using T4TS;

namespace FRS.Common.Enums
{
    [TypeScriptEnum]
    public enum ConditionCriteriaOperators
    {
        Equal = 1,
        NotEqual = 2,
        GreaterThan = 3,
        LessThan = 4,
        Like = 5,
        NotLike = 6,
        GreaterThanOrEqual = 7,
        LessThanOrEqual = 8
    }
}
