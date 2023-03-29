//This service provides a simple in-memory data caching service with two pizzas by default. Our web api
// will use that service for demo purposes. When you stop and start the web API, the in-memory data cache
// will be reset to the two default pizzas for the constructor of PizzaService
using ContosoPizza.Models;

namespace ContosoPizza.Services;


public static class PizzaService
{

    static List<Pizza> Pizzas { get; }
    static int nextId = 3;
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza{ Id = 1, Name = "Classi Italian", IsGlutenFree = false },
            new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
        };
    }

    public static List<Pizza> GetAll() => Pizzas;

    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }
    public static void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is null) return;
        Pizzas.Remove(pizza);
    }
    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1) return;

        Pizzas[index] = pizza;
    }
}


// This is the Pizza Service right here

