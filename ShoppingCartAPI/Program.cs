using Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(corsOptions => {
    corsOptions.AddPolicy(
        name: "MyPolicy",
        policy => {
            policy.WithOrigins("https://localhost:7090")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        }
    );
});
// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlite();
});
builder.Services.AddTransient<IDBRepository, DBRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddCors(options => {
//     options.AddPolicy("MyPolicy", builder => {
//         builder.AllowAnyOrigin()
//             .AllowAnyMethod()
//             .AllowAnyHeader();
//     });
// });
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
Console.WriteLine("API Running");
// app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

Console.WriteLine("API Running");

app.Run();