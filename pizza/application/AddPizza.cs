using System.Data;
using Domain;
using Repository;

namespace Application{
    
    public readonly record struct CommandCreatePizza(
        string Name,
        string Description,
        string Url,
        List<Ingredient> Ingredients
    );
    public interface IAddPizza{
        Pizza Add(CommandCreatePizza command);
    }
    public class AddPizza : IAddPizza{
        private readonly IAdd<Pizza> _repository;
        public AddPizza(IAdd<Pizza> repository){
            _repository = repository;
        }

        public Pizza Add(CommandCreatePizza command)
        {
           var pizza = Pizza.Create(command.Name, command.Description, command.Url, command.Ingredients);
           _repository.Add(pizza);
           return pizza;
        }
    }
}