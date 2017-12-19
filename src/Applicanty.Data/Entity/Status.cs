using Applicanty.Data.Entity.Abstract;
using Applicanty.Data.Repositories;

namespace Applicanty.Data.Entity
{
    public class Status : Statable, IPrimary<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
