using Applicanty.Data.Entity;

namespace Applicanty.Data.Services
{
    public interface ITechnologyService: IEntityService<Technology>
    {
        Technology GetById(int Id);
    }
}
