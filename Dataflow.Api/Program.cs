using Dataflow.Api.ApplicationExtensions;

using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDataflowApi();

var app = builder.Build();
app.UseDataflowApi();

app.Run();

public partial class Program { }
