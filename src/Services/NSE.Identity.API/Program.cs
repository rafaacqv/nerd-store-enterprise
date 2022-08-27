using NSE.Identity.API.Config;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;


builder.Services.AddApiConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddIdentityConfiguration(config);


var app = builder.Build();

app.UseSwaggerConfiguration();
app.UseApiConfiguration(app.Environment);


app.Run();
