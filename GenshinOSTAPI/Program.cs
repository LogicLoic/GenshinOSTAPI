using DTOs;
using Shared;
using Stub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<ITrackService<TrackDTO>, StubTrackDTO>();

builder.Services.AddOpenApiDocument(options => {
     options.PostProcess = document =>
     {
         document.Info = new NSwag.OpenApiInfo
         {
             Version = "v1",
             Title = "My API Title",
             Description = "My API Description",
             TermsOfService = "https://terms.of.service.fr/",
             Contact = new NSwag.OpenApiContact
             {
                 Name = "Code Lord",
                 Url = "https://code.lord.fr"
             },
             License = new NSwag.OpenApiLicense
             {
                 Name = "Code Lord",
                 Url = "https://license.fr"
             }
         };
     };
});

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
