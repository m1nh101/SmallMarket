using Order.Domain.Domains;
using Specification;

namespace Order.Domain.Specifications;

public class CurrentOrderSpecification : Specification<Cart>
{
	public CurrentOrderSpecification(int userId)
		:base(e => !e.IsCheckout && e.UserId == userId)
	{
		AddInclude(e => e.Items);
	}
}