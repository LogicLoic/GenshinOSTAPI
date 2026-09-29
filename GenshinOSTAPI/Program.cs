using DTOs;
using Shared;
using Stub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<ITrackService<TrackDTO>, StubTrackDTO>();
builder.Services.AddSingleton<IAlbumService<AlbumDTO>, StubAlbumDTO>();
builder.Services.AddSingleton<IContainsService<ContainsDTO>, StubContainsDTO>();
builder.Services.AddSingleton<IUserService<UserDTO>, StubUserDTO>();
builder.Services.AddSingleton<IFriendService<FriendDTO>, StubFriendDTO>();

builder.Services.AddOpenApiDocument();

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
