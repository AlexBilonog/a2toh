using T4TS;

namespace FRS.Common.Enums
{
    [TypeScriptEnum]
    public enum EventStatuses
    {
        Initial = 1,
        EventRequest = 2,
        Approved = 3,
        Rejected = 4,
        Calculated = 5,
        Booked = 6,
        BookingNotPossible = 7,
        Closed = 8,
        Cancellation = 10,
        Deprecated = 11
    }
}
