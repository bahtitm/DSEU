using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;
using DSEU.Application.Common.Behaviours;
//using DSEU.Application.Common.PreProcessors;
using DSEU.Application.Dtos;
//using DSEU.Application.Modules.Document.Documents.Commands.UpdateDocument;
//using DSEU.Application.Modules.Document.Documents.Queries.GetAllDocuments;
using DSEU.Application.Services;
//using DSEU.Application.Services.DocumentNameAutoGenerator;
using DSEU.Application.Services.Interfaces;

namespace DSEU.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDSEUApplicationCore(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //services.AddScoped<IDocumentRegisterService, DocumentRegisterRegistrationService>();
            //services.AddScoped<IDocumentRelationService, DocumentRelationService>();
            //services.AddScoped<IDocumentMapper, DocumentMapper>();
            //services.AddScoped<IDocumentNameAutogeneratorFactory, DocumentNameAutogeneratorFactory>();
            //services.AddScoped<IDocumentNameAutogenerationService, DocumentNameAutogenerationService>();
            //services.AddScoped<RussianDocumentNameAutoGenerator>();
            //services.AddScoped<TurkmenDocumentNameAutoGenerator>();
            //services.AddScoped<IDocumentAccessRightService, DocumentAccessRightService>();
            //services.AddScoped<IDocumentRelationService, DocumentRelationService>();
            //services.AddScoped<IHistoryService, HistoryService>();
            //services.AddScoped<IPipelineBehavior<GetAllDocuments, IEnumerable<ElectronicDocumentDto>>, FilterDocumentAccessRightsPipelineBehaviour>();

            //services.AddScoped<IWorkflowEntityAttachmentService, WorkflowEntityAttachmentService>();
            //services.AddScoped<IWorkflowMembersCalculator, WorkflowMembersCalculator>();
            //services.AddScoped<ITaskMapper, TaskMapper>();
            //services.AddScoped<IRequestPreProcessor<UpdateDocumentCommand>, DocumentValidationPreProcessor>();

            services.AddScoped<IAccessRightsService, AccessRightsService>();



            return services;
        }
    }
}
