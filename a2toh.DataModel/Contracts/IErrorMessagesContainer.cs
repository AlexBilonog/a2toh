using System.Collections.Generic;

namespace EventManager.Business.Scripting.Contracts
{
    public interface IErrorMessagesContainer
    {
        List<MessageDto> Messages { get; set; }
    }
}
