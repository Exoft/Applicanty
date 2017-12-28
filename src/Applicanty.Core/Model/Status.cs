using Applicanty.Core.Abstract;

namespace Applicanty.Core.Model
{
    public class Status : Statable, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
