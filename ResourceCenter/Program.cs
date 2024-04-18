using Microsoft.EntityFrameworkCore;
using ResourceCenter.Data;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration["ConnectionStrings:Main"];//������ ����������� ��������� � secrets.json
if (string.IsNullOrEmpty(connectionString)) 
{
    throw new Exception("������ ����������� � ���� ������ �� �������");
}

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
