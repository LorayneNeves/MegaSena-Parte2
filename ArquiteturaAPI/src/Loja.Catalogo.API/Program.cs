using Catalogo.Application.Services;
using Catalogo.Data.Repository;
using Catalogo.Domain.Interfaces;
using LOJAH1.Catalogo.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
