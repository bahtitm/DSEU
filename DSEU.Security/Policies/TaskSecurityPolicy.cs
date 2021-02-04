namespace DSEU.Security.Policies
{
    public static class TaskSecurityPolicy
    {
        public const string Read = "Доступ к просмотру задачи";
        public const string Update = "Доступ к обновлению задачи";
    }

    public static class WorkflowAttachmentPolicies
    {
        public const string Detach = "Открепление вложений";
        public const string Attach = "Прикрепление вложений";
    }
}
