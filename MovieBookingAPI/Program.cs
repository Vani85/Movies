using MovieBookingAPI.Database;
using MovieBookingAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        options.AddDefaultPolicy(
           policy =>
           {
               policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                   .AllowAnyMethod()
                   .AllowCredentials()
                   .AllowAnyHeader();
           });
    }
});

builder.Services.AddDbContext<MovieBookingDbContext>();
builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddTransient<IMoviesRepository, MoviesRepository>();
builder.Services.AddTransient<ITheatreRepository, TheatreRepository>();

builder.Services.AddTransient<ITheatreSeatsRepository, TheatreSeatsRepository>();
builder.Services.AddTransient<IShowRepository, ShowRepository>();
builder.Services.AddTransient<IBookingRepository, BookingRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors();
app.MapControllers();


app.Run();