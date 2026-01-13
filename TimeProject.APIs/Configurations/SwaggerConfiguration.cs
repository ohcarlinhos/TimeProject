// using Microsoft.OpenApi;
//
// namespace TimeProject.APIs.Configurations;
//
// public static class SwaggerConfiguration
// {
//     public static void AddSwaggerConfig(this WebApplicationBuilder builder)
//     {
//         builder.Services.AddSwaggerGen(options =>
//         {
//             options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
//             {
//                 Name = "Authorization",
//                 In = ParameterLocation.Header,
//                 Type = SecuritySchemeType.ApiKey,
//                 Scheme = "Bearer"
//             });
//
//             options.AddSecurityRequirement(new OpenApiSecurityRequirement()
//             {
//                 {
//                     new OpenApiSecurityScheme()
//                     {
//                         Reference = new OpenApiReference
//                         {
//                             Type = ReferenceType.SecurityScheme,
//                             Id = "Bearer"
//                         },
//                         Scheme = "oauth2",
//                         Name = "Bearer",
//                         In = ParameterLocation.Header
//                     },
//                     new List<string>()
//                 }
//             });
//         });
//     }
// }