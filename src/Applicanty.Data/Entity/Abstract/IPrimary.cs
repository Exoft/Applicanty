
namespace Applicanty.Data.Entity.Abstract
{
    public interface IPrimary<TKey>
    {
        TKey Id { get; set; }
    }
}
