namespace SistemaClinica.BackEnd.API.Repository.Interfaces.Actions
{
    public interface IActualizarRepository<T> where T : class
    {
        void Actualizar(T t);
    }
}
