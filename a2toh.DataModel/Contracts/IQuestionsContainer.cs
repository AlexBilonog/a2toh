using EventManager.Business.Scripting.Dto;
using System.Collections.Generic;

namespace EventManager.Business.Scripting.Contracts
{
    public interface IQuestionsContainer
    {
        CostQuestion CostQuestionTree { get; set; }
        List<CostQuestion> CostQuestionList { get; set; }
        List<CostField> CostFields { get; set; }
    }
}
