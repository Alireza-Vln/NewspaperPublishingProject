using Microsoft.EntityFrameworkCore;
using NewspaperPublishing.Contracts.Interfaces;
using NewspaperPublishing.Infrastructure;
using NewspaperPublishing.Persistence.EF;
using NewspaperPublishing.Persistence.EF.Newses;
using NewspaperPublishing.Persistence.EF.Newspapers;
using NewspaperPublishing.Services.Newes.Contracts;
using NewspaperPublishing.Spec.Tests.Authors;
using NewspaperPublishing.Spec.Tests.Categories;
using NewspaperPublishing.Spec.Tests.Newses;
using NewspaperPublishing.Spec.Tests.Newspapers;
using NewspaperPublishing.Spec.Tests.Tags;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile("appsettings.json");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EFDataContext>(
    options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<UnitOfWork,EFUnitOfWork>();
builder.Services.AddScoped<DateTimeService, DateTimeAppService>();
builder.Services.AddScoped<CategoryService, CategoryAppService>();
builder.Services.AddScoped<CategoryRepository,EFCategoryRepository>();
builder.Services.AddScoped<TagService, TagAppService>();
builder.Services.AddScoped<TagRepository,EFTagRepository>();
builder.Services.AddScoped<NewsRepository,EFNewsRepository>();
builder.Services.AddScoped<NewsService, NewsAppService>();
builder.Services.AddScoped<AuthorService,AuthorAppService>();
builder.Services.AddScoped<AuthorRepository, EFAuthorRepository>();
builder.Services.AddScoped<NewspaperRepository, EFNewspaperRepository>();
builder.Services.AddScoped<NewspaperService,NewspaperAppService>();

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
