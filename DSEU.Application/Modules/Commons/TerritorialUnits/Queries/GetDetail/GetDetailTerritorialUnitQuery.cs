using MediatR;

namespace DSEU.Application.Modules.Commons.TerritorialUnits.Queries.GetDetail
{
    public class GetDetailTerritorialUnitQuery:IRequest<TerritorialUnitDto>
    {
        public int Id { get; set; }

        public GetDetailTerritorialUnitQuery(int id)
        {
            Id = id;
        }
    }
}
