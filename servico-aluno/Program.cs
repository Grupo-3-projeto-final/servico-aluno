using AutoMapper;
using servico_aluno.Domain.Configurations;
using servico_aluno.Domain.Queue.Consumer;
using servico_aluno.Domain.Queue.Producer;
using servico_aluno.Infrastructure;
using servico_aluno.Infrastructure.Repositories;
using servico_aluno.Infrastructure.Repositories.Interfaces;
using servico_aluno.Infrastructure.Services;
using servico_aluno.Infrastructure.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStudentService, AlunoSevice>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IBoletoAlunoService, BoletoAlunoService>();
builder.Services.AddScoped<DatabaseConnection>();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<SqsProducerService>();

builder.Services.AddScoped<StudentAssessmentService>();
builder.Services.AddScoped<StudentAssessmentRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();


builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var _sqsConsumerService = new SqsConsumerService();
_sqsConsumerService.StartListeningAsync();


var app = builder.Build();

app.UseCors("CorsPolicy");

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
