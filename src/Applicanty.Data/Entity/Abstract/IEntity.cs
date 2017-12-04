
namespace Applicanty.Data.Entity.Abstract
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
