using _03_WebApi_WithApiKey.Models.Data;
using _03_WebApi_WithApiKey.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<IProductManager, MockupProductManager>();
builder.Services.AddScoped<IProductManager, ProductManager>();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*  
 
    CORS - Cross Origin Resource Sharing
    ------------------------------------------------------------------------------------------------------------------------------------------------
    AllowAnyOrigin()    =   Vilken adress får komma åt apiet            https://localhost:7070/, https://domain.com/, https://domain.com:8080/  
    AllowAnyMethod()    =   Vilken metod tar apiet emot                 HTTP Request Methods:  POST, GET, PUT, PATCH, DELETE     
    AllowAnyHeader()    =   Vad för typ av metadata behövs/tillåts      ContentType         "Content-Type": "application/json"
                                                                        Authentication      "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
                                                                        ApiKey              "code": "b2NoIHPDpSBza3JpdmVyIGphZyBuw6Vnb3QgaMOkcg=="
 
    
    JS
    ---------------------------------------------------------------------------------------------
    fetch("https://domain.com/api/products?code=b2NoIHPDpSBza3JpdmVyIGphZyBuw6Vnb3QgaMOkcg==", {
        method: "post",
        headers: {
            "Content-Type": "application/json",
            "code": "aMOkciBoYXIgamFnIGVuIGFubmFuIGtvZCBzbnV0dA=="
        },
        body: JSON.stringify(product)
    })
    .then(res => res.text())
    .then(data => { console.log(data) })

    fetch("https://domain.com/api/products?code=b2NoIHPDpSBza3JpdmVyIGphZyBuw6Vnb3QgaMOkcg==")
    .then(res => res.json())
    .then(data => { console.log(data) })

*/


app.UseCors(x => x.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
