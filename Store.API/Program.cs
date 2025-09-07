using Microsoft.EntityFrameworkCore;
using Store.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseCors(options =>
{
  options.WithOrigins("https://localhost:3000")
         .AllowAnyHeader()
         .AllowAnyMethod();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
DbInitailzer.InitDb(app);
app.Run();
