using CadastroAPP.API.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// endPOint em caixa baixa
builder.Services.AddRouting(option => option.LowercaseUrls = true );

//configurar AutoMapper
builder.Services.AddAutoMapper(typeof(ProfileMap));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configurar CORS
builder.Services.AddCors(
config => config.AddPolicy("DefaultPolicy", builder => {
    builder.WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader();
})
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// CORS
app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();
