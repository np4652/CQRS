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

namespace ApplicationLayer.Commands.Products
{
    public class DeleteProductByIdCommand : IRequest<int>
    {
        [Required]
        public int ProductId { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
        {
            private readonly IConfiguration _configuration;
            public DeleteProductByIdCommandHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
            {
                var sql = "DELETE FROM Products WHERE ProductId = @ProductId";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql, new { ClientID = request.ProductId });
                    return result;
                }
            }
        }
    }
}
