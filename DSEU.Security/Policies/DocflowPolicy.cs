namespace DSEU.Security.Policies
{
    public static class DocflowPolicy
    {
        public const string RegistrationGroupResponsible = "Политика для проверки ответственного за группу регистрации";

        public const string UpdateDocumentRegister = "Политика для обновление журнала регистрации";
        public const string RemoveDocumentRegister = "Политика на удаление журнала регистрации";
        public const string CanManageDocumentRegister = "Политика на управление журналом регистрации";

        public const string UpdateCaseFile = "Политика на обновление дела";
        public const string RemoveCaseFile = "Политика на удаление дела";

        public const string ReadRegistrationSettings = "Политика на чтение настроек журнала регистрации";
        public const string CreateRegistrationSettings = "Политика на создание настроек журнала регистрации";
        public const string UpdateRegistrationSettings = "Политика на обновление настроек журнала регистрации";

    }
}
