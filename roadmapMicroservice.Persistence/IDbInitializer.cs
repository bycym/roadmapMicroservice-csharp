namespace Roadmap.Microservice.Persistence
{
  public interface IDbInitializer
  {
    void Initialize();
    void SeedData();
  }
}