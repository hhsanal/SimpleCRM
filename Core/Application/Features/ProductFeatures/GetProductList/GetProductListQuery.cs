using MediatR;
using MindResult;

namespace Application.Features.ProductFeatures.GetProductList;

public record GetProductListQuery(): IRequest<Result<List<GetProductListResponse>>>;
