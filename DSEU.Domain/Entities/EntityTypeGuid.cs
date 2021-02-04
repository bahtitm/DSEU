namespace DSEU.Domain.Entities
{
    /// <summary>
    /// Тип сущности
    /// </summary>
    public enum EntityTypeGuid
    {
        /// <summary>
        /// Страна
        /// </summary>
        Country = 0,
        /// <summary>
        /// Регион
        /// </summary>
        Region,
        /// <summary>
        /// Населеный пункт
        /// </summary>
        Locality,
        /// <summary>
        /// Валюта
        /// </summary>
        Currency,
        /// <summary>
        /// Наша организация
        /// </summary>
        BusinessUnit = 100,
        /// <summary>
        /// Подразделения
        /// </summary>
        Department,
        /// <summary>
        /// Сотрудники
        /// </summary>
        Employee,
        /// <summary>
        /// Должности
        /// </summary>
        JobTitle,
        /// <summary>
        /// Помощники руководителей
        /// </summary>
        ManagersAssistant,
        /// <summary>
        /// Контрагенты
        /// </summary>
        Counterparty = 200,
        /// <summary>
        /// Контакты
        /// </summary>
        Contact,
        /// <summary>
        /// Приложения обработчики
        /// </summary>
        AssociatedApplication = 300,
        /// <summary>
        /// Типы файлов
        /// </summary>
        FilesType,
        /// <summary>
        /// Вид документа
        /// </summary>
        DocumentKind,
        /// <summary>
        /// Дело
        /// </summary>
        CaseFile,
        /// <summary>
        /// Срок хранения дела
        /// </summary>
        FileRetentionPeriod,
        /// <summary>
        /// Журнал регистрации
        /// </summary>
        DocumentRegister,
        /// <summary>
        /// Способы доставки документов
        /// </summary>
        DeliveryMethod,
        /// <summary>
        /// Группы регистрации
        /// </summary>
        RegistrationGroup,
        /// <summary>
        /// Настройки регистрации
        /// </summary>
        RegistrationSetting,
        /// <summary>
        /// Персональные настройки
        /// </summary>
        PersonalSettings,
        /// <summary>
        /// Группа документов
        /// </summary>
        DocumentGroupBase,
        /// <summary>
        /// Правило назначения прав
        /// </summary>
        AccessRightsRule,
        /// <summary>
        /// Цифоровой сертификат
        /// </summary>
        Certificate,
        /// <summary>
        /// Тип связи
        /// </summary>
        RelationType,
        /// <summary>
        /// Настройки прав подписи
        /// </summary>
        SignatureSetting,
        /// <summary>
        /// Электронный документ
        /// </summary>
        ElectronicDocument = 400,
        /// <summary>
        /// Оффициальный документ
        /// </summary>
        OfficialDocument,
        /// <summary>
        /// Входящий документ
        /// </summary>
        IncomingDocumentBase,
        /// <summary>
        /// Исходящий документ
        /// </summary>
        OutgoingDocumentBase,
        /// <summary>
        /// Внутренний документ
        /// </summary>
        InternalDocumentBase,
        /// <summary>
        /// Базовый приказ
        /// </summary>
        BaseOrder,
        /// <summary>
        /// Входящее письмо
        /// </summary>
        IncomingLetter,
        /// <summary>
        /// Исходящее письмо
        /// </summary>
        OutgoingLetter,
        /// <summary>
        /// Доверенность
        /// </summary>
        PowerOfAttorney,
        /// <summary>
        /// Приложение к документу
        /// </summary>
        Addendum,
        /// <summary>
        /// Простой документ
        /// </summary>
        SimpleDocument,
        /// <summary>
        /// Приказ
        /// </summary>
        Order,
        /// <summary>
        /// Распоряжение
        /// </summary>
        CompanyDirective,
        /// <summary>
        /// Служебная записка
        /// </summary>
        Memo,
        /// <summary>
        /// Финансовый документ
        /// </summary>
        AccountingDocumentBase,
        /// <summary>
        /// Входящий счет
        /// </summary>
        IncomingInvoice,
        /// <summary>
        /// Акт выполненных работ
        /// </summary>
        ContractStatement,
        /// <summary>
        /// Счет-фактура полученный
        /// </summary>
        IncomingTaxInvoice,
        /// <summary>
        /// Счет-фактура выставленный
        /// </summary>
        OutgoingTaxInvoice,
        /// <summary>
        /// Универсальный передаточный документ
        /// </summary>
        UniversalTransferDocument,
        /// <summary>
        /// Накладная
        /// </summary>
        Waybill,
        /// <summary>
        /// Базовый договорной документ
        /// </summary>
        ContractualDocumentBase,
        /// <summary>
        /// Базовый договор
        /// </summary>
        ContractBase,
        /// <summary>
        /// Договор
        /// </summary>
        Contract,
        /// <summary>
        /// Дополнительное соглашение
        /// </summary>
        SupAgreement,
        /// <summary>
        /// Шаблон электронного документа
        /// </summary>
        ElectronicDocumentTemplate = 450,
        /// <summary>
        /// Роль
        /// </summary>
        Role = 500,
        /// <summary>
        /// Задача
        /// </summary>
        Task = 600,
        /// <summary>
        /// Простая задача
        /// </summary>
        SimpleTask,
        /// <summary>
        /// Задача на исполнение поручения
        /// </summary>
        ActionItemExecutionTask,
        /// <summary>
        /// Ознакомление с документом
        /// </summary>
        AcquaintanceTask,
        /// <summary>
        /// Задача на рассмотрение руководителем
        /// </summary>
        DocumentReviewTask,
        /// <summary>
        /// задача на контроль возврата
        /// </summary>
        CheckReturnTask,
        /// <summary>
        /// Задача на согласование
        /// </summary>
        ApprovalTask,
        /// <summary>
        /// Задача на свободное согласовние
        /// </summary>
        FreeApprovalTask,
        /// <summary>
        /// Запрос отчета по поручению
        /// </summary>
        StatusReportRequestTask,
        /// <summary>
        /// Запрос на продление срока
        /// </summary>
        DeadlineExtensionTask
    }
}
