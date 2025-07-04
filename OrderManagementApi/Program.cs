using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderManagementApi.DataAccess.Abstract;
using OrderManagementApi.DataAccess.Entities;
using OrderManagementApi.DataAccess.Repository;
using OrderManagementApi.Service.Abstract;
using OrderManagementApi.Service.Service;
using OrderManagementApi.Service.Validator.OrderItem;
using OrderManagementApi.Service.Validator.OrderValidator;
using OrderManagementApi.Service.Validator.Product;
using OrderManagementApi.Service.Validator.User;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContext, OrderManagementContext>();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.AddHttpClient();




builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderMainManagerService, OrderMainManagerService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IOrderItemMainManagerService, OrderItemMainManagerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILoginService, LoginService>();


builder.Services.AddHttpClient<TokenCacheService>();
builder.Services.AddHttpClient<OrderService>();

builder.Services.AddSingleton<TokenCacheService>(); 
builder.Services.AddScoped<OrderService>();



builder.Services.AddScoped<OrderService>();

builder.Services.AddScoped<OrderSaveRequestValidator>();
builder.Services.AddScoped<OrderUpdateRequestValidator>();
builder.Services.AddScoped<OrderItemSaveRequestValidator>();
builder.Services.AddScoped<OrderItemUpdateRequestValidator>();
builder.Services.AddScoped<ProductSaveRequestValidator>();
builder.Services.AddScoped<ProductUpdateRequestValidator>();
builder.Services.AddScoped<UserSaveRequestValidator>();
builder.Services.AddScoped<UserUpdateRequestValidator>();


builder.Services.AddHttpClient();


builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var jwtSettings = builder.Configuration.GetSection("Jwt");
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
