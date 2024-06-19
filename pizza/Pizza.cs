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
        protected Pizza(Guid id,string name, string description, string url):base(id)
        {
            Name = name;
            Description = description;
            Url = url;
        }      
        public void Update(string name, string description, string url){
            Name= name;
            Description = description;
            Url = url;
        }
        public void AddIngredient(Ingredient ingredient){
            ingredients.Add(ingredient);
        }
        public void RemoveIngredient(Ingredient ingredient){
            if(!ingredients.Contains(ingredient)){
                //TODO Lanzar una exceptions
            }
            ingredients.Remove(ingredient);
        }
        public static Pizza Create(string name, string description, string url){
            return new Pizza(Guid.NewGuid(),name,description,url );
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