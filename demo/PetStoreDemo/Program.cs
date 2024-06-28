using PetStore;
using PetStoreDemo;

// See https://aka.ms/new-console-template for more information
var pets = new PetStoreClient(new Uri("https://localhost:7213"));
var menu = new PetMenu(pets);
menu.Dispatch();

