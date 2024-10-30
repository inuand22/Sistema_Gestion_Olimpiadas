namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorio<T>
    {
        void Add(T obj);
        void Update(T obj);
        T FindById(int id);
        IEnumerable<T> FindAll();
        void Remove(int id);
    }
}
