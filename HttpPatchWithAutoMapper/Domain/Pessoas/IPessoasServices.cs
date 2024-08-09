using HttpPatchWithAutoMapper.Domain.Pessoas.ViewModels;
using Microsoft.AspNetCore.JsonPatch;

namespace HttpPatchWithAutoMapper.Domain.Pessoas
{
    public interface IPessoasServices
    {
        Task<Pessoa> Add(Pessoa pessoa);

        Task<ICollection<Pessoa>> GetByFilter(string? filter);

        Task<Pessoa> Update(Pessoa pessoa);

        Task<Pessoa> UpdateJsonPatch(string id, JsonPatchDocument<Pessoa> pessoa);

        Task<Pessoa> UpdateAutoMapper(Pessoa pessoa);
    }
}
