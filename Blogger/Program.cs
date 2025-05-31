using Blogger;
using Blogger.Data;
using Blogger.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();

builder.Services.AddDbContext<BloggerDBContext>
    (options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("BloggerDbConnectionString")));

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
