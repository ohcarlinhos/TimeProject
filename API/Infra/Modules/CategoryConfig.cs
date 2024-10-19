using API.Core.Category;
using API.Core.Category.UseCases;
using API.Core.Category.Utils;
using API.Modules.Category;
using API.Modules.Category.UseCases;
using API.Modules.Category.Utils;

namespace API.Infra.Modules;

public static class CategoryConfig
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