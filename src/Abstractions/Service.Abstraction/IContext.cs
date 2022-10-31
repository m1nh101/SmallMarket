namespace Service.Abstraction;

public interface IContext
{
  Task Commit();
}
