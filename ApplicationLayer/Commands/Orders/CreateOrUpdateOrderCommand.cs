using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationLayer.Commands.Orders
{
    public class CreateOrUpdateOrderCommand : IRequest<int>
    {
        public int OrderId { get; set; }
        [Required]
        public string OrderDetails { get; set; }
        public class CreateOrUpdateOrderCommandHandler : IRequestHandler<CreateOrUpdateOrderCommand, int>
        {
            private readonly IConfiguration configuration;
            public CreateOrUpdateOrderCommandHandler(IConfiguration configuration)
            {
                this.configuration = configuration;
            }
            public async Task<int> Handle(CreateOrUpdateOrderCommand request, CancellationToken cancellationToken)
            {
                int result = 0;
                try
                {
                    if (request.OrderId > 0)
                    {
                        var sql = "Update Orders set OrderDetails = @OrderDetails Where OrderId = @OrderId";
                        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                        {
                            result = await connection.ExecuteAsync(sql, request);
                        }
                    }
                    else
                    {
                        var sql = "Insert into Orders (OrderDetails,IsActive,OrderedDate) VALUES (@OrderDetails,1,GetDate())";
                        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                        {
                            result = await connection.ExecuteAsync(sql, new { request.OrderDetails });
                        }
                    }

                }
                catch (Exception ex)
                {

                }
                return result;
            }
        }
    }
}
