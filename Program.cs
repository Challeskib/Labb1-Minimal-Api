using FluentValidation;
using Labb1_Minimal_Api.Data;
using Labb1_Minimal_Api.Models;
using Labb1_Minimal_Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<Book>, BookRepository>();
builder.Services.AddScoped<IRepository<Genre>, GenreRepository>();
builder.Services.AddScoped<IRepository<Author>, AuthorRepository>();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Book code below

app.MapGet("/books", async (IRepository<Book> BookRepo) =>
{
    ApiResponse response = new ApiResponse();

    response.Result = await BookRepo.GetAll();
    response.IsSuccess = true;
    response.StatusCode = System.Net.HttpStatusCode.OK;

    return Results.Ok(response);
}).WithName("GetBooks").Produces(200);

app.MapGet("/books/{id:int}", async (int id, IRepository<Book> bookRepo) =>
{
    ApiResponse response = new ApiResponse();

    response.Result = await bookRepo.GetById(id);
    response.IsSuccess = true;
    response.StatusCode = System.Net.HttpStatusCode.OK;

    return Results.Ok(response);
}).WithName("GetCoupon");

app.MapPost("/books", async ([FromBody] Book newBook, IRepository<Book> bookRepo, IValidator<Book> validator) =>
{
    ApiResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

    var validationResult = await validator.ValidateAsync(newBook);
    if (!validationResult.IsValid)
    {
        return Results.BadRequest(response);
    }

    if (newBook == null)
    {
        return Results.BadRequest("Invalid id or Book body");
    }
    else
    {
        response.Result = await bookRepo.Create(newBook);
        response.IsSuccess = true;
        response.StatusCode = System.Net.HttpStatusCode.OK;

        return Results.Ok(response);
    }

}).WithName("CreateBook");

app.MapPut("/books", async (Book bookToUpdate, IRepository<Book> bookRepo, IValidator<Book> validator) =>
{
    ApiResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

    var validationResult = await validator.ValidateAsync(bookToUpdate);
    if (!validationResult.IsValid)
    {
        return Results.BadRequest(response);
    }

    if (bookToUpdate == null)
    {
        return Results.BadRequest("Invalid id or Book body");
    }
    else
    {
        response.Result = await bookRepo.Update(bookToUpdate);
        response.IsSuccess = true;
        response.StatusCode = System.Net.HttpStatusCode.OK;

        return Results.Ok(response);
    }

}).WithName("UpdateBook");

app.MapDelete("/books/{id:int}", async (int id, IRepository<Book> bookRepo) =>
{
    ApiResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

    Book bookToDelete = await bookRepo.GetById(id);

    if (bookToDelete == null)
    {
        return Results.BadRequest("Book Id does not exist");
    }
    else
    {
        response.Result = await bookRepo.Delete(bookToDelete.Id);
        response.IsSuccess = true;
        response.StatusCode = System.Net.HttpStatusCode.OK;

        return Results.Ok(response);
    }

}).WithName("DeleteBook");

//Author code below

app.MapGet("/authors", async (IRepository<Author> authorRepo) =>
{
    ApiResponse response = new ApiResponse();

    response.Result = await authorRepo.GetAll();
    response.IsSuccess = true;
    response.StatusCode = System.Net.HttpStatusCode.OK;

    return Results.Ok(response);
}).WithName("GetAuthors").Produces(200);

app.MapGet("/authors/{id:int}", async (int id, IRepository<Author> authorRepo) =>
{
    ApiResponse response = new ApiResponse();

    response.Result = await authorRepo.GetById(id);
    response.IsSuccess = true;
    response.StatusCode = System.Net.HttpStatusCode.OK;

    return Results.Ok(response);
}).WithName("GetAuthor");

app.MapPost("/authors", async (Author newAuthor, IRepository<Author> authorRepo, IValidator<Author> validator) =>
{
    ApiResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

    var validationResult = await validator.ValidateAsync(newAuthor);
    if (!validationResult.IsValid)
    {
        return Results.BadRequest(response);
    }

    if (newAuthor == null)
    {
        return Results.BadRequest("Invalid id or Author body");
    }
    else
    {
        response.Result = await authorRepo.Create(newAuthor);
        response.IsSuccess = true;
        response.StatusCode = System.Net.HttpStatusCode.OK;

        return Results.Ok(response);
    }

}).WithName("CreateAuthor");

app.MapPut("/authors", async (Author authorToUpdate, IRepository<Author> authorRepo) =>
{
    ApiResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

    if (authorToUpdate == null)
    {
        return Results.BadRequest("Invalid id or Author body");
    }
    else
    {
        response.Result = await authorRepo.Update(authorToUpdate);
        response.IsSuccess = true;
        response.StatusCode = System.Net.HttpStatusCode.OK;

        return Results.Ok(response);
    }

}).WithName("UpdateAuthor");

app.MapDelete("/authors/{id:int}", async (int id, IRepository<Author> authorRepo) =>
{
    ApiResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

    Author authorToDelete = await authorRepo.GetById(id);

    if (authorToDelete == null)
    {
        return Results.BadRequest("Author Id does not exist");
    }
    else
    {
        response.Result = await authorRepo.Delete(authorToDelete.Id);
        response.IsSuccess = true;
        response.StatusCode = System.Net.HttpStatusCode.OK;

        return Results.Ok(response);
    }

}).WithName("DeleteAuthor");

// Genre logic below 

app.MapGet("/genres", async (IRepository<Genre> genreRepo) =>
{
    var response = new ApiResponse();

    response.Result = await genreRepo.GetAll();
    response.IsSuccess = true;
    response.StatusCode = System.Net.HttpStatusCode.OK;

    return Results.Ok(response);
}).WithName("GetGenres").Produces(200);

app.MapGet("/genres/{id:int}", async (int id, IRepository<Genre> genreRepo) =>
{
    var response = new ApiResponse();

    response.Result = await genreRepo.GetById(id);
    response.IsSuccess = true;
    response.StatusCode = System.Net.HttpStatusCode.OK;

    return Results.Ok(response);
}).WithName("GetGenre");

app.MapPost("/genres", async (Genre newGenre, IRepository<Genre> genreRepo) =>
{
    var response = new ApiResponse() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

    if (newGenre == null)
    {
        return Results.BadRequest("Invalid id or Genre body");
    }
    else
    {
        response.Result = await genreRepo.Create(newGenre);
        response.IsSuccess = true;
        response.StatusCode = System.Net.HttpStatusCode.OK;

        return Results.Ok(response);
    }

}).WithName("CreateGenre");

app.MapPut("/genres", async (Genre genreToUpdate, IRepository<Genre> genreRepo) =>
{
    var response = new ApiResponse() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

    if (genreToUpdate == null)
    {
        return Results.BadRequest("Invalid id or Genre body");
    }
    else
    {
        response.Result = await genreRepo.Update(genreToUpdate);
        response.IsSuccess = true;
        response.StatusCode = System.Net.HttpStatusCode.OK;

        return Results.Ok(response);
    }

}).WithName("UpdateGenre");

app.MapDelete("/genres/{id:int}", async (int id, IRepository<Genre> genreRepo) =>
{
    var response = new ApiResponse() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

    Genre genreToDelete = await genreRepo.GetById(id);

    if (genreToDelete == null)
    {
        return Results.BadRequest("Genre Id does not exist");
    }
    else
    {
        response.Result = await genreRepo.Delete(genreToDelete.Id);
        response.IsSuccess = true;
        response.StatusCode = System.Net.HttpStatusCode.OK;

        return Results.Ok(response);
    }

}).WithName("DeleteGenre");


app.UseHttpsRedirection();

app.Run();


