namespace SistemaClinica.BackEnd.API.Repository.Interfaces.Actions
{
    public interface IInsertarRepository<T> where T : class
    {
        void Insertar(T t);
    }
}
