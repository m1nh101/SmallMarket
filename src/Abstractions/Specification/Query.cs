namespace Specification;
using Microsoft.EntityFrameworkCore;

public static class Query
{
  public static IQueryable<TEntity> Evaluator<TEntity>(IQueryable<TEntity> sources,
    ISpecification<TEntity> spec, bool asNoTracking = false)
    where TEntity : class
  {
    IQueryable<TEntity> result = asNoTracking
      ? sources.AsNoTracking()
      : sources;

    if (spec.Criteria is not null)
      result = result.Where(spec.Criteria);

    result = spec.Includes.Aggregate(result, (current, expression) =>
      current.Include(expression));

    if (spec.OrderBy is not null)
      result = result.OrderBy(spec.OrderBy);

    if (spec.OrderByDescending is not null)
      result = result.OrderByDescending(spec.OrderByDescending);

    return result;
  }

  public static TEntity Get<TEntity>(IQueryable<TEntity> sources,
    ISpecification<TEntity> spec, bool asNoTracking = false)
    where TEntity : class
  {
    IQueryable<TEntity> source = asNoTracking
      ? sources.AsNoTracking()
      : sources;

    source = spec.Includes.Aggregate(source, (current, expression) =>
      current.Include(expression));

    var result = source.FirstOrDefault(spec.Criteria);

    if (result == null)
      throw new NullReferenceException();

    return result;
  }

  public static bool IsExist<TEntity>(IQueryable<TEntity> sources,
    ISpecification<TEntity> spec)
  {
    return sources.Any(spec.Criteria);
  }
}