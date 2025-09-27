using Domain.Products;
using MediatR;
using MindResult;

namespace Application.Features.ProductFeatures.GetProductList;

public class GetProductListHandler(IProductDal productDal) : IRequestHandler<GetProductListQuery, Result<List<GetProductListResponse>>>
{
    public async Task<Result<List<GetProductListResponse>>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
       var allData = await productDal.GetProductsWithParameters(cancellationToken);
        List<GetProductListResponse> response = allData.Select(x => new GetProductListResponse
        {
            Id = x.Id,
            BrandName = x.Brand?.Name ?? "-",
            CategoryName = x.Category?.Name ?? "-",
            GroupName = x.Group?.Name ?? "-",
            Code = x.Code,
            CurrencyType = x.CurrencyType,
            DefaultDiscountRate = x.DefaultDiscountRate,
            Description = x.Description,
            ImageUrl = x.ImageUrl,
            Name = x.Name,
            TechnicalDocumentUrl = x.TechnicalDocumentUrl,
            VatRate = x.VatRate
        }).ToList();
        return CreateResult.Ok(response);
    }
}
