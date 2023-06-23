using AutoMapper;
using ChallengeBeClever.Application.Interfaces;
using ChallengeBeClever.Application.UseCases.Auth;
using ChallengeBeClever.Application.UseCases.Payment.Get;
using ChallengeBeClever.Application.UseCases.Payment.Post;
using ChallengeBeClever.Infrastructure;
using ChallengeBeClever.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Donot forgot to add ConnectionStrings as "dbConnection" to the appsetting.json file
builder.Services.AddDbContext<DatabaseContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();
builder.Services.AddTransient<IPaymentPostService, PaymentPostService>();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IPaymentGetService, PaymentGetService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

#region Configure Swagger  

// Auto Mapper Configurations
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new ChallengeBeClever.Api.Controllers.Payment.Post.MappingProfile());
    mc.AddProfile(new ChallengeBeClever.Application.UseCases.Payment.Post.MappingProfile());
    mc.AddProfile(new ChallengeBeClever.Api.Controllers.Payment.Get.MappingProfile());
    mc.AddProfile(new ChallengeBeClever.Application.UseCases.Payment.Get.MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BasicAuth", Version = "v1" });
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Basic Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });
});
#endregion

builder.Services.Configure<SwaggerGenOptions>(options =>
{
    options.CustomSchemaIds(x => x.FullName);
    options.UseAllOfToExtendReferenceSchemas();
});

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