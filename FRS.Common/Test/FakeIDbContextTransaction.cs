using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace FRS.Common.Test
{
    public class FakeIDbContextTransaction : IDbContextTransaction
    {
        public Guid TransactionId => throw new NotImplementedException();

        public void Commit()
        {
        }

        public void Dispose()
        {
        }

        public void Rollback()
        {
        }
    }
}
