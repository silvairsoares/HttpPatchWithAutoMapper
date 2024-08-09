using HttpPatchWithAutoMapper.Domain.Pessoas;

namespace HttpPatchWithAutoMapper._Helpers
{
    public static class DependencyInjections
    {
        internal static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPessoasServices), typeof(PessoasServices));
        }
    }
}