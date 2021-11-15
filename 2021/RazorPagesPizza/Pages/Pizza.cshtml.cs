using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPizza.Models;
using RazorPagesPizza.Services;

namespace RazorPagesPizza.Pages
{
    public class PizzaModel : PageModel
    {
        // allows input and label controls to bind to it
        [BindProperty]
        public Pizza NewPizza { get; set; } = new Pizza();

        // used in razor page to list all pizzas
        public List<Pizza> pizzas = new List<Pizza>();

        // Default Page load event call (page get request)
        public void OnGet()
        {
            this.pizzas = PizzaService.GetAll();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                {
                    return Page();
                }
                PizzaService.Add(NewPizza);
                return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            PizzaService.Delete(id);
            return RedirectToAction("Get");
        }

        public string GlutenFreeText(Pizza pizza)
        {
            if (pizza.IsGlutenFree)
                return "Gluten Free";
            return "Not Gluten Free";
        }
    }
}
