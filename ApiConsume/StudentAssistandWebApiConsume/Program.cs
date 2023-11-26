using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<IStudentDal, EfStudentDal>();
builder.Services.AddScoped<IStudentService, StudentManager>();

builder.Services.AddScoped<INotesDal, EfNotesDal>();
builder.Services.AddScoped<INotesService, NotesManager>();

builder.Services.AddScoped<IDailyDal, EfDailyDal>();
builder.Services.AddScoped<IDailyService, DailyManager>();


builder.Services.AddCors(opt =>
    opt.AddPolicy("AssistantApiCors", opt =>
    {
        opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    }
    )
);  ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
