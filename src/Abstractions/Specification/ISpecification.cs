﻿using System.Linq.Expressions;

namespace Specification;

public interface ISpecification<T>
{
  Expression<Func<T, bool>> Criteria { get; }
  IList<Expression<Func<T, object>>> Includes { get; }
  Expression<Func<T, object>> OrderBy { get; }
  Expression<Func<T, object>> OrderByDescending { get; }
}