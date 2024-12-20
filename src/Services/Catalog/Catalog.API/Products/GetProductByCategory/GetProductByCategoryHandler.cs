﻿
namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string catagory):IQuery<GetProductByCategoryResult>;
public record GetProductByCategoryResult(IEnumerable<Product> Products);


public class GetProductByCategoryQueryHandler(IDocumentSession session):IQueryHandler<GetProductByCategoryQuery,GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>().Where(p => p.Category.Contains(query.catagory)).ToListAsync(cancellationToken);
        if (products is null)
        {
            throw new ProductNotFoundException("No Data");
        }
        return new GetProductByCategoryResult(products);

    }
}