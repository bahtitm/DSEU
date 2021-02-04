using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using DSEU.Security.AccessRights.Handlers;
using DSEU.Security.Admin.Handlers;
using DSEU.Security.EntityType.Handlers;

//todo history link
//using DSEU.Security.Tasks.Handlers;
//using DSEU.Security.WorkflowAttachment.Handlers;
//using DSEU.Security.Assignments.Handlers;
//using DSEU.Security.Docflow.Handlers;
//using DSEU.Security.Documents.Handlers;

namespace DSEU.Security.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDSEUSecurity(this IServiceCollection services)
        {
            services.AddScoped<IAuthorizationHandler, AdminAuthorizationHandler>();
            services.AddScoped<IAuthorizationHandler, EntityTypeOperationRequirementHandler>();

            //services.AddScoped<IAuthorizationHandler, RegistrationGroupResponsibleAuthorizationHandler>();
            //services.AddScoped<IAuthorizationHandler, RemoveDocumentRegisterAuthorizationHandler>();
            //services.AddScoped<IAuthorizationHandler, UpdateDocumentRegisterAuthorizationHandler>();
            //services.AddScoped<IAuthorizationHandler, CanManageDocumentRegisterAuthorizationHandler>();
            //services.AddScoped<IAuthorizationHandler, UpdateCaseFileAuthorizationHandler>();
            //services.AddScoped<IAuthorizationHandler, RemoveCaseFileAuthorizationHandler>();
            //services.AddScoped<IAuthorizationHandler, CreateRegistrationSettingsAuthorizationHandler>();
            //services.AddScoped<IAuthorizationHandler, UpdateRegistrationSettingsAuthorizationHandler>();

            //services.AddScoped<IAuthorizationHandler, DocumentDeletionAuthorizationHandler>();
            //services.AddScoped<IAuthorizationHandler, DocumentReadAuthorizationHandler>();
            //services.AddScoped<IAuthorizationHandler, DocumentReadVersionAuthorizationHandler>();
            //services.AddScoped<IAuthorizationHandler, DocumentUpdateAuthorizationHandler>();
            //services.AddScoped<IAuthorizationHandler, DocumentCreationAuthorizationHandler>();
            //services.AddScoped<IAuthorizationHandler, DocumentRegistrationAuthorizationHandler>();
            //services.AddScoped<IAuthorizationHandler, DocumentDeregistrationAuthorizationHandler>();
            //services.AddScoped<IAuthorizationHandler, RemoveDocumentVersionAuthorizationHandler>();

            //services.AddScoped<IAuthorizationHandler, TaskReadRequirementAuthorizationHandler>();
            //services.AddScoped<IAuthorizationHandler, TaskUpdateRequirementAuthorizationHandler>();
            //services.AddScoped<IAuthorizationHandler, AssignmentReadAuthorizationHandler>();
            //services.AddScoped<IAuthorizationHandler, AssignmentPerformerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler, ReadAccessRightsAuthorizationHandler>();
            services.AddScoped<IAuthorizationHandler, GrantAccessRightsAuthorizationHandler>();
            services.AddScoped<IAuthorizationHandler, RevokeAccessRightsAuthorizationHandler>();
            services.AddScoped<IAuthorizationHandler, UpdateAccessRightsAuthorizationHandler>();

            //services.AddScoped<IAuthorizationHandler, DetachWorkflowAttachmentAuthorizationHandler>();
            //services.AddScoped<IAuthorizationHandler, PasteWorkflowAttachmentAuthorizationHandler>();
            
            services.AddAuthorization(config =>
            {
                config.AddSecurityPolicies();
            });

            return services;
        }
    }
}
