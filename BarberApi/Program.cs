using BarberApi.Models;
using BarberApi.Services;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("*");
                      });
});
builder.Services.Configure<BarberShopDatabaseSettings>(builder.Configuration.GetSection("BarberShopDatabase"));
builder.Services.AddSingleton<UsersService>();
builder.Services.AddSingleton<ServicesService>();
builder.Services.AddSingleton<AppointmentService>();
builder.Services.AddSingleton<BarberAvailabilityService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
