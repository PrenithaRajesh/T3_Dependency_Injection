using backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//When you register all three implementations under the same interface (ICounter)
// but with different lifetimes, 
// it doesn't know which implementation to inject,
// as each request could potentially have a different version of ICounter

//knows which implementation to inject based on the type requested
builder.Services.AddSingleton<SingletonCounter>();
builder.Services.AddScoped<ScopedCounter>();
builder.Services.AddTransient<TransientCounter>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", (corsBuilder) =>
    {
        corsBuilder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("DevCors");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.MapControllers();
app.Run();
