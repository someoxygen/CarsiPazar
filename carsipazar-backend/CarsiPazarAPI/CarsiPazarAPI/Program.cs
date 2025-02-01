using CarsiPazarAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using CarsiPazarAPI.Helpers;
using Google.Cloud.Firestore;
using CarsiPazarAPI.Services;
using System.Text.Json;
using Npgsql;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
var key = Encoding.ASCII.GetBytes(configuration.GetSection("Appsettings:Token").Value);
//builder.Services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
builder.Services.AddDbContext<DataContext>(options =>options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString")));
//builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly(), typeof(Profile).Assembly);
builder.Services.AddMvc(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});


// Firebase configuration
var firebaseConfig = builder.Configuration.GetSection("Firebase");
var firebaseSections = configuration.GetSection("Firebase:Credentials").Get<Dictionary<string, string>>();
string projectId = firebaseConfig["ProjectId"];
string privateKeyPath = firebaseConfig["PrivateKeyPath"];

FirestoreDb firestoreDb = new FirestoreDbBuilder
{
    ProjectId = projectId,
    JsonCredentials = File.ReadAllText(privateKeyPath)
}.Build();

//string privateKey = firebaseSections["private_key"].Replace("\\n", "\n");
//string jsonCredentials = JsonSerializer.Serialize(new
//{
//    type = firebaseSections["type"],
//    project_id = firebaseSections["project_id"],
//    private_key_id = firebaseSections["private_key_id"],
//    private_key = privateKey,
//    client_email = firebaseSections["client_email"],
//    client_id = firebaseSections["client_id"],
//    auth_uri = firebaseSections["auth_uri"],
//    token_uri = firebaseSections["token_uri"],
//    auth_provider_x509_cert_url = firebaseSections["auth_provider_x509_cert_url"],
//    client_x509_cert_url = firebaseSections["client_x509_cert_url"]
//});
//FirestoreDb firestoreDb = new FirestoreDbBuilder
//{
//    ProjectId = projectId,
//    JsonCredentials = jsonCredentials
//}.Build();


builder.Services.AddCors();
builder.Services.AddScoped<IAppRepository, AppRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});
builder.Services.AddSingleton(firestoreDb);
builder.Services.AddScoped<FirebaseService>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(hostName => true));

app.UseAuthentication();

app.Run();
