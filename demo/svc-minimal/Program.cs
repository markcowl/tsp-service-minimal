using PetStore.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

PetApi.Register(app, () => new MyPetApi());


app.Run();


