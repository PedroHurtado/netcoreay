namespace respository{
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
}