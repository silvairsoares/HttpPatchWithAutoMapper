Projeto de exemplo para o artigo:

[**Criando métodos HTTP PATCH, usando o AutoMappe**r](https://dev.to/silvairsoares/criando-metodos-http-patch-usando-o-automapper-168g "Criando métodos HTTP PATCH, usando o AutoMapper")

```mermaid
sequenceDiagram
    Cliente->>Controller: PATCH /api/pessoas/AutoMapper/{id}
    Controller->>Servico: UpdateAutoMapper(pessoa)
    Note right of Servico: Configura AutoMapper para mapeamento condicional
    Servico->>Banco: BuscarPessoaPorId(id)
    Banco-->>Servico: pessoaExistente
    Note right of Servico: Aplica mapeamento somente para propriedades não nulas
    Servico->>Banco: SalvarAlteracoes()
    Banco-->>Servico: Sucesso
    Servico-->>Controller: pessoaAtualizada
    Controller-->>Cliente: 200 OK + pessoaAtualizada
```
