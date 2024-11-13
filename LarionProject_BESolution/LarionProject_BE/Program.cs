using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using Models.Mapping;
using Services.Implementations;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LarionDatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IFollowActionService, FollowActionService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddAutoMapper(typeof(GenerateProfile));
builder.Services.AddScoped<ILikeActionService, LikeActionService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddCors(OptionsBuilderConfigurationExtensions =>
{
    OptionsBuilderConfigurationExtensions.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
