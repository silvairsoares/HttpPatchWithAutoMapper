using HttpPatchWithAutoMapper.Domain.Pessoas;
using HttpPatchWithAutoMapper.Domain.Pessoas.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HttpPatchWithAutoMapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoasServices _pessoasServices;

        public PessoasController(IPessoasServices pessoasServices)
        {
            _pessoasServices = pessoasServices;
        }

        /// <summary>
        /// Cadastra uma nova pessoa
        /// </summary>
        /// <returns></returns>
        [HttpPost("api/pessoas")]
        public async Task<Pessoa> Add([FromBody] Pessoa pessoa)
        {
            return await _pessoasServices.Add(pessoa);
        }

        /// <summary>
        /// Cadastra uma nova pessoa
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/pessoas")]
        public async Task<ICollection<Pessoa>> Get(string? filter)
        {
            return await _pessoasServices.GetByFilter(filter);
        }

        /// <summary>
        /// Atualiza uma nova pessoa completa
        /// </summary>
        /// <returns></returns>
        [HttpPut("api/pessoas")]
        public async Task<Pessoa> Update([FromBody] Pessoa pessoa)
        {
            return await _pessoasServices.Update(pessoa);
        }

        /// <summary>
        /// Atualiza parcialmente uma pessoa usando JSON Patch
        /// </summary>
        /// <returns></returns>
        [HttpPatch("api/pessoas/JsonPatch/")]
        public async Task<Pessoa> UpdateJsonPatch(string id, [FromBody] JsonPatchDocument<Pessoa> pessoa)
        {
            return await _pessoasServices.UpdateJsonPatch(id, pessoa);
        }

        /// <summary>
        /// Atualiza parcialmente uma pessoa usando o AutoMapper
        /// </summary>
        /// <returns></returns>
        [HttpPatch("api/pessoas/AutoMapper")]
        public async Task<Pessoa> UpdateAutoMapper([FromBody] Pessoa pessoa)
        {
            return await _pessoasServices.UpdateAutoMapper(pessoa);
        }
    }
}
