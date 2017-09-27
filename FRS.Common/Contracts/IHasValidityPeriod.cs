using System;

namespace FRS.Common.Contracts
{
    public interface IHasValidityPeriod
    {
        DateTime ValidFromDate { get; set; }
        DateTime ValidToDate { get; set; }
    }
}
