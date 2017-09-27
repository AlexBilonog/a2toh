namespace FRS.Business.EmailNotifications
{
    public enum EmailType
    {
        ResetPassword,
        CreateUser,
        EventTypeUpdate,
        EventCalculationChanged,
        EventCustomizationChanged,
        EventClosed,
        WorkflowTransition,
        RepresentativePersonActiveType,
        RepresentativePersonPassiveType,
        BasicDataChanged,
        DeclarationDateCreated,
        EventRequestNotification,
        EventRequestReplyNotification,
        EventCanceled,
        EventDeadline,
        CostAllocationNotification,
        EventCanceledCopied,
        MoveToActualPhase,
        MoveToActualPhaseWithProjectNumber,
        /// <summary>For adidas</summary>
        EventReservedPlacesNotification,
        /// <summary>For adidas</summary>
        VipLoungeBasicDataStepFinished,
        /// <summary>For adidas</summary>
        VipLoungeCostStepFinished
    }
}
