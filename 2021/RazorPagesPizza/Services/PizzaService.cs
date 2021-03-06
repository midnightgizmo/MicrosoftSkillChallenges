using RazorPagesPizza.Models;

namespace RazorPagesPizza.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas {get;}
    static int nextID = 3;
    static PizzaService()
    {
        PizzaService.Pizzas = new List<Pizza>
        {
            new Pizza 
            {
                Id = 1,
                Name = "Classic Italian",
                Size = PizzaSize.Large,
                IsGlutenFree = false
            },
            new Pizza 
            {
                Id = 2,
                Name = "Veggie",
                Size = PizzaSize.Small,
                IsGlutenFree = true
            }

        };
    }

    public static List<Pizza> GetAll() => PizzaService.Pizzas.ToList();

    public static Pizza? Get(int id) => PizzaService.Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextID++;
        if(pizza is null)
            return;

        PizzaService.Pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null)
            return;

        PizzaService.Pizzas.Remove(pizza);
    }

    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return;

        Pizzas[index] = pizza;
    }
}