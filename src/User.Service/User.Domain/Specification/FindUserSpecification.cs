using Specification;

namespace User.Domain.Specification;

public class FindUserSpecification : Specification<Domains.User>
{
	public FindUserSpecification(string email)
		:base(d => d.Email == email)
	{
		AddInclude(e => e.Roles);
	}
}