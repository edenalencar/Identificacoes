# User Stories e Epics

## Epics

### Epic 1: Geração de CPF
Como usuário, quero gerar números de CPF válidos para usar em meus testes de software, garantindo que as aplicações que desenvolvemos tratem corretamente este tipo de documento.

### Epic 2: Geração de CNPJ
Como usuário, quero gerar números de CNPJ válidos, incluindo matrizes e filiais, para testar sistemas que processam dados de pessoas jurídicas.

### Epic 3: Geração de Inscrição Estadual
Como usuário, quero gerar números de Inscrição Estadual válidos para todas as UFs brasileiras, para testar sistemas que processam dados fiscais regionais.

### Epic 4: Interface do Usuário e Experiência
Como usuário, quero uma interface intuitiva, moderna e responsiva que facilite a geração e cópia dos documentos de identificação.

### Epic 5: Configurações e Personalização
Como usuário, quero personalizar a aparência e o comportamento do aplicativo conforme minhas preferências.

## User Stories

### Epic 1: Geração de CPF

#### US01: Geração Básica de CPF
**Como** testador de software,  
**Quero** gerar um número de CPF válido,  
**Para** usar em testes de formulários que exigem CPF.

**Critérios de Aceitação:**
- O CPF gerado deve passar em algoritmos de validação padrão
- Os dígitos verificadores devem ser calculados corretamente
- O resultado deve ser exibido claramente na interface

#### US02: Geração em Massa de CPF
**Como** testador de software,  
**Quero** gerar múltiplos CPFs de uma só vez,  
**Para** criar grandes conjuntos de dados de teste.

**Critérios de Aceitação:**
- Deve ser possível especificar a quantidade (até 100) de CPFs a serem gerados
- Todos os CPFs gerados devem ser válidos
- Os resultados devem ser apresentados em uma lista organizada

#### US03: Formatação de CPF
**Como** testador de software,  
**Quero** alternar entre CPFs formatados e não formatados,  
**Para** adequar ao formato exigido pelo sistema que estou testando.

**Critérios de Aceitação:**
- Deve haver uma opção simples para alternar a formatação
- O formato padrão deve ser xxx.xxx.xxx-xx quando ativado
- A configuração deve ser aplicada a todos os CPFs gerados

#### US04: Cópia de CPF para Área de Transferência
**Como** testador de software,  
**Quero** copiar os CPFs gerados para a área de transferência,  
**Para** colá-los facilmente em outras aplicações.

**Critérios de Aceitação:**
- Deve haver um botão claro para copiar os resultados
- Todos os CPFs gerados devem ser copiados de uma vez
- Deve haver uma indicação visual de que a cópia foi bem-sucedida

### Epic 2: Geração de CNPJ

#### US05: Geração Básica de CNPJ
**Como** desenvolvedor,  
**Quero** gerar um número de CNPJ válido,  
**Para** testar funcionalidades que processam dados de empresas.

**Critérios de Aceitação:**
- O CNPJ gerado deve passar em algoritmos de validação padrão
- Os dígitos verificadores devem ser calculados corretamente
- O resultado deve ser exibido claramente na interface

#### US06: Geração de Filiais
**Como** analista de QA,  
**Quero** gerar CNPJs de filiais a partir de uma matriz,  
**Para** testar sistemas que gerenciam empresas com múltiplas unidades.

**Critérios de Aceitação:**
- Deve haver uma opção para gerar filiais
- As filiais devem compartilhar a mesma raiz com a matriz
- Os números de filial devem ser sequenciais (0001, 0002, etc.)
- Os dígitos verificadores devem ser recalculados para cada filial

#### US07: Geração em Massa de CNPJ
**Como** testador de software,  
**Quero** gerar múltiplos CNPJs de uma só vez,  
**Para** criar conjuntos de dados para testes em lote.

**Critérios de Aceitação:**
- Deve ser possível especificar a quantidade (até 100) de CNPJs a serem gerados
- Todos os CNPJs gerados devem ser válidos
- Os resultados devem ser apresentados em uma lista organizada

#### US08: Formatação de CNPJ
**Como** testador de software,  
**Quero** alternar entre CNPJs formatados e não formatados,  
**Para** adequar ao formato exigido pelo sistema que estou testando.

**Critérios de Aceitação:**
- Deve haver uma opção simples para alternar a formatação
- O formato padrão deve ser xx.xxx.xxx/xxxx-xx quando ativado
- A configuração deve ser aplicada a todos os CNPJs gerados

#### US09: Cópia de CNPJ para Área de Transferência
**Como** testador de software,  
**Quero** copiar os CNPJs gerados para a área de transferência,  
**Para** colá-los facilmente em outras aplicações.

**Critérios de Aceitação:**
- Similar aos critérios da US04, mas para CNPJs

### Epic 3: Geração de Inscrição Estadual

#### US10: Seleção de Estado
**Como** testador de sistemas fiscais,  
**Quero** selecionar uma UF específica,  
**Para** gerar uma Inscrição Estadual válida para esse estado.

**Critérios de Aceitação:**
- Todas as 27 UFs brasileiras devem estar disponíveis para seleção
- A seleção deve ser intuitiva, possivelmente através de uma lista suspensa
- A seleção da UF deve automaticamente aplicar as regras de geração específicas daquele estado

#### US11: Geração Básica de IE
**Como** desenvolvedor de sistemas fiscais,  
**Quero** gerar um número de IE válido para um estado específico,  
**Para** testar a validação de documentos fiscais.

**Critérios de Aceitação:**
- A IE gerada deve seguir as regras específicas do estado selecionado
- Os dígitos verificadores devem ser calculados corretamente conforme o algoritmo do estado
- O resultado deve ser exibido claramente na interface

#### US12: Geração em Massa de IE
**Como** testador de software,  
**Quero** gerar múltiplas IEs de um estado específico,  
**Para** criar conjuntos de dados para testes fiscais.

**Critérios de Aceitação:**
- Deve ser possível especificar a quantidade (até 100) de IEs a serem geradas
- Todas as IEs geradas devem ser válidas para o estado selecionado
- Os resultados devem ser apresentados em uma lista organizada

#### US13: Formatação de IE
**Como** testador de software,  
**Quero** alternar entre IEs formatadas e não formatadas,  
**Para** adequar ao formato exigido pelo sistema que estou testando.

**Critérios de Aceitação:**
- Deve haver uma opção simples para alternar a formatação
- O formato deve seguir o padrão específico do estado selecionado quando ativado
- A configuração deve ser aplicada a todas as IEs geradas

#### US14: Cópia de IE para Área de Transferência
**Como** testador de software,  
**Quero** copiar as IEs geradas para a área de transferência,  
**Para** colá-las facilmente em outras aplicações.

**Critérios de Aceitação:**
- Similar aos critérios da US04, mas para IEs

### Epic 4: Interface do Usuário e Experiência

#### US15: Navegação entre Funcionalidades
**Como** usuário do aplicativo,  
**Quero** navegar facilmente entre diferentes tipos de documentos,  
**Para** acessar rapidamente a funcionalidade desejada.

**Critérios de Aceitação:**
- Deve haver um menu de navegação claro e intuitivo
- A navegação não deve perder o estado da aplicação
- A barra de navegação deve indicar claramente a página atual

#### US16: Interface Responsiva
**Como** usuário,  
**Quero** usar o aplicativo em diferentes tamanhos de janela,  
**Para** adaptá-lo ao meu ambiente de trabalho.

**Critérios de Aceitação:**
- A interface deve se ajustar adequadamente a diferentes tamanhos de janela
- Os controles devem permanecer acessíveis em todas as dimensões
- Nenhum conteúdo importante deve ficar inacessível ao redimensionar

#### US17: Feedback Visual
**Como** usuário,  
**Quero** receber feedback visual claro sobre minhas ações,  
**Para** saber que o aplicativo está respondendo corretamente.

**Critérios de Aceitação:**
- Botões devem ter estados visuais (hover, pressed, disabled)
- Ações como cópia para a área de transferência devem ter confirmação visual
- Erros (se ocorrerem) devem ser claramente comunicados

### Epic 5: Configurações e Personalização

#### US18: Seleção de Tema
**Como** usuário,  
**Quero** escolher entre temas claro, escuro ou do sistema,  
**Para** adequar o aplicativo às minhas preferências visuais.

**Critérios de Aceitação:**
- Deve haver uma página de configurações com opções de tema
- A mudança de tema deve ser aplicada imediatamente
- A preferência de tema deve ser salva e restaurada entre sessões

#### US19: Informações do Aplicativo
**Como** usuário,  
**Quero** ver informações sobre o aplicativo, como versão e autor,  
**Para** saber mais sobre a ferramenta que estou usando.

**Critérios de Aceitação:**
- Deve haver uma seção "Sobre" nas configurações
- As informações devem incluir versão, autor e propósito do aplicativo
- Deve haver links para recursos externos, como GitHub ou documentação

## Mapa das User Stories

```
├── Epic 1: Geração de CPF
│   ├── US01: Geração Básica de CPF
│   ├── US02: Geração em Massa de CPF
│   ├── US03: Formatação de CPF
│   └── US04: Cópia de CPF para Área de Transferência
│
├── Epic 2: Geração de CNPJ
│   ├── US05: Geração Básica de CNPJ
│   ├── US06: Geração de Filiais
│   ├── US07: Geração em Massa de CNPJ
│   ├── US08: Formatação de CNPJ
│   └── US09: Cópia de CNPJ para Área de Transferência
│
├── Epic 3: Geração de Inscrição Estadual
│   ├── US10: Seleção de Estado
│   ├── US11: Geração Básica de IE
│   ├── US12: Geração em Massa de IE
│   ├── US13: Formatação de IE
│   └── US14: Cópia de IE para Área de Transferência
│
├── Epic 4: Interface do Usuário e Experiência
│   ├── US15: Navegação entre Funcionalidades
│   ├── US16: Interface Responsiva
│   └── US17: Feedback Visual
│
└── Epic 5: Configurações e Personalização
    ├── US18: Seleção de Tema
    └── US19: Informações do Aplicativo
```

## Priorização

### Prioridade Alta (MVP - Minimum Viable Product)
- US01, US05, US11: Geração básica dos documentos
- US03, US08, US13: Formatação dos documentos
- US04, US09, US14: Cópia para área de transferência
- US15: Navegação entre funcionalidades

### Prioridade Média
- US02, US07, US12: Geração em massa
- US10: Seleção de estado para IE
- US16: Interface responsiva
- US17: Feedback visual

### Prioridade Baixa
- US06: Geração de filiais CNPJ
- US18: Seleção de tema
- US19: Informações do aplicativo

---

Documento elaborado por: Equipe de Produto  
Última atualização: [Data atual]