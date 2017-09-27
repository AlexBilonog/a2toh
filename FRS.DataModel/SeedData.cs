using FRS.Common;
using FRS.DataModel.Entities;

namespace FRS.DataModel
{
    public class SeedData
    {
        public void Seed()
        {
            using (var context = new FRSDbContext())
            {
                context.AddOrUpdateSeed(null,
                    new AttendeeAccessory { ID = 1, Name = "External" },
                    new AttendeeAccessory { ID = 2, Name = "Internal" });

                context.AddOrUpdateSeed(null,
                    new AttendeeSalutation { ID = 1, Name = "Mr" },
                    new AttendeeSalutation { ID = 2, Name = "Ms" });

                context.AddOrUpdateSeed(null,
                    new BasicFieldDictionaryType { ID = 1, Name = "Department" },
                    new BasicFieldDictionaryType { ID = 2, Name = "CostCenter" },
                    new BasicFieldDictionaryType { ID = 3, Name = "Company" });

                context.AddOrUpdateSeed(null,
                    new BasicFieldType { ID = 1, Name = "Text" },
                    new BasicFieldType { ID = 2, Name = "Description" },
                    new BasicFieldType { ID = 3, Name = "Dictionary" },
                    new BasicFieldType { ID = 4, Name = "Date" },
                    new BasicFieldType { ID = 5, Name = "Checkbox" },
                    new BasicFieldType { ID = 6, Name = "RadioButton" });

                context.AddOrUpdateSeed(null,
                    new ConditionCriteriaOperator { ID = 1, Name = "Equal" },
                    new ConditionCriteriaOperator { ID = 2, Name = "NotEqual" },
                    new ConditionCriteriaOperator { ID = 3, Name = "GreaterThan" },
                    new ConditionCriteriaOperator { ID = 4, Name = "LessThan" },
                    new ConditionCriteriaOperator { ID = 5, Name = "Like" },
                    new ConditionCriteriaOperator { ID = 6, Name = "NotLike" },
                    new ConditionCriteriaOperator { ID = 7, Name = "GreaterThanOrEqual" },
                    new ConditionCriteriaOperator { ID = 8, Name = "LessThanOrEqual" });

                context.AddOrUpdateSeed(null,
                    new ConditionOperator { ID = 1, Name = "And" },
                    new ConditionOperator { ID = 2, Name = "Or" },
                    new ConditionOperator { ID = 3, Name = "AndNot" });

                context.AddOrUpdateSeed(null,
                    new CostAllocationStatuss { ID = 1, Name = "Not committed" },
                    new CostAllocationStatuss { ID = 2, Name = "Partially committed" },
                    new CostAllocationStatuss { ID = 3, Name = "Committed" });

                context.AddOrUpdateSeed(null,
                    new CostFlexibleFieldType { ID = 1, Name = "RadioButton" },
                    new CostFlexibleFieldType { ID = 2, Name = "CheckBox" },
                    new CostFlexibleFieldType { ID = 3, Name = "Wizard" });

                context.AddOrUpdateSeed(null,
                    new DataConditionField { ID = 1, Name = "EventNo" },
                    new DataConditionField { ID = 2, Name = "Company" },
                    new DataConditionField { ID = 3, Name = "Department" },
                    new DataConditionField { ID = 4, Name = "CostCenter" },
                    new DataConditionField { ID = 5, Name = "Name" },
                    new DataConditionField { ID = 6, Name = "ProjectNumber" },
                    new DataConditionField { ID = 7, Name = "EventType" },
                    new DataConditionField { ID = 8, Name = "Reason" },
                    new DataConditionField { ID = 9, Name = "StartDate" },
                    new DataConditionField { ID = 10, Name = "FinishDate" },
                    new DataConditionField { ID = 11, Name = "Sport" },
                    new DataConditionField { ID = 12, Name = "CurrentWorkflowStep" },
                    new DataConditionField { ID = 13, Name = "LastChangeDateTime" },
                    new DataConditionField { ID = 14, Name = "Event" },
                    new DataConditionField { ID = 15, Name = "PlannedAttendees" },
                    new DataConditionField { ID = 16, Name = "ActualAttendees" },
                    new DataConditionField { ID = 17, Name = "PlannedCosts" },
                    new DataConditionField { ID = 18, Name = "ActualCosts" },
                    new DataConditionField { ID = 19, Name = "BasicField" });

                context.AddOrUpdateSeed(null,
                    new EventStatuss { ID = 1, Name = "Initial" },
                    new EventStatuss { ID = 2, Name = "Event request" },
                    new EventStatuss { ID = 3, Name = "Approved" },
                    new EventStatuss { ID = 4, Name = "Rejected" },
                    new EventStatuss { ID = 5, Name = "Calculated" },
                    new EventStatuss { ID = 6, Name = "Booked" },
                    new EventStatuss { ID = 7, Name = "Booking not possible" },
                    new EventStatuss { ID = 8, Name = "Closed" },
                    //
                    new EventStatuss { ID = 10, Name = "Cancellation" },
                    new EventStatuss { ID = 11, Name = "Deprecated" });

                context.AddOrUpdateSeed(null,
                    new EventUserNotificationRecipientType { ID = 1, Name = "DefaultUser" },
                    new EventUserNotificationRecipientType { ID = 2, Name = "SendRequestUser" },
                    new EventUserNotificationRecipientType { ID = 3, Name = "ReplyRequestUser" },
                    new EventUserNotificationRecipientType { ID = 4, Name = "GeneralNotificationUser" });

                context.AddOrUpdateSeed(null,
                    new LoggingActionModule { ID = 1, Name = "User" },
                    new LoggingActionModule { ID = 2, Name = "Event Status Cockpit" },
                    new LoggingActionModule { ID = 3, Name = "Event" },
                    new LoggingActionModule { ID = 4, Name = "Global attendees" },
                    new LoggingActionModule { ID = 5, Name = "Administration" },
                    new LoggingActionModule { ID = 6, Name = "Create report" },
                    new LoggingActionModule { ID = 7, Name = "Cost allocation" },
                    new LoggingActionModule { ID = 8, Name = "Event Dates Cockpit" },
                    new LoggingActionModule { ID = 9, Name = "Sports" });

                // Previous before next

                context.AddOrUpdateSeed(null,
                    new LoggingAction { ID = 1, Name = "Login", LoggingActionModuleID = 1 },
                    new LoggingAction { ID = 2, Name = "Logout", LoggingActionModuleID = 1 },
                    new LoggingAction { ID = 3, Name = "Change password", LoggingActionModuleID = 1 },
                    new LoggingAction { ID = 4, Name = "Reset password", LoggingActionModuleID = 1 },
                    new LoggingAction { ID = 5, Name = "Copy event", LoggingActionModuleID = 2 },
                    new LoggingAction { ID = 6, Name = "Create event", LoggingActionModuleID = 3 },
                    new LoggingAction { ID = 7, Name = "Edit basic data", LoggingActionModuleID = 3 },
                    new LoggingAction { ID = 8, Name = "Import attendees", LoggingActionModuleID = 3 },
                    new LoggingAction { ID = 9, Name = "Delete assigned attendee", LoggingActionModuleID = 3 },
                    new LoggingAction { ID = 10, Name = "Assign attendee", LoggingActionModuleID = 3 },
                    new LoggingAction { ID = 11, Name = "Edit agenda", LoggingActionModuleID = 3 },
                    new LoggingAction { ID = 12, Name = "Cost modification", LoggingActionModuleID = 3 },
                    new LoggingAction { ID = 13, Name = "Import costs", LoggingActionModuleID = 3 },
                    new LoggingAction { ID = 14, Name = "Copy costs", LoggingActionModuleID = 3 },
                    new LoggingAction { ID = 15, Name = "Action execution", LoggingActionModuleID = 3 },
                    new LoggingAction { ID = 16, Name = "Change deadline", LoggingActionModuleID = 3 },
                    new LoggingAction { ID = 17, Name = "Edit attendee", LoggingActionModuleID = 3 },
                    new LoggingAction { ID = 18, Name = "Assign to event", LoggingActionModuleID = 4 },
                    new LoggingAction { ID = 19, Name = "Set attendee to inactive", LoggingActionModuleID = 4 },
                    new LoggingAction { ID = 20, Name = "Create user", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 21, Name = "Edit user data", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 22, Name = "Change user password", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 23, Name = "Lock user", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 24, Name = "Unlock user", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 25, Name = "Role modification", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 26, Name = "Role to user assignment", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 27, Name = "Datarole to user assignment", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 28, Name = "Datarole modification", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 29, Name = "Import companies", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 30, Name = "Set company to active/inactive", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 31, Name = "Edit company", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 32, Name = "Import departments", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 33, Name = "Set department to active/inactive", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 34, Name = "Edit department", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 35, Name = "Import cost centers", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 36, Name = "Set cost center to active/inactive", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 37, Name = "Edit cost center", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 38, Name = "Edit workflow step", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 39, Name = "Delete workflow step", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 40, Name = "Create workflow", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 41, Name = "Edit workflow", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 42, Name = "Import customization", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 43, Name = "Set event type to active/inactive", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 44, Name = "VIP Lounge creation", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 45, Name = "VIP Lounge - modification", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 46, Name = "VIP Lounge - releasing", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 47, Name = "VIP Lounge - set date as not available", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 48, Name = "Update document for event", LoggingActionModuleID = 3 },
                    new LoggingAction { ID = 49, Name = "Delete document for event", LoggingActionModuleID = 3 },
                    new LoggingAction { ID = 50, Name = "VIP Lounge - set to active/incative", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 51, Name = "Edit E-mail template", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 52, Name = "Event version update", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 53, Name = "Edit booking suggestion mapping", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 54, Name = "Edit workflow step permission", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 55, Name = "Delete workflow step permission", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 56, Name = "Add substitute", LoggingActionModuleID = 1 },
                    new LoggingAction { ID = 57, Name = "Deactivate substitute", LoggingActionModuleID = 1 },
                    new LoggingAction { ID = 58, Name = "Login as substitute", LoggingActionModuleID = 1 },
                    new LoggingAction { ID = 59, Name = "Wage type mappings modification", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 60, Name = "Mapping event types modification", LoggingActionModuleID = 5, },
                    new LoggingAction { ID = 61, Name = "Wage type taxation. Edit Transferred checkbox", LoggingActionModuleID = 6, },
                    new LoggingAction { ID = 62, Name = "Social security. Edit Transferred checkbox", LoggingActionModuleID = 6 },
                    new LoggingAction { ID = 63, Name = "Cost was marked as Clearing Cost", LoggingActionModuleID = 7 },
                    new LoggingAction { ID = 64, Name = "Costs were allocated to event", LoggingActionModuleID = 7 },
                    new LoggingAction { ID = 65, Name = "Costs were allocated to cost category", LoggingActionModuleID = 7 },
                    new LoggingAction { ID = 66, Name = "Allocation to event was reset", LoggingActionModuleID = 7 },
                    new LoggingAction { ID = 67, Name = "Allocation to cost category was reset", LoggingActionModuleID = 7 },
                    new LoggingAction { ID = 68, Name = "Allocation was commited", LoggingActionModuleID = 7 },
                    new LoggingAction { ID = 69, Name = "Cost was marked as irrelevant", LoggingActionModuleID = 7 },
                    new LoggingAction { ID = 71, Name = "Import teams", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 72, Name = "Import order numbers", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 77, Name = "Create order number", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 78, Name = "Update order number", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 79, Name = "Create competitor", LoggingActionModuleID = 8 },
                    new LoggingAction { ID = 80, Name = "Update competitor", LoggingActionModuleID = 8 },
                    new LoggingAction { ID = 81, Name = "Delete competitor", LoggingActionModuleID = 8 },
                    new LoggingAction { ID = 82, Name = "Create season", LoggingActionModuleID = 8 },
                    new LoggingAction { ID = 83, Name = "Update season", LoggingActionModuleID = 8 },
                    new LoggingAction { ID = 84, Name = "Delete season", LoggingActionModuleID = 8 },
                    new LoggingAction { ID = 85, Name = "Import dates", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 86, Name = "Create team", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 87, Name = "Update team", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 88, Name = "Create Sport to department connection", LoggingActionModuleID = 9 },
                    new LoggingAction { ID = 89, Name = "Update Sport to department connection", LoggingActionModuleID = 9 },
                    new LoggingAction { ID = 90, Name = "Create Sport", LoggingActionModuleID = 9 },
                    new LoggingAction { ID = 91, Name = "Update Sport", LoggingActionModuleID = 9 },
                    new LoggingAction { ID = 95, Name = "Vip Lounge Basic Fields Updated", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 96, Name = "Update VipLounge Place", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 97, Name = "VipLounge Copied", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 98, Name = "Event Cancelled", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 99, Name = "Event Reserved Places Notification Email Sent", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 100, Name = "Create VipLounge Place", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 101, Name = "Assign attendee update", LoggingActionModuleID = 3 },
                    new LoggingAction { ID = 104, Name = "New attendee", LoggingActionModuleID = 3 },
                    new LoggingAction { ID = 105, Name = "Add permission to role", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 106, Name = "Remove permission from role", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 107, Name = "Update permission to role assignment", LoggingActionModuleID = 5 },
                    new LoggingAction { ID = 108, Name = "Limit 10K euro. Edit Processed checkbox", LoggingActionModuleID = 6 },
                    new LoggingAction { ID = 109, Name = "Limit 35 euro. Edit Processed checkbox", LoggingActionModuleID = 6 }
                    );

                context.AddOrUpdateSeed(null,
                    new PermissionType { ID = 1, Name = "Module" },
                    new PermissionType { ID = 2, Name = "Feature" },
                    new PermissionType { ID = 3, Name = "Workflow step execution" },
                    new PermissionType { ID = 4, Name = "Rest service access" });

                // Previous before next

                context.AddOrUpdateSeed(null,
                    new Permission { ID = 1, PermissionTypeID = 1, Description = "Event creation" },
                    new Permission { ID = 2, PermissionTypeID = 1, Description = "Event status cockpit" },
                    //
                    new Permission { ID = 4, PermissionTypeID = 1, Description = "Attendees" },
                    //
                    new Permission { ID = 6, PermissionTypeID = 1, Description = "User administration" },
                    new Permission { ID = 7, PermissionTypeID = 1, Description = "Master data" },
                    new Permission { ID = 8, PermissionTypeID = 1, Description = "Workflow administration" },
                    new Permission { ID = 9, PermissionTypeID = 1, Description = "Customization" },
                    new Permission { ID = 10, PermissionTypeID = 1, Description = "Event types" },
                    new Permission { ID = 11, PermissionTypeID = 1, Description = "VIP Lounge" },
                    new Permission { ID = 12, PermissionTypeID = 1, Description = "Logs" },
                    new Permission { ID = 13, PermissionTypeID = 1, Description = "Email editor" },
                    new Permission { ID = 14, PermissionTypeID = 1, Description = "Mapping event types" },
                    new Permission { ID = 15, PermissionTypeID = 1, Description = "Translations" },
                    new Permission { ID = 16, PermissionTypeID = 2, Description = "Costs import" },
                    new Permission { ID = 17, PermissionTypeID = 1, Description = "Cost allocation page" },
                    //
                    new Permission { ID = 19, PermissionTypeID = 1, Description = "License administration" },
                    new Permission { ID = 20, PermissionTypeID = 2, Description = "Copy event" },
                    new Permission { ID = 21, PermissionTypeID = 2, Description = "Edit VIP Lounge" },
                    new Permission { ID = 22, PermissionTypeID = 2, Description = "Release VIP Lounge" },
                    new Permission { ID = 23, PermissionTypeID = 2, Description = "Deactivate VIP Lounge" },
                    //
                    new Permission { ID = 30, PermissionTypeID = 2, Description = "Read planned costs" },
                    new Permission { ID = 31, PermissionTypeID = 2, Description = "Edit planned costs" },
                    new Permission { ID = 32, PermissionTypeID = 2, Description = "Read actual costs" },
                    new Permission { ID = 33, PermissionTypeID = 2, Description = "Edit actual costs" },
                    new Permission { ID = 34, PermissionTypeID = 2, Description = "Read costs documents" },
                    new Permission { ID = 35, PermissionTypeID = 2, Description = "Upload costs documents" },
                    new Permission { ID = 36, PermissionTypeID = 2, Description = "Edit costs documents" },
                    new Permission { ID = 37, PermissionTypeID = 2, Description = "Read basic data" },
                    new Permission { ID = 38, PermissionTypeID = 2, Description = "Edit basic data" },
                    new Permission { ID = 39, PermissionTypeID = 2, Description = "Read planned agenda" },
                    new Permission { ID = 40, PermissionTypeID = 2, Description = "Edit planned agenda" },
                    new Permission { ID = 41, PermissionTypeID = 2, Description = "Read booking suggestions" },
                    //
                    new Permission { ID = 43, PermissionTypeID = 2, Description = "Read actual agenda" },
                    new Permission { ID = 44, PermissionTypeID = 2, Description = "Edit actual agenda" },
                    new Permission { ID = 45, PermissionTypeID = 2, Description = "Cancel and copy event" },
                    new Permission { ID = 46, PermissionTypeID = 2, Description = "Edit costs flexible fields" },
                    new Permission { ID = 47, PermissionTypeID = 2, Description = "Change attendee attribute from technical to manual" },
                    new Permission { ID = 48, PermissionTypeID = 2, Description = "See personal number" },
                    new Permission { ID = 49, PermissionTypeID = 2, Description = "Update event version" },
                    new Permission { ID = 50, PermissionTypeID = 4, Description = "Rest service access" },
                    new Permission { ID = 51, PermissionTypeID = 2, Description = "Edit Internal attendees" },
                    new Permission { ID = 52, PermissionTypeID = 2, Description = "Edit External attendees" },
                    new Permission { ID = 53, PermissionTypeID = 2, Description = "Batch go to next step" },
                    new Permission { ID = 54, PermissionTypeID = 2, Description = "Select workflow step after reject" },
                    new Permission { ID = 55, PermissionTypeID = 2, Description = "Read planned attendees" },
                    new Permission { ID = 56, PermissionTypeID = 2, Description = "Read actual attendees" },
                    new Permission { ID = 57, PermissionTypeID = 2, Description = "Edit planned attendees" },
                    new Permission { ID = 58, PermissionTypeID = 2, Description = "Edit actual attendees" },
                    new Permission { ID = 59, PermissionTypeID = 1, Description = "Wage type taxation" },
                    new Permission { ID = 60, PermissionTypeID = 2, Description = "Wage type taxation. Edit Transferred checkbox" },
                    new Permission { ID = 61, PermissionTypeID = 1, Description = "Corporate event" },
                    new Permission { ID = 62, PermissionTypeID = 1, Description = "Social security" },
                    new Permission { ID = 64, PermissionTypeID = 1, Description = "Stock of Gifts" },
                    new Permission { ID = 65, PermissionTypeID = 2, Description = "Manage event gifts" },
                    new Permission { ID = 66, PermissionTypeID = 2, Description = "Social security. Edit Transferred checkbox" },
                    new Permission { ID = 68, PermissionTypeID = 2, Description = "Update event version of closed events" },
                    new Permission { ID = 71, PermissionTypeID = 1, Description = "Costs on-charge" },
                    new Permission { ID = 72, PermissionTypeID = 1, Description = "Booking suggestions report" },
                    new Permission { ID = 73, PermissionTypeID = 1, Description = "Tickets Cockpit" },
                    new Permission { ID = 76, PermissionTypeID = 1, Description = "Event Dates Cockpit" },
                    new Permission { ID = 77, PermissionTypeID = 1, Description = "Limit 10K euro" },
                    new Permission { ID = 78, PermissionTypeID = 2, Description = "Limit 10K euro. Edit Processed checkbox" },
                    new Permission { ID = 79, PermissionTypeID = 1, Description = "Limit 35 euro" },
                    new Permission { ID = 80, PermissionTypeID = 2, Description = "Limit 35 euro. Edit Processed checkbox" });

                context.AddOrUpdateSeed(null,
                    new Role { ID = 1, Name = "RestAccess" },
                    new Role { ID = 2, Name = "Administrators" });

                // Previous before next

                context.AddOrUpdateSeed((existing, @new) => existing.PermissionID == @new.PermissionID && existing.RoleID == @new.RoleID,
                    new PermissionRole { PermissionID = 50, RoleID = 1 },

                    new PermissionRole { PermissionID = 1, RoleID = 2 },
                    new PermissionRole { PermissionID = 2, RoleID = 2 },
                    //
                    new PermissionRole { PermissionID = 4, RoleID = 2 },
                    //
                    new PermissionRole { PermissionID = 6, RoleID = 2 },
                    new PermissionRole { PermissionID = 7, RoleID = 2 },
                    new PermissionRole { PermissionID = 8, RoleID = 2 },
                    new PermissionRole { PermissionID = 9, RoleID = 2 },
                    new PermissionRole { PermissionID = 10, RoleID = 2 },
                    new PermissionRole { PermissionID = 11, RoleID = 2 },
                    new PermissionRole { PermissionID = 12, RoleID = 2 },
                    new PermissionRole { PermissionID = 13, RoleID = 2 },
                    //new PermissionRole { PermissionID = 14, RoleID = 2 },
                    new PermissionRole { PermissionID = 15, RoleID = 2 },
                    new PermissionRole { PermissionID = 16, RoleID = 2 },
                    new PermissionRole { PermissionID = 17, RoleID = 2 },
                    new PermissionRole { PermissionID = 19, RoleID = 2 },
                    //
                    new PermissionRole { PermissionID = 20, RoleID = 2 },
                    new PermissionRole { PermissionID = 21, RoleID = 2 },
                    new PermissionRole { PermissionID = 22, RoleID = 2 },
                    new PermissionRole { PermissionID = 23, RoleID = 2 },
                    //
                    new PermissionRole { PermissionID = 30, RoleID = 2 },
                    new PermissionRole { PermissionID = 31, RoleID = 2 },
                    new PermissionRole { PermissionID = 32, RoleID = 2 },
                    new PermissionRole { PermissionID = 33, RoleID = 2 },
                    new PermissionRole { PermissionID = 34, RoleID = 2 },
                    new PermissionRole { PermissionID = 35, RoleID = 2 },
                    new PermissionRole { PermissionID = 36, RoleID = 2 },
                    new PermissionRole { PermissionID = 37, RoleID = 2 },
                    new PermissionRole { PermissionID = 38, RoleID = 2 },
                    new PermissionRole { PermissionID = 39, RoleID = 2 },
                    new PermissionRole { PermissionID = 40, RoleID = 2 },
                    new PermissionRole { PermissionID = 41, RoleID = 2 },
                    //
                    new PermissionRole { PermissionID = 43, RoleID = 2 },
                    new PermissionRole { PermissionID = 44, RoleID = 2 },
                    new PermissionRole { PermissionID = 45, RoleID = 2 },
                    new PermissionRole { PermissionID = 46, RoleID = 2 },
                    new PermissionRole { PermissionID = 47, RoleID = 2 },
                    new PermissionRole { PermissionID = 48, RoleID = 2 },
                    new PermissionRole { PermissionID = 49, RoleID = 2 },
                    new PermissionRole { PermissionID = 50, RoleID = 2 },
                    new PermissionRole { PermissionID = 51, RoleID = 2 },
                    new PermissionRole { PermissionID = 52, RoleID = 2 },
                    new PermissionRole { PermissionID = 53, RoleID = 2 },
                    new PermissionRole { PermissionID = 54, RoleID = 2 },
                    new PermissionRole { PermissionID = 55, RoleID = 2 },
                    new PermissionRole { PermissionID = 56, RoleID = 2 },
                    new PermissionRole { PermissionID = 57, RoleID = 2 },
                    new PermissionRole { PermissionID = 58, RoleID = 2 },
                    new PermissionRole { PermissionID = 59, RoleID = 2 },
                    new PermissionRole { PermissionID = 60, RoleID = 2 },
                    new PermissionRole { PermissionID = 61, RoleID = 2 },
                    new PermissionRole { PermissionID = 62, RoleID = 2 },
                    new PermissionRole { PermissionID = 64, RoleID = 2 },
                    new PermissionRole { PermissionID = 65, RoleID = 2 },
                    new PermissionRole { PermissionID = 66, RoleID = 2 },
                    new PermissionRole { PermissionID = 68, RoleID = 2 },
                    new PermissionRole { PermissionID = 71, RoleID = 2 },
                    new PermissionRole { PermissionID = 72, RoleID = 2 },
                    new PermissionRole { PermissionID = 73, RoleID = 2 },
                    new PermissionRole { PermissionID = 76, RoleID = 2 },
                    new PermissionRole { PermissionID = 77, RoleID = 2 },
                    new PermissionRole { PermissionID = 78, RoleID = 2 },
                    new PermissionRole { PermissionID = 79, RoleID = 2 },
                    new PermissionRole { PermissionID = 80, RoleID = 2 });

                context.AddOrUpdateSeed(null,
                    new SourceType { ID = 1, Name = "Manual" },
                    new SourceType { ID = 2, Name = "Csv" },
                    new SourceType { ID = 3, Name = "RestApi" });

                // Previous before next

                context.AddOrUpdateSeed(null,
                    new StepSkipCondition { ID = 1, Name = "Company" },
                    new StepSkipCondition { ID = 2, Name = "Department" },
                    new StepSkipCondition { ID = 3, Name = "CostCenter" },
                    new StepSkipCondition { ID = 4, Name = "EventType" },
                    new StepSkipCondition { ID = 5, Name = "EventDuration" },
                    new StepSkipCondition { ID = 6, Name = "TotalParticipants" },
                    new StepSkipCondition { ID = 7, Name = "NotParticipated" },
                    new StepSkipCondition { ID = 8, Name = "Participated" },
                    new StepSkipCondition { ID = 9, Name = "TotalCostPlanned" },
                    new StepSkipCondition { ID = 10, Name = "TotalCostActual" },
                    new StepSkipCondition { ID = 11, Name = "BasicField" });

                context.AddOrUpdateSeed(null,
                    new Taxation { ID = 1, Name = "Deutschland" },
                    new Taxation { ID = 2, Name = "außerhalb Deutschland" });

                context.AddOrUpdateSeed(null,
                    new User
                    {
                        ID = 1,
                        Password = "AG8YFAuDP5RVRnZAYSJoNlSyLJ4DgUtAQ2RJYqR/y1Ivo/aZqKCadksGUsO1kZ1yRQ==",
                        Email = "em_admin@evolvice.de",
                        FirstName = "Admin",
                        LastName = "Admin"
                    },
                    new User
                    {
                        ID = 1000,
                        Password = "AAnZGvZ/4Sh1bTFReQiV5BfC2ZxSIfZLizWTI2PCDRsOVdD/KN1KCE3wuzTOc5hP3A==",
                        Email = "restuser@evolvice.de",
                        FirstName = "RestUser",
                        LastName = "RestUser"
                    });

                context.AddOrUpdateSeed(null,
                    new DataRole { ID = 1000, Name = "RestAccess" },
                    new DataRole { ID = 1001, Name = "Administrators" });

                // Previous before next

                context.AddOrUpdateSeed((r, e) => e.UserID == r.UserID && e.RoleID == r.RoleID,
                    new UserRole { UserID = 1, RoleID = 2, DataRoleIDs = "1001" },
                    new UserRole { UserID = 1000, RoleID = 1, DataRoleIDs = "1000" });

                context.AddOrUpdateSeed(null,
                    new WorkflowStepType { ID = 1, Name = "Initial" },
                    new WorkflowStepType { ID = 2, Name = "Approving" },
                    new WorkflowStepType { ID = 3, Name = "Accounting" },
                    new WorkflowStepType { ID = 4, Name = "Booking" });

                // Previous before next

                context.AddOrUpdateSeed(null,
                    new WorkflowStepTypeAction { ID = 1, Name = "Cancellation", Description = "Cancellation of event", WorkflowStepTypeID = 1 },
                    new WorkflowStepTypeAction { ID = 2, Name = "ForApproval", Description = "Event for approval", WorkflowStepTypeID = 1 },
                    new WorkflowStepTypeAction { ID = 3, Name = "Reject", Description = "Event reject", WorkflowStepTypeID = 2 },
                    new WorkflowStepTypeAction { ID = 4, Name = "Approve", Description = "Event approve", WorkflowStepTypeID = 2 },
                    new WorkflowStepTypeAction { ID = 5, Name = "AccountingReject", Description = "Event cancelled", WorkflowStepTypeID = 3 },
                    new WorkflowStepTypeAction { ID = 6, Name = "ForBooking", Description = "Event for booking", WorkflowStepTypeID = 3 },
                    new WorkflowStepTypeAction { ID = 7, Name = "BookingNotPossible", Description = "Event booking not possible", WorkflowStepTypeID = 4 },
                    new WorkflowStepTypeAction { ID = 8, Name = "Booked", Description = "Event booked", WorkflowStepTypeID = 4 });

                context.AddOrUpdateSeed(null,
                    new Tournament { ID = 1, Name = "Bundesliga" },
                    new Tournament { ID = 2, Name = "DFB-Pokal" },
                    new Tournament { ID = 3, Name = "Champions League" },
                    new Tournament { ID = 4, Name = "Euro League" },
                    new Tournament { ID = 5, Name = "Other" });
            }
        }
    }
}
