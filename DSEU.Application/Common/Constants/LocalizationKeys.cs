namespace DSEU.Application.Common.Constants
{
    public static class LocalizationKeys
    {
        /// <summary>
        /// Наименование свойств
        /// </summary>
        public static class PropertyNames
        {
            /// <summary>
            /// Страна
            /// </summary>
            public const string Country = "Prop_Country";
            /// <summary>
            /// Регион
            /// </summary>
            public const string Region = "Prop_Region";
            /// <summary>
            /// Наименование
            /// </summary>
            public const string Name = "Prop_Name";
            /// <summary>
            /// Цифровой код
            /// </summary>
            public const string NumericCode = "Prop_NumericCode";
            /// <summary>
            /// Буквенный код
            /// </summary>
            public const string AlphaCode = "Prop_AlphaCode";
            /// <summary>
            /// Сокращенное наименование
            /// </summary>
            public const string ShortName = "Prop_ShortName";
            /// <summary>
            /// Дробная часть
            /// </summary>
            public const string FractionName = "Prop_FranctionName";
            /// <summary>
            /// Срок хранения (лет)
            /// </summary>
            public const string RetentionPeriod = "Prop_RetentionPeriod";

        }


        /// <summary>
        /// Общие ключи локализации
        /// </summary>
        public static class SharedKeys
        {
            /// <summary>
            /// Ошибка обработки зависимых данных. Проверьте правильность заполнения
            /// </summary>
            public const string CascadeDependencyError = "SK_CascadeDependencyError";

            /// <summary>
            /// Статус должен быть активным
            /// </summary>
            public const string StatusMustBeActive = "SK_StatusMustBeActive";
            /// <summary>
            /// Обнаружена циркулярная вложенность. Проверьте правильность заполнения данных.
            /// </summary>
            public const string CircularNesting = "SK_CircularNesting";
            /// <summary>
            /// Значение уже существует
            /// </summary>
            public const string ValueAlreadyExists = "SK_ValueAlreadyExists";
            /// <summary>
            /// Проверьте правильность данных.
            /// </summary>
            public const string EntityWithKeyDoesNotExists = "SK_EntityWithKeyDoesNotExists";
            /// <summary>
            /// Нельзя удалять запись, так как она уже используется.
            /// </summary>
            public const string HasOneOreMoreDependencies = "SK_HasOneOreMoreDependencies";

        }

        /// <summary>
        /// Помощники руководителей (DOCVER)
        /// </summary>
        public static class ElectronicDocumentVersionKeys
        {
            /// <summary>
            /// Файлы без расширения запрещены
            /// </summary>
            public const string FilesWithoutExtensionDenied = "DOCVER_FilesWithoutExtensionDenied";
            /// <summary>
            /// Недопустимое расширение файла
            /// </summary>
            public const string InvalidFileExtension = "DOCVER_InvalidFileExtension";
            /// <summary>
            /// Сохраните документ перед созданием новой версии
            /// </summary>
            public const string SaveDocumentBefoureUploadNewVersion = "DOCVER_SaveDocumentBefoureUploadNewVersion";
            /// <summary>
            /// Запрещено скачивание или просмотр файла. Файл содержит вирус.
            /// </summary>
            public const string VirusDetected = "DOCVER_VirusDetected";
        }

        /// <summary>
        /// Помощники руководителей (MASS)
        /// </summary>
        public static class ManagersAssistantsKeys
        {
            /// <summary>
            /// Руководитель и помощник не могут быть одним человеком
            /// </summary>
            public const string ManagerAndAssistantCantBeSamePerson = "MASS_ManagerAndAssistantCantBeSamePerson";
            /// <summary>
            /// Не должно быть более одного активного помощника менеджера
            /// </summary>
            public const string ActiveManagerAssistantCantBeMoreThanOne = "MASS_ActiveManagerAssistantCantBeMoreThanOne";
        }

        /// <summary>
        /// Группы регистрации (RS)
        /// </summary>
        public static class RegistrationSettings
        {
            /// <summary>
            /// Обнаружены дублирующие записи.
            /// </summary>
            public const string DuplicatesDetected = "RS_DuplicatesDetected";
        }

        /// <summary>
        /// Ключи локализации для дел документов (CF)
        /// </summary>
        public static class CaseFileKeys
        {
            /// <summary>
            /// Индекс дела должен быть уникальным в рамках нашей организации
            /// </summary>
            public const string IndexAlreadyExistsInDepartment = "CF_IndexAlreadyExistsInDepartment";
        }

        /// <summary>
        /// Ключи локализации для наших организаций (BU)
        /// </summary>
        public static class BusinessUnitKeys
        {
            /// <summary>
            /// Руководитель организации уже назначен.
            /// </summary>
            public const string CeoAlreadyAssigned = "BU_CeoAlreadyAssigned";
            /// <summary>
            /// Такой ИНН уже существует.
            /// </summary>
            public const string TaxNumberAlreadyExists = "BU_TaxNumberAlreadyExists";
            /// <summary>
            /// Код организации уже существует.
            /// </summary>
            public const string BusinessUnitCodeAlreadyExists = "BU_BusinessUnitCodeAlreadyExists";
        }

        /// <summary>
        /// Ключи локализации для логов журналов регистрации (DRLK)
        /// </summary>
        public static class DocumentRegistrationLogKeys
        {
            /// <summary>
            /// Такой номер уже назначен документу.
            /// </summary>
            public const string NumberAlreadyAssignedToDocument = "DRLK_NumberAlreadyAssignedToDocument";
        }

        /// <summary>
        /// Ключи локализации для журналов регистрации (DRK)
        /// </summary>
        public static class DocumentRegistryKeys
        {
            /// <summary>
            /// В формировании номера обязательно должен присутствовать порядковый номер
            /// </summary>
            public const string ElementNumberRequired = "DRK_ElementNumberRequired";
            /// <summary>
            /// Не допускается использование пробелов в номере.
            /// </summary>
            public const string SpacesAreNotAllowedInTheNumber = "DRK_SpacesAreNotAllowedInTheNumber";
            /// <summary>
            /// Ошибка обновления заблокированных полей в журнале регистрации.
            /// </summary>
            public const string DocumentRegisterLockedPropertiesMustNotModified = "DRK_DocumentRegisterLockedPropertiesMustNotModified";
            /// <summary>
            /// Разрез и период нумерации закрыты от изменения, так как в этом журнале зарегистрированы документы.
            /// </summary>
            public const string NumberingSectionWithPeriodLockedFromChanges = "DRK_NumberingSectionWithPeriodLockedFromChanges";
            /// <summary>
            /// Регистрация документов в указанном документопотоке недоступна для указанной группы регистрации
            /// </summary>
            public const string UnavailableDocumentFlowForRegistrationGroup = "DRK_UnavailableDocumentFlowForRegistrationGroup";
        }

        /// <summary>
        /// Ключи локализации для отчетов о регистрации документов (DRRK)
        /// </summary>
        public static class DocumentRegisterReportKeys
        {
            /// <summary>
            /// Допустимые файлы только с расширением .docx 
            /// </summary>
            public const string ValidOnlyDocxFiles = "DRRK_ValidOnlyDocxFiles";
            /// <summary>
            /// Идентификатор документа не должен быть пустым
            /// </summary>
            public const string DocumentIdMustNotBeEmpty = "DRRK_DocumentIdMustNotBeEmpty";
        }

        /// <summary>
        /// Ключи локализации для Подразделений (DEP)
        /// </summary>
        public static class DepartmentKeys
        {
            /// <summary>
            /// Руководитель уже назначен у другого подразделения
            /// </summary>
            public const string ManagerAlreadyAssigned = "DEP_ManagerAlreadyAssigned";
            /// <summary>
            /// Такой код подразделения уже существует в данной организации
            /// </summary>
            public const string DepartmentCodeAlreadyExists = "DEP_DepartmentCodeAlreadyExists";
            /// <summary>
            /// Сотрудник уже работает в организации
            /// </summary>
            public const string EmployeeAlreadyAssigned = "DEP_EmployeeAlreadyAssigned";
            /// <summary>
            /// Невозможно удалить пользователя подразделения
            /// </summary>
            public const string DepartmentMemberRemoveDenied = "DEP_DepartmentMemberRemoveDenied";
        }


        /// <summary>
        /// Ключи локализации для документов (DOC)
        /// </summary>
        public static class DocumentKeys
        {
            /// <summary>
            /// Документ должен быть зарегистрирован
            /// </summary>
            public const string DocumentMustBeRegistered = "DOC_DocumentMustBeRegistered";
            /// <summary>
            /// Документ с данными регистрационным номером уже зарегистрирован
            /// </summary>
            public const string RegistrationNumberAlreadyExists = "DOC_RegistrationNumberAlreadyExists";
            /// <summary>
            /// Документ уже зарегистрирован
            /// </summary>
            public const string DocumentAlreadyRegistered = "DOC_DocumentAlreadyRegistered";
            /// <summary>
            /// Тип документа должен быть "Исходящий"
            /// </summary>
            public const string DocumentMustBeOutgoing = "DOC_DocumentMustBeOutgoing";
            /// <summary>
            /// Тип документа должен быть "Входящий"
            /// </summary>
            public const string DocumentMustBeIncoming = "DOC_DocumentMustBeIncoming";
            /// <summary>
            /// Невозможно удалить документ. 
            /// </summary>
            public const string DocumentDeletionError = "DOC_DocumentDeletionError";
        }


        /// <summary>
        /// Ключи локализации для видов документов (DK)
        /// </summary>
        public static class DocumentKindKeys
        {
            /// <summary>
            /// Неверно выбрат документопоток
            /// </summary>
            public const string IncorrectDocumentFlow = "DK_IncorrectDocumentFlow";

            /// <summary>
            /// Неверно выбран Тип документа
            /// </summary>
            public const string IncorrectDocumentType = "DK_IncorrectDocumentType";
            /// <summary>
            /// Невозможно изменить документ, т.к. для него существуют зависимости.
            /// </summary>
            public const string DocumentKindHasDependencies = "DK_DocumentKindHasDependencies";
        }


        /// <summary>
        /// Ключи локализации для Сотрудников (EMP)
        /// </summary>
        public static class EmployeeKeys
        {
            /// <summary>
            /// Пароли не совпадают
            /// </summary>
            public const string PasswordsDontMatch = "EMP_PasswordsDontMatch";
            /// <summary>
            /// Email должен быть уникальным
            /// </summary>
            public const string EmailMustBeUniq = "EMP_EmailMustBeUniq";
            /// <summary>
            /// Учетная запись с таким именем уже существует
            /// </summary>
            public const string UserNameAlreadyExists = "EMP_UserNameAlreadyExists";
        }


        /// <summary>
        /// Ключи локализации для приложений обработчиков
        /// </summary>
        public static class AssociatedApplicationKeys
        {
            /// <summary>
            /// Неверное расширение файла
            /// </summary>
            public const string InvalidFileExtension = "ASAP_InvalidFileExtension";

        }


        /// <summary>
        /// Ключи локализации для ролей
        /// </summary>
        public static class RoleKeys
        {
            /// <summary>
            /// Невозможно обновить системную роль
            /// </summary>
            public const string CantUpdateSystemRole = "ROLE_CantUpdateSystemRole";
            /// <summary>
            /// Состав участников для роли неизменяемый
            /// </summary>
            public const string RoleMembersIsImmutable = "ROLE_RoleMembersIsImmutable";
            /// <summary>
            /// Участник уже назначен для роли
            /// </summary>
            public const string RoleMemberAlreadyAssigned = "ROLE_RoleMemberAlreadyAssigned";
        }

        /// <summary>
        /// Ключи локализации для Задач
        /// </summary>
        public static class TaskKeys
        {
            /// <summary>
            /// Задача должна быть в статусе "Черновик"
            /// </summary>
            public const string TaskMustBeDraft = "TK_TaskMustBeDraft";
            /// <summary>
            /// Задача должна быть в процессе
            /// </summary>
            public const string TaskMustBeInProcess = "TK_TaskMustBeInProcess";
            /// <summary>
            /// Невозможно запустить задачу из данного состояния
            /// </summary>
            public const string CantStartTaskFromThisState = "TK_CantStartTaskFromThisState";
            /// <summary>
            /// Для отправки документа на электронное ознакомление необходимо создать версию документа.
            /// </summary>
            public const string ElectronicAcquaintanceNeedVersion = "TK_ElectronicAcquaintanceNeedVersion";
            /// <summary>
            /// Срок должен быть больше или равен текущей дате
            /// </summary>
            public const string DeadlineMustBeGreaterOrEqualThanNow = "TK_DeadlineMustBeGreaterOrEqualThanNow";
            /// <summary>
            /// Не удалось изменить права доступа для одного или нескольких вложений.
            /// </summary>
            public const string CantChangeAccessRightsOnAttachments = "TK_CantChangeAccessRightsOnAttachments";
            /// <summary>
            /// Заполните текст в поручении или в табличной части.
            /// </summary>
            public const string ActionItemCompoundBodyRequired = "TK_ActionItemCompoundBodyRequired";
        }
        
        /// <summary>
        /// Ключи локализации для Заданий
        /// </summary>
        public static class AssignmentKeys
        {
            /// <summary>
            /// Введите комментарий к отчету исполнителя
            /// </summary>
            public const string ActionItemSupervisorAssignmentReportRequired = "ASIGN_ActionItemSupervisorAssignmentReportRequired";
            /// <summary>
            /// Введите комментарий для доработки проекта резолюции
            /// </summary>
            public const string ReviewDraftResolutionAssignmentBodyRequired = "ASIGN_ReviewDraftResolutionAssignmentBodyRequired";
            /// <summary>
            /// Укажите сотрудника которому необходимо переадресовать задание
            /// </summary>
            public const string ForwardRequired = "ASIGN_ForwardRequired";
            /// <summary>
            /// Невозможно переадресовать задание на подготовку проекта резолюции,т.к. задание находится на доработке
            /// </summary>
            public const string CantForwardReworkedPreparingDraftResoulutionAssignment = "ASIGN_CantForwardReworkedPreparingDraftResoulutionAssignment";
            /// <summary>
            /// Новый срок должен быть больше, либо равен сроку задачи
            /// </summary>
            public const string NewDeallineMustBeGreaterOrEqualThanTaskDeadline = "ASIGN_NewDeallineMustBeGreaterOrEqualThanTaskDeadline";
            /// <summary>
            /// Задание должно быть в процессе
            /// </summary>
            public const string AssignmentMustBeInProcess = "ASIGN_AssignmentMustBeInProcess";
            /// <summary>
            /// Введите комментарий
            /// </summary>
            public const string CommentRequired = "ASIGN_CommentRequired";
        }

    }
}
