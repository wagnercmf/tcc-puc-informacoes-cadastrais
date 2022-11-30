using Application.Interfaces;
using Application.UseCases;
using Domain.Services.Interfaces;
using Infrastructure.Kafka.KafkaProducer.ProducerBuilder;
using Infrastructure.Kafka.KafkaProducer;
using Infrastructure.Repositories;
using Confluent.Kafka;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IRegistrarAtendimentoUseCase, RegistrarAtendimentoUseCase>();
builder.Services.AddScoped<IGetPrestadoresPorEspecialidadeUseCase, GetPrestadoresPorEspecialidadeUseCase>();
builder.Services.AddScoped<ICalcularValorCorpaticipacaoDoAtendimentoUseCase, CalcularValorCorpaticipacaoDoAtendimentoUseCase>();
builder.Services.AddScoped<IPrestadorRepository, PrestadorRepository>();
builder.Services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
builder.Services.AddScoped<IAssociadoRepository, AssociadoRepository>();
builder.Services.AddSingleton<IKafkaProducer, KafkaProducer>();
builder.Services.AddSingleton<IProducerBuilder, KafkaProducerBuilder>();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Informações Cadastrais API"

    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

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
