using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAuthentication("JwtAuth")
//    .AddJwtBearer("JwtAuth", options =>
//    {
//        options.Authority = "your-auth-provider";
//        options.Audience = "bank-api";
//    });


// Load ocelot.json configuration
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Add Ocelot services
builder.Services.AddOcelot();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

await app.UseOcelot();

app.Run();
