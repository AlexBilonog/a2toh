using FRS.Common;
using FRS.DataModel.Entities;

namespace FRS.DataModel
{
    public class SeedData
    {
        public void Seed()
        {
            using (var context = new FRSContext())
            {
                context.AddOrUpdateSeed(null,
                    new AttendeeAccessory { Id = 1, Name = "External" },
                    new AttendeeAccessory { Id = 2, Name = "Internal" });

                context.AddOrUpdateSeed(null,
                    new AttendeeSalutation { Id = 1, Name = "Mr" },
                    new AttendeeSalutation { Id = 2, Name = "Ms" });

                context.AddOrUpdateSeed(null,
                    new BasicFieldDictionaryType { Id = 1, Name = "Department" },
                    new BasicFieldDictionaryType { Id = 2, Name = "CostCenter" },
                    new BasicFieldDictionaryType { Id = 3, Name = "Company" });

                context.AddOrUpdateSeed(null,
                    new BasicFieldType { Id = 1, Name = "Text" },
                    new BasicFieldType { Id = 2, Name = "Description" },
                    new BasicFieldType { Id = 3, Name = "Dictionary" },
                    new BasicFieldType { Id = 4, Name = "Date" },
                    new BasicFieldType { Id = 5, Name = "Checkbox" },
                    new BasicFieldType { Id = 6, Name = "RadioButton" });

                context.AddOrUpdateSeed(null,
                    new ConditionCriteriaOperator { Id = 1, Name = "Equal" },
                    new ConditionCriteriaOperator { Id = 2, Name = "NotEqual" },
                    new ConditionCriteriaOperator { Id = 3, Name = "GreaterThan" },
                    new ConditionCriteriaOperator { Id = 4, Name = "LessThan" },
                    new ConditionCriteriaOperator { Id = 5, Name = "Like" },
                    new ConditionCriteriaOperator { Id = 6, Name = "NotLike" },
                    new ConditionCriteriaOperator { Id = 7, Name = "GreaterThanOrEqual" },
                    new ConditionCriteriaOperator { Id = 8, Name = "LessThanOrEqual" });

                context.AddOrUpdateSeed(null,
                    new ConditionOperator { Id = 1, Name = "And" },
                    new ConditionOperator { Id = 2, Name = "Or" },
                    new ConditionOperator { Id = 3, Name = "AndNot" });

                context.AddOrUpdateSeed(null,
                    new CostAllocationStatuss { Id = 1, Name = "Not committed" },
                    new CostAllocationStatuss { Id = 2, Name = "Partially committed" },
                    new CostAllocationStatuss { Id = 3, Name = "Committed" });

                context.AddOrUpdateSeed(null,
                    new CostFlexibleFieldType { Id = 1, Name = "RadioButton" },
                    new CostFlexibleFieldType { Id = 2, Name = "CheckBox" },
                    new CostFlexibleFieldType { Id = 3, Name = "Wizard" });

                context.AddOrUpdateSeed(null,
                    new DataConditionField { Id = 1, Name = "EventNo" },
                    new DataConditionField { Id = 2, Name = "Company" },
                    new DataConditionField { Id = 3, Name = "Department" },
                    new DataConditionField { Id = 4, Name = "CostCenter" },
                    new DataConditionField { Id = 5, Name = "Name" },
                    new DataConditionField { Id = 6, Name = "ProjectNumber" },
                    new DataConditionField { Id = 7, Name = "EventType" },
                    new DataConditionField { Id = 8, Name = "Reason" },
                    new DataConditionField { Id = 9, Name = "StartDate" },
                    new DataConditionField { Id = 10, Name = "FinishDate" },
                    new DataConditionField { Id = 11, Name = "Sport" },
                    new DataConditionField { Id = 12, Name = "CurrentWorkflowStep" },
                    new DataConditionField { Id = 13, Name = "LastChangeDateTime" },
                    new DataConditionField { Id = 14, Name = "Event" },
                    new DataConditionField { Id = 15, Name = "PlannedAttendees" },
                    new DataConditionField { Id = 16, Name = "ActualAttendees" },
                    new DataConditionField { Id = 17, Name = "PlannedCosts" },
                    new DataConditionField { Id = 18, Name = "ActualCosts" },
                    new DataConditionField { Id = 19, Name = "BasicField" });

                context.AddOrUpdateSeed(null,
                    new EventStatuss { Id = 1, Name = "Initial" },
                    new EventStatuss { Id = 2, Name = "Event request" },
                    new EventStatuss { Id = 3, Name = "Approved" },
                    new EventStatuss { Id = 4, Name = "Rejected" },
                    new EventStatuss { Id = 5, Name = "Calculated" },
                    new EventStatuss { Id = 6, Name = "Booked" },
                    new EventStatuss { Id = 7, Name = "Booking not possible" },
                    new EventStatuss { Id = 8, Name = "Closed" },
                    //
                    new EventStatuss { Id = 10, Name = "Cancellation" },
                    new EventStatuss { Id = 11, Name = "Deprecated" });

                context.AddOrUpdateSeed(null,
                    new EventUserNotificationRecipientType { Id = 1, Name = "DefaultUser" },
                    new EventUserNotificationRecipientType { Id = 2, Name = "SendRequestUser" },
                    new EventUserNotificationRecipientType { Id = 3, Name = "ReplyRequestUser" },
                    new EventUserNotificationRecipientType { Id = 4, Name = "GeneralNotificationUser" });

                context.AddOrUpdateSeed(null,
                    new LoggingActionModule { Id = 1, Name = "User" },
                    new LoggingActionModule { Id = 2, Name = "Event Status Cockpit" },
                    new LoggingActionModule { Id = 3, Name = "Event" },
                    new LoggingActionModule { Id = 4, Name = "Global attendees" },
                    new LoggingActionModule { Id = 5, Name = "Administration" },
                    new LoggingActionModule { Id = 6, Name = "Create report" },
                    new LoggingActionModule { Id = 7, Name = "Cost allocation" },
                    new LoggingActionModule { Id = 8, Name = "Event Dates Cockpit" },
                    new LoggingActionModule { Id = 9, Name = "Sports" });

                // Previous before next

                context.AddOrUpdateSeed(null,
                    new LoggingAction { Id = 1, Name = "Login", LoggingActionModuleId = 1 },
                    new LoggingAction { Id = 2, Name = "Logout", LoggingActionModuleId = 1 },
                    new LoggingAction { Id = 3, Name = "Change password", LoggingActionModuleId = 1 },
                    new LoggingAction { Id = 4, Name = "Reset password", LoggingActionModuleId = 1 },
                    new LoggingAction { Id = 5, Name = "Copy event", LoggingActionModuleId = 2 },
                    new LoggingAction { Id = 6, Name = "Create event", LoggingActionModuleId = 3 },
                    new LoggingAction { Id = 7, Name = "Edit basic data", LoggingActionModuleId = 3 },
                    new LoggingAction { Id = 8, Name = "Import attendees", LoggingActionModuleId = 3 },
                    new LoggingAction { Id = 9, Name = "Delete assigned attendee", LoggingActionModuleId = 3 },
                    new LoggingAction { Id = 10, Name = "Assign attendee", LoggingActionModuleId = 3 },
                    new LoggingAction { Id = 11, Name = "Edit agenda", LoggingActionModuleId = 3 },
                    new LoggingAction { Id = 12, Name = "Cost modification", LoggingActionModuleId = 3 },
                    new LoggingAction { Id = 13, Name = "Import costs", LoggingActionModuleId = 3 },
                    new LoggingAction { Id = 14, Name = "Copy costs", LoggingActionModuleId = 3 },
                    new LoggingAction { Id = 15, Name = "Action execution", LoggingActionModuleId = 3 },
                    new LoggingAction { Id = 16, Name = "Change deadline", LoggingActionModuleId = 3 },
                    new LoggingAction { Id = 17, Name = "Edit attendee", LoggingActionModuleId = 3 },
                    new LoggingAction { Id = 18, Name = "Assign to event", LoggingActionModuleId = 4 },
                    new LoggingAction { Id = 19, Name = "Set attendee to inactive", LoggingActionModuleId = 4 },
                    new LoggingAction { Id = 20, Name = "Create user", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 21, Name = "Edit user data", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 22, Name = "Change user password", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 23, Name = "Lock user", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 24, Name = "Unlock user", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 25, Name = "Role modification", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 26, Name = "Role to user assignment", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 27, Name = "Datarole to user assignment", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 28, Name = "Datarole modification", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 29, Name = "Import companies", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 30, Name = "Set company to active/inactive", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 31, Name = "Edit company", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 32, Name = "Import departments", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 33, Name = "Set department to active/inactive", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 34, Name = "Edit department", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 35, Name = "Import cost centers", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 36, Name = "Set cost center to active/inactive", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 37, Name = "Edit cost center", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 38, Name = "Edit workflow step", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 39, Name = "Delete workflow step", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 40, Name = "Create workflow", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 41, Name = "Edit workflow", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 42, Name = "Import customization", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 43, Name = "Set event type to active/inactive", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 44, Name = "VIP Lounge creation", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 45, Name = "VIP Lounge - modification", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 46, Name = "VIP Lounge - releasing", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 47, Name = "VIP Lounge - set date as not available", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 48, Name = "Update document for event", LoggingActionModuleId = 3 },
                    new LoggingAction { Id = 49, Name = "Delete document for event", LoggingActionModuleId = 3 },
                    new LoggingAction { Id = 50, Name = "VIP Lounge - set to active/incative", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 51, Name = "Edit E-mail template", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 52, Name = "Event version update", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 53, Name = "Edit booking suggestion mapping", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 54, Name = "Edit workflow step permission", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 55, Name = "Delete workflow step permission", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 56, Name = "Add substitute", LoggingActionModuleId = 1 },
                    new LoggingAction { Id = 57, Name = "Deactivate substitute", LoggingActionModuleId = 1 },
                    new LoggingAction { Id = 58, Name = "Login as substitute", LoggingActionModuleId = 1 },
                    new LoggingAction { Id = 59, Name = "Wage type mappings modification", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 60, Name = "Mapping event types modification", LoggingActionModuleId = 5, },
                    new LoggingAction { Id = 61, Name = "Wage type taxation. Edit Transferred checkbox", LoggingActionModuleId = 6, },
                    new LoggingAction { Id = 62, Name = "Social security. Edit Transferred checkbox", LoggingActionModuleId = 6 },
                    new LoggingAction { Id = 63, Name = "Cost was marked as Clearing Cost", LoggingActionModuleId = 7 },
                    new LoggingAction { Id = 64, Name = "Costs were allocated to event", LoggingActionModuleId = 7 },
                    new LoggingAction { Id = 65, Name = "Costs were allocated to cost category", LoggingActionModuleId = 7 },
                    new LoggingAction { Id = 66, Name = "Allocation to event was reset", LoggingActionModuleId = 7 },
                    new LoggingAction { Id = 67, Name = "Allocation to cost category was reset", LoggingActionModuleId = 7 },
                    new LoggingAction { Id = 68, Name = "Allocation was commited", LoggingActionModuleId = 7 },
                    new LoggingAction { Id = 69, Name = "Cost was marked as irrelevant", LoggingActionModuleId = 7 },
                    new LoggingAction { Id = 71, Name = "Import teams", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 72, Name = "Import order numbers", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 77, Name = "Create order number", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 78, Name = "Update order number", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 79, Name = "Create competitor", LoggingActionModuleId = 8 },
                    new LoggingAction { Id = 80, Name = "Update competitor", LoggingActionModuleId = 8 },
                    new LoggingAction { Id = 81, Name = "Delete competitor", LoggingActionModuleId = 8 },
                    new LoggingAction { Id = 82, Name = "Create season", LoggingActionModuleId = 8 },
                    new LoggingAction { Id = 83, Name = "Update season", LoggingActionModuleId = 8 },
                    new LoggingAction { Id = 84, Name = "Delete season", LoggingActionModuleId = 8 },
                    new LoggingAction { Id = 85, Name = "Import dates", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 86, Name = "Create team", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 87, Name = "Update team", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 88, Name = "Create Sport to department connection", LoggingActionModuleId = 9 },
                    new LoggingAction { Id = 89, Name = "Update Sport to department connection", LoggingActionModuleId = 9 },
                    new LoggingAction { Id = 90, Name = "Create Sport", LoggingActionModuleId = 9 },
                    new LoggingAction { Id = 91, Name = "Update Sport", LoggingActionModuleId = 9 },
                    new LoggingAction { Id = 95, Name = "Vip Lounge Basic Fields Updated", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 96, Name = "Update VipLounge Place", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 97, Name = "VipLounge Copied", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 98, Name = "Event Cancelled", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 99, Name = "Event Reserved Places Notification Email Sent", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 100, Name = "Create VipLounge Place", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 101, Name = "Assign attendee update", LoggingActionModuleId = 3 },
                    new LoggingAction { Id = 104, Name = "New attendee", LoggingActionModuleId = 3 },
                    new LoggingAction { Id = 105, Name = "Add permission to role", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 106, Name = "Remove permission from role", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 107, Name = "Update permission to role assignment", LoggingActionModuleId = 5 },
                    new LoggingAction { Id = 108, Name = "Limit 10K euro. Edit Processed checkbox", LoggingActionModuleId = 6 },
                    new LoggingAction { Id = 109, Name = "Limit 35 euro. Edit Processed checkbox", LoggingActionModuleId = 6 }
                    );

                context.AddOrUpdateSeed(null,
                    new PermissionType { Id = 1, Name = "Module" },
                    new PermissionType { Id = 2, Name = "Feature" },
                    new PermissionType { Id = 3, Name = "Workflow step execution" },
                    new PermissionType { Id = 4, Name = "Rest service access" });

                // Previous before next

                context.AddOrUpdateSeed(null,
                    new Permission { Id = 1, PermissionTypeId = 1, Description = "Event creation" },
                    new Permission { Id = 2, PermissionTypeId = 1, Description = "Event status cockpit" },
                    //
                    new Permission { Id = 4, PermissionTypeId = 1, Description = "Attendees" },
                    //
                    new Permission { Id = 6, PermissionTypeId = 1, Description = "User administration" },
                    new Permission { Id = 7, PermissionTypeId = 1, Description = "Master data" },
                    new Permission { Id = 8, PermissionTypeId = 1, Description = "Workflow administration" },
                    new Permission { Id = 9, PermissionTypeId = 1, Description = "Customization" },
                    new Permission { Id = 10, PermissionTypeId = 1, Description = "Event types" },
                    new Permission { Id = 11, PermissionTypeId = 1, Description = "VIP Lounge" },
                    new Permission { Id = 12, PermissionTypeId = 1, Description = "Logs" },
                    new Permission { Id = 13, PermissionTypeId = 1, Description = "Email editor" },
                    new Permission { Id = 14, PermissionTypeId = 1, Description = "Mapping event types" },
                    new Permission { Id = 15, PermissionTypeId = 1, Description = "Translations" },
                    new Permission { Id = 16, PermissionTypeId = 2, Description = "Costs import" },
                    new Permission { Id = 17, PermissionTypeId = 1, Description = "Cost allocation page" },
                    //
                    new Permission { Id = 19, PermissionTypeId = 1, Description = "License administration" },
                    new Permission { Id = 20, PermissionTypeId = 2, Description = "Copy event" },
                    new Permission { Id = 21, PermissionTypeId = 2, Description = "Edit VIP Lounge" },
                    new Permission { Id = 22, PermissionTypeId = 2, Description = "Release VIP Lounge" },
                    new Permission { Id = 23, PermissionTypeId = 2, Description = "Deactivate VIP Lounge" },
                    //
                    new Permission { Id = 30, PermissionTypeId = 2, Description = "Read planned costs" },
                    new Permission { Id = 31, PermissionTypeId = 2, Description = "Edit planned costs" },
                    new Permission { Id = 32, PermissionTypeId = 2, Description = "Read actual costs" },
                    new Permission { Id = 33, PermissionTypeId = 2, Description = "Edit actual costs" },
                    new Permission { Id = 34, PermissionTypeId = 2, Description = "Read costs documents" },
                    new Permission { Id = 35, PermissionTypeId = 2, Description = "Upload costs documents" },
                    new Permission { Id = 36, PermissionTypeId = 2, Description = "Edit costs documents" },
                    new Permission { Id = 37, PermissionTypeId = 2, Description = "Read basic data" },
                    new Permission { Id = 38, PermissionTypeId = 2, Description = "Edit basic data" },
                    new Permission { Id = 39, PermissionTypeId = 2, Description = "Read planned agenda" },
                    new Permission { Id = 40, PermissionTypeId = 2, Description = "Edit planned agenda" },
                    new Permission { Id = 41, PermissionTypeId = 2, Description = "Read booking suggestions" },
                    //
                    new Permission { Id = 43, PermissionTypeId = 2, Description = "Read actual agenda" },
                    new Permission { Id = 44, PermissionTypeId = 2, Description = "Edit actual agenda" },
                    new Permission { Id = 45, PermissionTypeId = 2, Description = "Cancel and copy event" },
                    new Permission { Id = 46, PermissionTypeId = 2, Description = "Edit costs flexible fields" },
                    new Permission { Id = 47, PermissionTypeId = 2, Description = "Change attendee attribute from technical to manual" },
                    new Permission { Id = 48, PermissionTypeId = 2, Description = "See personal number" },
                    new Permission { Id = 49, PermissionTypeId = 2, Description = "Update event version" },
                    new Permission { Id = 50, PermissionTypeId = 4, Description = "Rest service access" },
                    new Permission { Id = 51, PermissionTypeId = 2, Description = "Edit Internal attendees" },
                    new Permission { Id = 52, PermissionTypeId = 2, Description = "Edit External attendees" },
                    new Permission { Id = 53, PermissionTypeId = 2, Description = "Batch go to next step" },
                    new Permission { Id = 54, PermissionTypeId = 2, Description = "Select workflow step after reject" },
                    new Permission { Id = 55, PermissionTypeId = 2, Description = "Read planned attendees" },
                    new Permission { Id = 56, PermissionTypeId = 2, Description = "Read actual attendees" },
                    new Permission { Id = 57, PermissionTypeId = 2, Description = "Edit planned attendees" },
                    new Permission { Id = 58, PermissionTypeId = 2, Description = "Edit actual attendees" },
                    new Permission { Id = 59, PermissionTypeId = 1, Description = "Wage type taxation" },
                    new Permission { Id = 60, PermissionTypeId = 2, Description = "Wage type taxation. Edit Transferred checkbox" },
                    new Permission { Id = 61, PermissionTypeId = 1, Description = "Corporate event" },
                    new Permission { Id = 62, PermissionTypeId = 1, Description = "Social security" },
                    new Permission { Id = 64, PermissionTypeId = 1, Description = "Stock of Gifts" },
                    new Permission { Id = 65, PermissionTypeId = 2, Description = "Manage event gifts" },
                    new Permission { Id = 66, PermissionTypeId = 2, Description = "Social security. Edit Transferred checkbox" },
                    new Permission { Id = 68, PermissionTypeId = 2, Description = "Update event version of closed events" },
                    new Permission { Id = 71, PermissionTypeId = 1, Description = "Costs on-charge" },
                    new Permission { Id = 72, PermissionTypeId = 1, Description = "Booking suggestions report" },
                    new Permission { Id = 73, PermissionTypeId = 1, Description = "Tickets Cockpit" },
                    new Permission { Id = 76, PermissionTypeId = 1, Description = "Event Dates Cockpit" },
                    new Permission { Id = 77, PermissionTypeId = 1, Description = "Limit 10K euro" },
                    new Permission { Id = 78, PermissionTypeId = 2, Description = "Limit 10K euro. Edit Processed checkbox" },
                    new Permission { Id = 79, PermissionTypeId = 1, Description = "Limit 35 euro" },
                    new Permission { Id = 80, PermissionTypeId = 2, Description = "Limit 35 euro. Edit Processed checkbox" });

                context.AddOrUpdateSeed(null,
                    new Role { Id = 1, Name = "RestAccess" },
                    new Role { Id = 2, Name = "Administrators" });

                // Previous before next

                context.AddOrUpdateSeed((existing, @new) => existing.PermissionId == @new.PermissionId && existing.RoleId == @new.RoleId,
                    new PermissionRole { PermissionId = 50, RoleId = 1 },

                    new PermissionRole { PermissionId = 1, RoleId = 2 },
                    new PermissionRole { PermissionId = 2, RoleId = 2 },
                    //
                    new PermissionRole { PermissionId = 4, RoleId = 2 },
                    //
                    new PermissionRole { PermissionId = 6, RoleId = 2 },
                    new PermissionRole { PermissionId = 7, RoleId = 2 },
                    new PermissionRole { PermissionId = 8, RoleId = 2 },
                    new PermissionRole { PermissionId = 9, RoleId = 2 },
                    new PermissionRole { PermissionId = 10, RoleId = 2 },
                    new PermissionRole { PermissionId = 11, RoleId = 2 },
                    new PermissionRole { PermissionId = 12, RoleId = 2 },
                    new PermissionRole { PermissionId = 13, RoleId = 2 },
                    //new PermissionRole { PermissionId = 14, RoleId = 2 },
                    new PermissionRole { PermissionId = 15, RoleId = 2 },
                    new PermissionRole { PermissionId = 16, RoleId = 2 },
                    new PermissionRole { PermissionId = 17, RoleId = 2 },
                    new PermissionRole { PermissionId = 19, RoleId = 2 },
                    //
                    new PermissionRole { PermissionId = 20, RoleId = 2 },
                    new PermissionRole { PermissionId = 21, RoleId = 2 },
                    new PermissionRole { PermissionId = 22, RoleId = 2 },
                    new PermissionRole { PermissionId = 23, RoleId = 2 },
                    //
                    new PermissionRole { PermissionId = 30, RoleId = 2 },
                    new PermissionRole { PermissionId = 31, RoleId = 2 },
                    new PermissionRole { PermissionId = 32, RoleId = 2 },
                    new PermissionRole { PermissionId = 33, RoleId = 2 },
                    new PermissionRole { PermissionId = 34, RoleId = 2 },
                    new PermissionRole { PermissionId = 35, RoleId = 2 },
                    new PermissionRole { PermissionId = 36, RoleId = 2 },
                    new PermissionRole { PermissionId = 37, RoleId = 2 },
                    new PermissionRole { PermissionId = 38, RoleId = 2 },
                    new PermissionRole { PermissionId = 39, RoleId = 2 },
                    new PermissionRole { PermissionId = 40, RoleId = 2 },
                    new PermissionRole { PermissionId = 41, RoleId = 2 },
                    //
                    new PermissionRole { PermissionId = 43, RoleId = 2 },
                    new PermissionRole { PermissionId = 44, RoleId = 2 },
                    new PermissionRole { PermissionId = 45, RoleId = 2 },
                    new PermissionRole { PermissionId = 46, RoleId = 2 },
                    new PermissionRole { PermissionId = 47, RoleId = 2 },
                    new PermissionRole { PermissionId = 48, RoleId = 2 },
                    new PermissionRole { PermissionId = 49, RoleId = 2 },
                    new PermissionRole { PermissionId = 50, RoleId = 2 },
                    new PermissionRole { PermissionId = 51, RoleId = 2 },
                    new PermissionRole { PermissionId = 52, RoleId = 2 },
                    new PermissionRole { PermissionId = 53, RoleId = 2 },
                    new PermissionRole { PermissionId = 54, RoleId = 2 },
                    new PermissionRole { PermissionId = 55, RoleId = 2 },
                    new PermissionRole { PermissionId = 56, RoleId = 2 },
                    new PermissionRole { PermissionId = 57, RoleId = 2 },
                    new PermissionRole { PermissionId = 58, RoleId = 2 },
                    new PermissionRole { PermissionId = 59, RoleId = 2 },
                    new PermissionRole { PermissionId = 60, RoleId = 2 },
                    new PermissionRole { PermissionId = 61, RoleId = 2 },
                    new PermissionRole { PermissionId = 62, RoleId = 2 },
                    new PermissionRole { PermissionId = 64, RoleId = 2 },
                    new PermissionRole { PermissionId = 65, RoleId = 2 },
                    new PermissionRole { PermissionId = 66, RoleId = 2 },
                    new PermissionRole { PermissionId = 68, RoleId = 2 },
                    new PermissionRole { PermissionId = 71, RoleId = 2 },
                    new PermissionRole { PermissionId = 72, RoleId = 2 },
                    new PermissionRole { PermissionId = 73, RoleId = 2 },
                    new PermissionRole { PermissionId = 76, RoleId = 2 },
                    new PermissionRole { PermissionId = 77, RoleId = 2 },
                    new PermissionRole { PermissionId = 78, RoleId = 2 },
                    new PermissionRole { PermissionId = 79, RoleId = 2 },
                    new PermissionRole { PermissionId = 80, RoleId = 2 });

                context.AddOrUpdateSeed(null,
                    new SourceType { Id = 1, Name = "Manual" },
                    new SourceType { Id = 2, Name = "Csv" },
                    new SourceType { Id = 3, Name = "RestApi" });

                // Previous before next

                context.AddOrUpdateSeed(null,
                    new StepSkipCondition { Id = 1, Name = "Company" },
                    new StepSkipCondition { Id = 2, Name = "Department" },
                    new StepSkipCondition { Id = 3, Name = "CostCenter" },
                    new StepSkipCondition { Id = 4, Name = "EventType" },
                    new StepSkipCondition { Id = 5, Name = "EventDuration" },
                    new StepSkipCondition { Id = 6, Name = "TotalParticipants" },
                    new StepSkipCondition { Id = 7, Name = "NotParticipated" },
                    new StepSkipCondition { Id = 8, Name = "Participated" },
                    new StepSkipCondition { Id = 9, Name = "TotalCostPlanned" },
                    new StepSkipCondition { Id = 10, Name = "TotalCostActual" },
                    new StepSkipCondition { Id = 11, Name = "BasicField" });

                context.AddOrUpdateSeed(null,
                    new Taxation { Id = 1, Name = "Deutschland" },
                    new Taxation { Id = 2, Name = "außerhalb Deutschland" });

                context.AddOrUpdateSeed(null,
                    new User
                    {
                        Id = 1,
                        Password = "AG8YFAuDP5RVRnZAYSJoNlSyLJ4DgUtAQ2RJYqR/y1Ivo/aZqKCadksGUsO1kZ1yRQ==",
                        Email = "em_admin@evolvice.de",
                        FirstName = "Admin",
                        LastName = "Admin"
                    },
                    new User
                    {
                        Id = 1000,
                        Password = "AAnZGvZ/4Sh1bTFReQiV5BfC2ZxSIfZLizWTI2PCDRsOVdD/KN1KCE3wuzTOc5hP3A==",
                        Email = "restuser@evolvice.de",
                        FirstName = "RestUser",
                        LastName = "RestUser"
                    });

                context.AddOrUpdateSeed(null,
                    new DataRole { Id = 1000, Name = "RestAccess" },
                    new DataRole { Id = 1001, Name = "Administrators" });

                // Previous before next

                context.AddOrUpdateSeed((r, e) => e.UserId == r.UserId && e.RoleId == r.RoleId,
                    new UserRole { UserId = 1, RoleId = 2, DataRoleIds = "1001" },
                    new UserRole { UserId = 1000, RoleId = 1, DataRoleIds = "1000" });

                context.AddOrUpdateSeed(null,
                    new WorkflowStepType { Id = 1, Name = "Initial" },
                    new WorkflowStepType { Id = 2, Name = "Approving" },
                    new WorkflowStepType { Id = 3, Name = "Accounting" },
                    new WorkflowStepType { Id = 4, Name = "Booking" });

                // Previous before next

                context.AddOrUpdateSeed(null,
                    new WorkflowStepTypeAction { Id = 1, Name = "Cancellation", Description = "Cancellation of event", WorkflowStepTypeId = 1 },
                    new WorkflowStepTypeAction { Id = 2, Name = "ForApproval", Description = "Event for approval", WorkflowStepTypeId = 1 },
                    new WorkflowStepTypeAction { Id = 3, Name = "Reject", Description = "Event reject", WorkflowStepTypeId = 2 },
                    new WorkflowStepTypeAction { Id = 4, Name = "Approve", Description = "Event approve", WorkflowStepTypeId = 2 },
                    new WorkflowStepTypeAction { Id = 5, Name = "AccountingReject", Description = "Event cancelled", WorkflowStepTypeId = 3 },
                    new WorkflowStepTypeAction { Id = 6, Name = "ForBooking", Description = "Event for booking", WorkflowStepTypeId = 3 },
                    new WorkflowStepTypeAction { Id = 7, Name = "BookingNotPossible", Description = "Event booking not possible", WorkflowStepTypeId = 4 },
                    new WorkflowStepTypeAction { Id = 8, Name = "Booked", Description = "Event booked", WorkflowStepTypeId = 4 });

                context.AddOrUpdateSeed(null,
                    new Tournament { Id = 1, Name = "Bundesliga" },
                    new Tournament { Id = 2, Name = "DFB-Pokal" },
                    new Tournament { Id = 3, Name = "Champions League" },
                    new Tournament { Id = 4, Name = "Euro League" },
                    new Tournament { Id = 5, Name = "Other" });
            }
        }
    }
}
