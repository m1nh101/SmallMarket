using System.Linq.Expressions;

namespace Specification;

public class Specification<T> : ISpecification<T>
{
  public Specification()
  {
    Includes = new List<Expression<Func<T, object>>>();
  }

  public Specification(Expression<Func<T, bool>> expression)
  {
    Criteria = expression;
    Includes = new List<Expression<Func<T, object>>>();
  }

  public Expression<Func<T, bool>> Criteria { get; } = default!;

  public IList<Expression<Func<T, object>>> Includes { get; }

  public Expression<Func<T, object>> OrderBy { get; private set; } = default!;

  public Expression<Func<T, object>> OrderByDescending { get; private set; } = default!;

  protected void AddInclude(Expression<Func<T, object>> include) => Includes.Add(include);

  protected void AddOrderBy(Expression<Func<T, object>> orderBy) => OrderBy = orderBy;

  protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescending) => OrderByDescending = orderByDescending;
}