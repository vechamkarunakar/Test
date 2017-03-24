using AssureNetServicesPOC.DAL;

namespace AssureNetServicesPOC
{
    public interface IUnitOfWork<TEntity> where TEntity : class
    {
        GenericRepo<TEntity> GetEntities { get; }

        void Dispose();
    }
}