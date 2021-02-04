using Microsoft.AspNetCore.Authorization;
using DSEU.Security.AccessRights;
using DSEU.Security.Admin.Requirements;
//using DSEU.Security.Assignments;
using DSEU.Security.Commons;
using DSEU.Security.Company;
using DSEU.Security.CoreEntities;
using DSEU.Security.Parties;
using DSEU.Security.Policies;

//todo history link
//using DSEU.Security.Tasks;
//using DSEU.Security.Documents;
//using DSEU.Security.Docflow;
//using DSEU.Security.WorkflowAttachment;

namespace DSEU.Security.Extensions
{
    public static class AuthorizationOptionsExtensions
    {
        public static void AddSecurityPolicies(this AuthorizationOptions options)
        {
            options.AddAdminPolicy();
            options.AddCommonsPolicies();
            options.AddCompanyPolicies();
            options.AddPartiesPolicies();
            options.AddCoreEntitiesPolicies();
            options.AddPermissionsPolicy();

            //todo history link
            //options.AddAssignmentPerformerPolicies();
            //options.AddTaskPolicies();
            //options.AddDocumentsPolicies();
            //options.AddDocflowPolicies();
            //options.AddWorkflowAttachmentPolicies();
        }

        public static void AddAdminPolicy(this AuthorizationOptions options)
        {
            options.AddPolicy(GeneralPolicy.Admin,
                       builder => builder.AddRequirements(new AdminRequirement()));
        }
    }
}
