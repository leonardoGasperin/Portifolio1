# Projeto de Eleição Condominial em C#

Este é um projeto de exemplo em C# que demonstra a implementação dos princípios de arquitetura limpa, conceitos de Clean Code e S.O.L.I.D, juntamente com testes unitários usando NUnit. O projeto visa resolver o exercício proposto na faculdade de criar um algoritmo que determina o candidato vencedor de uma eleição em um condomínio. O algoritmo recebe o nome e o número de votos de três candidatos e exibe o vencedor na tela.

## Requisitos

Certifique-se de que você tem o seguinte software instalado:

- Visual Studio (ou VSCode ou uma IDE C# de sua escolha)
- .Net 8.0
- NUnit (para executar os testes unitários)

## Estrutura do Projeto

O projeto está organizado seguindo uma estrutura de arquitetura limpa, com divisão em camadas:

- **Apresentation**: Responsável por implementar os casos de uso da eleição.
- **Infrastructure**: Lida com a persistência e algoritmos de dados .
- **Infrastructure.Rules**: Contém as regras de negócios da eleição.
- **Domain**: Contém as entidades e regras de domínio relacionadas à eleição.
- **Tests**: Contém testes unitários para garantir o funcionamento correto do código.

## Clean Code e S.O.L.I.D.

- O código segue princípios de nomenclatura descritiva e legível.
- Princípios S.O.L.I.D são aplicados em todo o projeto para manter a coesão e baixo acoplamento.

## Execução do Projeto

Para demonstrar o funcionamento do algoritmo, execute o projeto, através do play da IDE ou utilizando o comando na raiz do projeto `dotnet run` e insira os nomes e números de votos dos candidatos quando solicitado. Após a entrada de dados, o programa exibirá o nome do candidato vencedor na eleição.

## Testes Unitários

O projeto também inclui testes unitários usando o framework NUnit. Os testes estão localizados no projeto **PortifolioTest** e podem ser executados para garantir a qualidade e a corretude do código.

## Exemplo de Uso
```
Nome do 1. candidato: Lucas Lima
Número de votos do 1. candidato: 500
Nome do 2. candidato: Carlos Francisco
Número de votos do 2. candidato: 380
Nome do 3. candidato: Alfredo Santos
Número de votos do 3. candidato: 630

O candidato Alfredo Santos venceu a eleição com 630 votos.
```


Observação: Os nomes e números não são fixos e podem ser personalizados a cada execução do programa.

## Contribuição

Sinta-se à vontade para contribuir, fazer melhorias ou usar este projeto como referência para seus estudos. Se você encontrar algum problema ou tiver sugestões, por favor, crie um "Issue" ou envie um "Pull Request".
