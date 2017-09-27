using System.Collections.Generic;

namespace FRS.Business.Scripting.Contracts
{
    public interface IErrorMessagesContainer
    {
        List<MessageDto> Messages { get; set; }
    }
}
