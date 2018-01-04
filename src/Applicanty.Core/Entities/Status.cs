using Applicanty.Core.Entities.Abstract;

namespace Applicanty.Core.Entities
{
    public class Status : Statable, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
