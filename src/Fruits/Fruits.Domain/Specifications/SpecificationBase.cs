using System.Linq.Expressions;

namespace Fruits.Domain.Specifications
{
    public abstract class SpecificationBase<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {
            var predicate = ToExpression().Compile();

            return predicate(entity);
        }
    }
}
