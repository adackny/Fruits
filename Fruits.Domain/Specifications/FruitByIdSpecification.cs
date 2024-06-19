using System.Linq.Expressions;
using Fruits.Domain.Models;

namespace Fruits.Domain.Specifications
{
    public class FruitByIdSpecification : SpecificationBase<Fruit>
    {
        private readonly int _id;

        public FruitByIdSpecification(int id)
        {
            _id = id;
        }

        public override Expression<Func<Fruit, bool>> ToExpression()
        {
            return fruit => fruit.Id == _id;
        }
    }
}
