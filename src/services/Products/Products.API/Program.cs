using Products.API;
var builder = WebApplication.CreateBuilder(args);

builder.AddGeneralServices();
builder.AddInfrastructureservices();
builder.AddApplicationServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.MapControllers();
app.Run();
