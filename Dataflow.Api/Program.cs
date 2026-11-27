using Dataflow.Api.ApplicationExtensions;

using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDataflowApi(builder.Configuration);

var app = builder.Build();
app.UseDataflowApi();

app.Run();

public partial class Program { }
