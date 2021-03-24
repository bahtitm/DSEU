using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.ElasticSearch.Commands.DeleteElasticSearch
{
    public class DeleteElasticSearchCommand : IRequest
    {
        public int id;

        public DeleteElasticSearchCommand(int id)
        {
            this.id = id;
        }
    }
}
