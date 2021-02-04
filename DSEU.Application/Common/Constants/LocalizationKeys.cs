namespace DSEU.Application.Common.Constants
{
    public static class LocalizationKeys
    {
        /// <summary>
        /// ������������ �������
        /// </summary>
        public static class PropertyNames
        {
            /// <summary>
            /// ������
            /// </summary>
            public const string Country = "Prop_Country";
            /// <summary>
            /// ������
            /// </summary>
            public const string Region = "Prop_Region";
            /// <summary>
            /// ������������
            /// </summary>
            public const string Name = "Prop_Name";
            /// <summary>
            /// �������� ���
            /// </summary>
            public const string NumericCode = "Prop_NumericCode";
            /// <summary>
            /// ��������� ���
            /// </summary>
            public const string AlphaCode = "Prop_AlphaCode";
            /// <summary>
            /// ����������� ������������
            /// </summary>
            public const string ShortName = "Prop_ShortName";
            /// <summary>
            /// ������� �����
            /// </summary>
            public const string FractionName = "Prop_FranctionName";
            /// <summary>
            /// ���� �������� (���)
            /// </summary>
            public const string RetentionPeriod = "Prop_RetentionPeriod";

        }


        /// <summary>
        /// ����� ����� �����������
        /// </summary>
        public static class SharedKeys
        {
            /// <summary>
            /// ������ ��������� ��������� ������. ��������� ������������ ����������
            /// </summary>
            public const string CascadeDependencyError = "SK_CascadeDependencyError";

            /// <summary>
            /// ������ ������ ���� ��������
            /// </summary>
            public const string StatusMustBeActive = "SK_StatusMustBeActive";
            /// <summary>
            /// ���������� ����������� �����������. ��������� ������������ ���������� ������.
            /// </summary>
            public const string CircularNesting = "SK_CircularNesting";
            /// <summary>
            /// �������� ��� ����������
            /// </summary>
            public const string ValueAlreadyExists = "SK_ValueAlreadyExists";
            /// <summary>
            /// ��������� ������������ ������.
            /// </summary>
            public const string EntityWithKeyDoesNotExists = "SK_EntityWithKeyDoesNotExists";
            /// <summary>
            /// ������ ������� ������, ��� ��� ��� ��� ������������.
            /// </summary>
            public const string HasOneOreMoreDependencies = "SK_HasOneOreMoreDependencies";

        }

        /// <summary>
        /// ��������� ������������� (DOCVER)
        /// </summary>
        public static class ElectronicDocumentVersionKeys
        {
            /// <summary>
            /// ����� ��� ���������� ���������
            /// </summary>
            public const string FilesWithoutExtensionDenied = "DOCVER_FilesWithoutExtensionDenied";
            /// <summary>
            /// ������������ ���������� �����
            /// </summary>
            public const string InvalidFileExtension = "DOCVER_InvalidFileExtension";
            /// <summary>
            /// ��������� �������� ����� ��������� ����� ������
            /// </summary>
            public const string SaveDocumentBefoureUploadNewVersion = "DOCVER_SaveDocumentBefoureUploadNewVersion";
            /// <summary>
            /// ��������� ���������� ��� �������� �����. ���� �������� �����.
            /// </summary>
            public const string VirusDetected = "DOCVER_VirusDetected";
        }

        /// <summary>
        /// ��������� ������������� (MASS)
        /// </summary>
        public static class ManagersAssistantsKeys
        {
            /// <summary>
            /// ������������ � �������� �� ����� ���� ����� ���������
            /// </summary>
            public const string ManagerAndAssistantCantBeSamePerson = "MASS_ManagerAndAssistantCantBeSamePerson";
            /// <summary>
            /// �� ������ ���� ����� ������ ��������� ��������� ���������
            /// </summary>
            public const string ActiveManagerAssistantCantBeMoreThanOne = "MASS_ActiveManagerAssistantCantBeMoreThanOne";
        }

        /// <summary>
        /// ������ ����������� (RS)
        /// </summary>
        public static class RegistrationSettings
        {
            /// <summary>
            /// ���������� ����������� ������.
            /// </summary>
            public const string DuplicatesDetected = "RS_DuplicatesDetected";
        }

        /// <summary>
        /// ����� ����������� ��� ��� ���������� (CF)
        /// </summary>
        public static class CaseFileKeys
        {
            /// <summary>
            /// ������ ���� ������ ���� ���������� � ������ ����� �����������
            /// </summary>
            public const string IndexAlreadyExistsInDepartment = "CF_IndexAlreadyExistsInDepartment";
        }

        /// <summary>
        /// ����� ����������� ��� ����� ����������� (BU)
        /// </summary>
        public static class BusinessUnitKeys
        {
            /// <summary>
            /// ������������ ����������� ��� ��������.
            /// </summary>
            public const string CeoAlreadyAssigned = "BU_CeoAlreadyAssigned";
            /// <summary>
            /// ����� ��� ��� ����������.
            /// </summary>
            public const string TaxNumberAlreadyExists = "BU_TaxNumberAlreadyExists";
            /// <summary>
            /// ��� ����������� ��� ����������.
            /// </summary>
            public const string BusinessUnitCodeAlreadyExists = "BU_BusinessUnitCodeAlreadyExists";
        }

        /// <summary>
        /// ����� ����������� ��� ����� �������� ����������� (DRLK)
        /// </summary>
        public static class DocumentRegistrationLogKeys
        {
            /// <summary>
            /// ����� ����� ��� �������� ���������.
            /// </summary>
            public const string NumberAlreadyAssignedToDocument = "DRLK_NumberAlreadyAssignedToDocument";
        }

        /// <summary>
        /// ����� ����������� ��� �������� ����������� (DRK)
        /// </summary>
        public static class DocumentRegistryKeys
        {
            /// <summary>
            /// � ������������ ������ ����������� ������ �������������� ���������� �����
            /// </summary>
            public const string ElementNumberRequired = "DRK_ElementNumberRequired";
            /// <summary>
            /// �� ����������� ������������� �������� � ������.
            /// </summary>
            public const string SpacesAreNotAllowedInTheNumber = "DRK_SpacesAreNotAllowedInTheNumber";
            /// <summary>
            /// ������ ���������� ��������������� ����� � ������� �����������.
            /// </summary>
            public const string DocumentRegisterLockedPropertiesMustNotModified = "DRK_DocumentRegisterLockedPropertiesMustNotModified";
            /// <summary>
            /// ������ � ������ ��������� ������� �� ���������, ��� ��� � ���� ������� ���������������� ���������.
            /// </summary>
            public const string NumberingSectionWithPeriodLockedFromChanges = "DRK_NumberingSectionWithPeriodLockedFromChanges";
            /// <summary>
            /// ����������� ���������� � ��������� ��������������� ���������� ��� ��������� ������ �����������
            /// </summary>
            public const string UnavailableDocumentFlowForRegistrationGroup = "DRK_UnavailableDocumentFlowForRegistrationGroup";
        }

        /// <summary>
        /// ����� ����������� ��� ������� � ����������� ���������� (DRRK)
        /// </summary>
        public static class DocumentRegisterReportKeys
        {
            /// <summary>
            /// ���������� ����� ������ � ����������� .docx 
            /// </summary>
            public const string ValidOnlyDocxFiles = "DRRK_ValidOnlyDocxFiles";
            /// <summary>
            /// ������������� ��������� �� ������ ���� ������
            /// </summary>
            public const string DocumentIdMustNotBeEmpty = "DRRK_DocumentIdMustNotBeEmpty";
        }

        /// <summary>
        /// ����� ����������� ��� ������������� (DEP)
        /// </summary>
        public static class DepartmentKeys
        {
            /// <summary>
            /// ������������ ��� �������� � ������� �������������
            /// </summary>
            public const string ManagerAlreadyAssigned = "DEP_ManagerAlreadyAssigned";
            /// <summary>
            /// ����� ��� ������������� ��� ���������� � ������ �����������
            /// </summary>
            public const string DepartmentCodeAlreadyExists = "DEP_DepartmentCodeAlreadyExists";
            /// <summary>
            /// ��������� ��� �������� � �����������
            /// </summary>
            public const string EmployeeAlreadyAssigned = "DEP_EmployeeAlreadyAssigned";
            /// <summary>
            /// ���������� ������� ������������ �������������
            /// </summary>
            public const string DepartmentMemberRemoveDenied = "DEP_DepartmentMemberRemoveDenied";
        }


        /// <summary>
        /// ����� ����������� ��� ���������� (DOC)
        /// </summary>
        public static class DocumentKeys
        {
            /// <summary>
            /// �������� ������ ���� ���������������
            /// </summary>
            public const string DocumentMustBeRegistered = "DOC_DocumentMustBeRegistered";
            /// <summary>
            /// �������� � ������� ��������������� ������� ��� ���������������
            /// </summary>
            public const string RegistrationNumberAlreadyExists = "DOC_RegistrationNumberAlreadyExists";
            /// <summary>
            /// �������� ��� ���������������
            /// </summary>
            public const string DocumentAlreadyRegistered = "DOC_DocumentAlreadyRegistered";
            /// <summary>
            /// ��� ��������� ������ ���� "���������"
            /// </summary>
            public const string DocumentMustBeOutgoing = "DOC_DocumentMustBeOutgoing";
            /// <summary>
            /// ��� ��������� ������ ���� "��������"
            /// </summary>
            public const string DocumentMustBeIncoming = "DOC_DocumentMustBeIncoming";
            /// <summary>
            /// ���������� ������� ��������. 
            /// </summary>
            public const string DocumentDeletionError = "DOC_DocumentDeletionError";
        }


        /// <summary>
        /// ����� ����������� ��� ����� ���������� (DK)
        /// </summary>
        public static class DocumentKindKeys
        {
            /// <summary>
            /// ������� ������ ��������������
            /// </summary>
            public const string IncorrectDocumentFlow = "DK_IncorrectDocumentFlow";

            /// <summary>
            /// ������� ������ ��� ���������
            /// </summary>
            public const string IncorrectDocumentType = "DK_IncorrectDocumentType";
            /// <summary>
            /// ���������� �������� ��������, �.�. ��� ���� ���������� �����������.
            /// </summary>
            public const string DocumentKindHasDependencies = "DK_DocumentKindHasDependencies";
        }


        /// <summary>
        /// ����� ����������� ��� ����������� (EMP)
        /// </summary>
        public static class EmployeeKeys
        {
            /// <summary>
            /// ������ �� ���������
            /// </summary>
            public const string PasswordsDontMatch = "EMP_PasswordsDontMatch";
            /// <summary>
            /// Email ������ ���� ����������
            /// </summary>
            public const string EmailMustBeUniq = "EMP_EmailMustBeUniq";
            /// <summary>
            /// ������� ������ � ����� ������ ��� ����������
            /// </summary>
            public const string UserNameAlreadyExists = "EMP_UserNameAlreadyExists";
        }


        /// <summary>
        /// ����� ����������� ��� ���������� ������������
        /// </summary>
        public static class AssociatedApplicationKeys
        {
            /// <summary>
            /// �������� ���������� �����
            /// </summary>
            public const string InvalidFileExtension = "ASAP_InvalidFileExtension";

        }


        /// <summary>
        /// ����� ����������� ��� �����
        /// </summary>
        public static class RoleKeys
        {
            /// <summary>
            /// ���������� �������� ��������� ����
            /// </summary>
            public const string CantUpdateSystemRole = "ROLE_CantUpdateSystemRole";
            /// <summary>
            /// ������ ���������� ��� ���� ������������
            /// </summary>
            public const string RoleMembersIsImmutable = "ROLE_RoleMembersIsImmutable";
            /// <summary>
            /// �������� ��� �������� ��� ����
            /// </summary>
            public const string RoleMemberAlreadyAssigned = "ROLE_RoleMemberAlreadyAssigned";
        }

        /// <summary>
        /// ����� ����������� ��� �����
        /// </summary>
        public static class TaskKeys
        {
            /// <summary>
            /// ������ ������ ���� � ������� "��������"
            /// </summary>
            public const string TaskMustBeDraft = "TK_TaskMustBeDraft";
            /// <summary>
            /// ������ ������ ���� � ��������
            /// </summary>
            public const string TaskMustBeInProcess = "TK_TaskMustBeInProcess";
            /// <summary>
            /// ���������� ��������� ������ �� ������� ���������
            /// </summary>
            public const string CantStartTaskFromThisState = "TK_CantStartTaskFromThisState";
            /// <summary>
            /// ��� �������� ��������� �� ����������� ������������ ���������� ������� ������ ���������.
            /// </summary>
            public const string ElectronicAcquaintanceNeedVersion = "TK_ElectronicAcquaintanceNeedVersion";
            /// <summary>
            /// ���� ������ ���� ������ ��� ����� ������� ����
            /// </summary>
            public const string DeadlineMustBeGreaterOrEqualThanNow = "TK_DeadlineMustBeGreaterOrEqualThanNow";
            /// <summary>
            /// �� ������� �������� ����� ������� ��� ������ ��� ���������� ��������.
            /// </summary>
            public const string CantChangeAccessRightsOnAttachments = "TK_CantChangeAccessRightsOnAttachments";
            /// <summary>
            /// ��������� ����� � ��������� ��� � ��������� �����.
            /// </summary>
            public const string ActionItemCompoundBodyRequired = "TK_ActionItemCompoundBodyRequired";
        }
        
        /// <summary>
        /// ����� ����������� ��� �������
        /// </summary>
        public static class AssignmentKeys
        {
            /// <summary>
            /// ������� ����������� � ������ �����������
            /// </summary>
            public const string ActionItemSupervisorAssignmentReportRequired = "ASIGN_ActionItemSupervisorAssignmentReportRequired";
            /// <summary>
            /// ������� ����������� ��� ��������� ������� ���������
            /// </summary>
            public const string ReviewDraftResolutionAssignmentBodyRequired = "ASIGN_ReviewDraftResolutionAssignmentBodyRequired";
            /// <summary>
            /// ������� ���������� �������� ���������� �������������� �������
            /// </summary>
            public const string ForwardRequired = "ASIGN_ForwardRequired";
            /// <summary>
            /// ���������� �������������� ������� �� ���������� ������� ���������,�.�. ������� ��������� �� ���������
            /// </summary>
            public const string CantForwardReworkedPreparingDraftResoulutionAssignment = "ASIGN_CantForwardReworkedPreparingDraftResoulutionAssignment";
            /// <summary>
            /// ����� ���� ������ ���� ������, ���� ����� ����� ������
            /// </summary>
            public const string NewDeallineMustBeGreaterOrEqualThanTaskDeadline = "ASIGN_NewDeallineMustBeGreaterOrEqualThanTaskDeadline";
            /// <summary>
            /// ������� ������ ���� � ��������
            /// </summary>
            public const string AssignmentMustBeInProcess = "ASIGN_AssignmentMustBeInProcess";
            /// <summary>
            /// ������� �����������
            /// </summary>
            public const string CommentRequired = "ASIGN_CommentRequired";
        }

    }
}
