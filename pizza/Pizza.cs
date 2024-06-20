using System.Timers;
using Microsoft.VisualBasic;

namespace Domain
{
    public abstract class BaseEntity
    {
        public Guid Id { get; init; }
        public BaseEntity(Guid id)
        {
            Id = id;
        }
        public override bool Equals(object? obj)
        {
            if (obj is BaseEntity e)
            {
                return e.Id == Id;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
    public class Pizza:BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Url { get; private set; }
        private HashSet<Ingredient> ingredients = new HashSet<Ingredient>();
        protected Pizza(Guid id,string name, string description, string url, List<Ingredient> ingredients):base(id)
        {
            Name = name;
            Description = description;
            Url = url;
            ingredients.ForEach(i=>this.ingredients.Add(i));
        }      
        public void Update(string name, string description, string url){
            Name= name;
            Description = description;
            Url = url;
            
            //evento
        }
        public void AddIngredient(Ingredient ingredient){
            ingredients.Add(ingredient);
            //evento->agregado piña
        }
        public void RemoveIngredient(Ingredient ingredient){
            if(!ingredients.Contains(ingredient)){
                throw new Exception("el ingrediente que intenas eliminar no existe");
            }
            ingredients.Remove(ingredient);
            //evento->tomate
        }
        public static Pizza Create(string name, string description, string url, List<Ingredient> ingredients){
            var pizza =  new Pizza(Guid.NewGuid(),name,description,url, ingredients );
            
            //evento->creado una pizza el catalog
            return pizza;
            
        } 
        public List<Ingredient> Ingredients {
            get{
                return ingredients.ToList();
            }
        }
        public decimal Price {
            get{
                return ingredients.Sum(i=>i.Price) * 1.2M;
            }
        } 
        
    }

    //Posible builder pattern
    //https://refactoring.guru/design-patterns/builder/csharp/example
    public class Ingredient : BaseEntity
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        protected Ingredient(Guid id, string name, decimal price) : base(id)
        {
            Name = name;
            Price = price;
        }
        public static Ingredient Create(string name, decimal price)
        {
            return new Ingredient(Guid.NewGuid(), name, price);
        }
    }

}