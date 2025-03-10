# Identificações

[![.NET 6 WinUI 3 CI](https://github.com/edenalencar/Identificacoes/actions/workflows/dotnet-desktop.yml/badge.svg)](https://github.com/edenalencar/Identificacoes/actions/workflows/dotnet-desktop.yml)

É uma ferramenta para equipes de QA e desenvolvedores que necessitam testar usando documentos de identificação utilizados no Brasil, como CPF, CNPJ e Inscrição Estadual.

![Imagem do aplicativo Identificações](https://user-images.githubusercontent.com/7075481/117592396-b9cfe480-b10e-11eb-9e74-f039b1b5a100.png)

## Recursos

* Geração de CPF válido com dígitos verificadores
* Geração de CNPJ válido, incluindo opções para filiais
* Geração de Inscrição Estadual válida para todas as Unidades Federativas do Brasil
* Opção para formatação dos documentos (com pontos e traços)
* Geração múltipla de documentos (até 100 por vez)
* Suporte a temas claro, escuro ou padrão do sistema

## Especificações Técnicas

* Desenvolvido com .NET 6 e WinUI 3
* Interface moderna seguindo os padrões de design do Windows 11
* Implementação de algoritmos oficiais de validação de documentos
* Suporte para Windows 10/11 (x86, x64, ARM64)

## Algoritmos Implementados

* **CPF**: Implementa o algoritmo oficial com os dois dígitos verificadores
* **CNPJ**: Gera CNPJ válidos com suporte para matrizes e filiais
* **Inscrição Estadual**: Implementa os algoritmos específicos para cada UF:
  * Acre (AC)
  * Alagoas (AL)
  * Amapá (AP)
  * Amazonas (AM)
  * Bahia (BA)
  * Ceará (CE)
  * Distrito Federal (DF)
  * Espírito Santo (ES)
  * Goiás (GO)
  * Maranhão (MA)
  * Mato Grosso (MT)
  * Mato Grosso do Sul (MS)
  * Minas Gerais (MG)
  * Pará (PA)
  * Paraíba (PB)
  * Paraná (PR)
  * Pernambuco (PE)
  * Piauí (PI)
  * Rio de Janeiro (RJ)
  * Rio Grande do Norte (RN)
  * Rio Grande do Sul (RS)
  * Rondônia (RO)
  * Roraima (RR)
  * Santa Catarina (SC)
  * São Paulo (SP)
  * Sergipe (SE)
  * Tocantins (TO)

## Instalação

<a href="https://apps.microsoft.com/detail/9pjr7tbtzkr1?mode=full">
	<img src="https://get.microsoft.com/images/pt-br%20dark.svg" width="200"/>
</a>

## Como Usar

1. Selecione o tipo de documento que deseja gerar (CPF, CNPJ ou IE)
2. No caso de IE, selecione a UF desejada
3. Defina a quantidade de documentos a serem gerados (1-100)
4. Marque a opção "Formatado" se desejar o documento com pontuação
5. Para CNPJ, marque a opção "Filiais" para gerar filiais de uma mesma matriz
6. Clique em "Gerar" para criar os documentos
7. Use o botão "Copiar" para copiar o resultado para a área de transferência

## Desenvolvimento

### Pré-requisitos

* Visual Studio 2022
* .NET 6.0 SDK
* Windows App SDK
* Windows 10 versão 1809 ou superior

### Como Clonar o Repositório

```bash
git clone https://github.com/edenalencar/Identificacoes
```

### Estrutura do Projeto

O projeto segue o padrão MVC:

* **Model**: Classes que representam os dados dos documentos
* **View**: Interfaces WinUI 3 para interação com o usuário
* **Bu**: Implementações dos algoritmos de geração de documentos
* **Util**: Classes utilitárias e constantes

## Licença

Este projeto está licenciado sob a [GNU General Public License v3.0](LICENSE.txt).

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.

## Política de Privacidade

Veja nossa [Política de Privacidade](PRIVACY-POLICY.md) para mais informações sobre como tratamos seus dados.
