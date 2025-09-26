using LibraryManagementSystem.Data;
using LibraryManagementSystem.DataService;
using LibraryManagementSystem.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IBooksServices, BooksServices>();
builder.Services.AddTransient<IAuthorsService, AuthorsService>();
builder.Services.AddTransient<ICategoriesService, CategoriesService>();
builder.Services.AddTransient<IFinesService , FinesService>();
builder.Services.AddTransient<ILoansService, LoansService>();
builder.Services.AddTransient<IMembersService, MembersService>();
builder.Services.AddTransient<IReservationsService, ReservationsService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
