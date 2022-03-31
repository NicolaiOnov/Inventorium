namespace Inventorium.Server.Services.DbInitializer
{
    public interface IDbInitializerService
    {
        void Initialize(bool recreateDb);
    }
}
