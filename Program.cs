using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/dado/d{numeroDeFaces}", ([FromRoute] int numeroDeFaces) =>

{   
    if (numeroDeFaces <= 0)
    {
        return Results.BadRequest (new {mensagem = "Digite um número de faces maior que zero!!!!"});
    }

    int face = RandomNumberGenerator.GetInt32(1, numeroDeFaces + 1);
    return Results.Ok (new {dado = $"d{numeroDeFaces}", rolagem = face});
});

app.Run();