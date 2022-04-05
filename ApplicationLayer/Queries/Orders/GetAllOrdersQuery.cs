using ApplicationLayer.Dapper;
using DomainLayer;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationLayer.Queries.Orders
{
    public class GetAllOrdersQuery : IRequest<IList<Order>>
    {
        public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrdersQuery, IList<Order>>
        {
            private IDapperRepository _dapper;
            public GetAllOrderQueryHandler(IDapperRepository dapper) => _dapper = dapper;
            public async Task<IList<Order>> Handle(GetAllOrdersQuery query, CancellationToken cancellationToken)
            {
                var sql = "Select * from Orders";
                var result = await _dapper.GetAllAsync<Order>(sql, null,commandType:System.Data.CommandType.Text);
                return result.ToList();
            }
        }
    }
}
