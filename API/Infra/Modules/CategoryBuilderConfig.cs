using API.Modules.Category;
using API.Modules.Category.UseCases;
using API.Modules.Category.Utils;
using Core.Category;
using Core.Category.UseCases;
using Core.Category.Utils;

namespace API.Infra.Modules;

public static class CategoryBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICategoryMapDataUtil, CategoryMapDataUtil>();

        builder.Services.AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>();
        builder.Services.AddScoped<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
        builder.Services.AddScoped<IGetAllCategoryUseCase, GetAllCategoryUseCase>();
        builder.Services.AddScoped<IGetPaginatedCategoryUseCase, GetPaginatedCategoryUseCase>();
        builder.Services.AddScoped<IUpdateCategoryUseCase, UpdateCategoryUseCase>();
    }
}