namespace FRS.Common.Enums
{
    //[Flags]
    public enum EventUpdateType
    {
        WithoutCalculationChanges = 1,
        CalculationChanged = 2,
        CustomizationChanged = 4
    }
}
