using CAT.Wishlist.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc.Authorization;
using CAT.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.Authority = builder.Configuration["IdentityServer"];
    options.Audience = "resource_wishlist";
    options.RequireHttpsMetadata = false;
});

builder.Services.AddDbContext<WishlistDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), configure =>
    {
        configure.MigrationsAssembly("CAT.Wishlist.Infrastructure");
    });
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();

builder.Services.AddMediatR(typeof(CAT.Wishlist.Application.Handlers.CreateWishlistCommandHandler).Assembly);

builder.Services.AddControllers(opt => opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy)));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var wishlistDbContext = serviceProvider.GetRequiredService<WishlistDbContext>();
    wishlistDbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
