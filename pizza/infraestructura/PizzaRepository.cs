using Domain;
namespace Repository{

    public interface IAdd<T>{
        void Add(T entity);
    }

    public interface IGet<T, ID>{
        T Get(ID id);
    }

    public interface IUpdate<T,ID>:IGet<T,ID>{
        void Update(T entity);
    }

    public interface IRemove<T,ID>:IGet<T,ID>{
        void Remove(T entity);
    }

    public interface IAll<T,ID>:IUpdate<T,ID>,IRemove<T,ID>,IAdd<T>{

    }

    //implementacion

    public class PizzaRepositoy : IAll<Pizza, Guid>
    {
        private readonly List<Pizza> pizzas = [];
        public void Add(Pizza entity)
        {
            pizzas.Add(entity);
        }

        public Pizza Get(Guid id)
        {
            var pizza = pizzas.Where(p=>p.Id == id).FirstOrDefault();
            if(pizza==null){
                throw new Exception("la pizza no existe");
            }
            return pizza;
        }

        public void Remove(Pizza entity)
        {
            this.pizzas.Remove(entity);
        }

        public void Update(Pizza entity)
        {
            var index = this.pizzas.IndexOf(entity);
            if(index>0){
                pizzas[index] = entity;
            }
        }
    }
}