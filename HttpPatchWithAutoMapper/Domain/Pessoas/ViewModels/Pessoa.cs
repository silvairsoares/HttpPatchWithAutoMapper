using NJsonSchema.Annotations;

namespace HttpPatchWithAutoMapper.Domain.Pessoas.ViewModels
{
    [JsonSchemaExtensionData("example",
    @"{
        ""nome"": ""Silvair Leite Soares"",
        ""idade"": ""40"",    
        ""endereco"": {
            ""rua"": ""Nome da rua da pessoa"",
            ""complemento"": ""Complemento do endereço""
        }
    }")]
    public class Pessoa
    {
        public string? Id { get; set; }

        public string? Nome { get; set; }

        public int? Idade { get; set; }

        public Endereco? Endereco { get; set; }
    }
}