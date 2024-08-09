using AutoMapper;
using HttpPatchWithAutoMapper.Domain.Pessoas.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace HttpPatchWithAutoMapper.Domain.Pessoas
{
    public class PessoasServices : IPessoasServices
    {
        private static ICollection<Pessoa> pessoas = new List<Pessoa>();

        public Task<Pessoa> Add(Pessoa pessoa)
        {
            if (string.IsNullOrEmpty(pessoa.Id)) pessoa.Id = Guid.NewGuid().ToString();
            pessoas.Add(pessoa);
            return Task.FromResult(pessoa);
        }

        public async Task<ICollection<Pessoa>> GetByFilter(string? filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return pessoas;
            }
            else
            {
                var filteredPessoa = pessoas.Where(p => p.Nome.Contains(filter)).ToList();
                return await Task.FromResult(filteredPessoa);
            }
        }

        public Task<Pessoa> Update(Pessoa pessoa)
        {
            var existingPessoa = pessoas.FirstOrDefault(p => p.Id == pessoa.Id);
            if (existingPessoa == null)
            {
                throw new ArgumentException("Pessoa não encontrada");
            }

            existingPessoa.Nome = pessoa.Nome;

            return Task.FromResult(existingPessoa);
        }

        public Task<Pessoa> UpdateAutoMapper(Pessoa pessoa)
        {
            var existingPessoa = pessoas.FirstOrDefault(p => p.Id == pessoa.Id);
            if (existingPessoa == null)
            {
                throw new ArgumentException("Pessoa não encontrada");
            }

            // Configuração do AutoMapper
            var configAutoMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Pessoa, Pessoa>()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

                cfg.CreateMap<Endereco, Endereco>()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));                
            });

            // Inclui configuração de mapeamento personalizada, para copiar apenas itens não nulos
            var mapper = configAutoMapper.CreateMapper();

            // Faz o merge das informações salvas no repositório, com as propriedades não nulas enviadas pelo usuário da API
            mapper.Map(pessoa, existingPessoa);

            return Task.FromResult(existingPessoa);
        }

        public async Task<Pessoa> UpdateJsonPatch(string id, [FromBody] JsonPatchDocument<Pessoa> pessoa)
        {
            var pessoaSalva = pessoas.FirstOrDefault(p => p.Id == id);
            if (pessoaSalva == null)
            {
                throw new ArgumentException("Pessoa não encontrada");
            }

            try
            {
                // Aqui é o local em que os comandos definidos no objeto 'pessoa' são aplicados, atualizando o objeto 'pessoaSalva'
                pessoa.ApplyTo(pessoaSalva);
                return pessoaSalva;
            }
            catch (JsonPatchException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> Delete(string id)
        {
            var pessoa = pessoas.FirstOrDefault(p => p.Id == id);
            if (pessoa == null)
            {
                return Task.FromResult(false);
            }

            pessoas.Remove(pessoa);
            return Task.FromResult(true);
        }
    }
}
