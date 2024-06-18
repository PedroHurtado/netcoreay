using System.Data.Common;
using System.Reflection.Metadata;

namespace Segregation{
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

    public class Customer{}
    public class User{}
    public class RepositoruCustomer : IAll<Customer, int>
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }

    public class RepositoryUser : IGet<User, int>
    {
        public User Get(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class ServiceUser{
        public ServiceUser(IGet<User,int> repositoruser){
            
            //repositoryUser.Get
        }
    }
    public class ServiceCustomer{
        public ServiceCustomer(IAll<Customer,int> repositoruCustomer){
            
            //repositoryCustomer.Add
            //repositoryCustomer.Update
            //repositoryCustomer.Remove
            //repositoryCustomer.Get
        }
    }

    public class ControllerCustomer{
        public ControllerCustomer(){
            var customerServie = new ServiceCustomer(new RepositoruCustomer());
            var userService = new ServiceUser(new RepositoryUser());
            
        }
    }
    
}