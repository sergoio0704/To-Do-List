using To_Do_List_Backend.Repositories;
using To_Do_List_Backend.Services;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddControllers();
builder.Services.AddScoped<ITodoRepository>( s =>
    new TodoRepository( builder.Configuration.GetValue<string>( "DefaultConnection" ) ) );
builder.Services.AddScoped<ITodoService, TodoService>();

var app = builder.Build();
app.MapControllers();
app.Run();
