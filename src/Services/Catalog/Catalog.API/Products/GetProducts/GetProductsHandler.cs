using Marten.Pagination;

namespace DefaultNamespace;


public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<Product> Products);
     

internal class GetProductHandler(IDocumentSession session,  ILogger<GetProductHandler> logger) : 
    IQueryHandler<GetProductsQuery, GetProductsResult> 
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    { 
        logger.LogInformation("Handle get products witj {@Query}", query);
        var products = await session.Query<Product>().ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);
        return new GetProductsResult(products);
    }
}