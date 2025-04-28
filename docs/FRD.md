# Documento de Requisitos Funcionais (FRD)

## 1. Introdução

### 1.1 Propósito
Este documento detalha os requisitos funcionais do aplicativo Identificações, descrevendo as funcionalidades esperadas, comportamentos do sistema, e os critérios de aceitação para cada funcionalidade.

### 1.2 Escopo
O documento abrange todas as funcionalidades disponíveis no aplicativo Identificações, incluindo geração de CPF, CNPJ e Inscrição Estadual, bem como configurações da aplicação e interface do usuário.

### 1.3 Definições e Acrônimos
- **CPF**: Cadastro de Pessoas Físicas
- **CNPJ**: Cadastro Nacional da Pessoa Jurídica
- **IE**: Inscrição Estadual
- **UF**: Unidade Federativa
- **UI**: Interface do Usuário

## 2. Requisitos Funcionais Detalhados

### 2.1 Geração de CPF

#### 2.1.1 Gerar CPF Individual
- **Descrição**: O sistema deve gerar um número de CPF válido.
- **Entrada**: Solicitação de geração pelo usuário.
- **Processo**: 
  1. Gerar aleatoriamente os 9 primeiros dígitos
  2. Calcular o primeiro dígito verificador usando o algoritmo específico
  3. Calcular o segundo dígito verificador usando o algoritmo específico
- **Saída**: Um número de CPF válido com 11 dígitos.
- **Critérios de Aceitação**: 
  - O número gerado deve passar na validação matemática de CPF
  - Os dígitos verificadores devem estar corretos

#### 2.1.2 Gerar Múltiplos CPFs
- **Descrição**: O sistema deve gerar múltiplos números de CPF válidos.
- **Entrada**: Quantidade de CPFs a serem gerados (1-100).
- **Processo**: Executa o processo de geração individual repetidamente.
- **Saída**: Lista de CPFs válidos.
- **Critérios de Aceitação**: 
  - Todos os números gerados devem ser válidos
  - A quantidade deve corresponder ao solicitado

#### 2.1.3 Formatar CPF
- **Descrição**: O sistema deve formatar o CPF no padrão brasileiro.
- **Entrada**: Número de CPF válido.
- **Processo**: Inserir pontos e traços na formatação padrão.
- **Saída**: CPF formatado (xxx.xxx.xxx-xx).
- **Critérios de Aceitação**: 
  - Formato deve seguir o padrão xxx.xxx.xxx-xx

#### 2.1.4 Copiar CPFs para Área de Transferência
- **Descrição**: O sistema deve copiar os CPFs gerados para a área de transferência.
- **Entrada**: Lista de CPFs gerados.
- **Processo**: Copia o texto para o clipboard do sistema.
- **Saída**: Confirmação visual de que os dados foram copiados.
- **Critérios de Aceitação**: 
  - O conteúdo copiado deve ser idêntico ao exibido na interface

### 2.2 Geração de CNPJ

#### 2.2.1 Gerar CNPJ Individual
- **Descrição**: O sistema deve gerar um número de CNPJ válido.
- **Entrada**: Solicitação de geração pelo usuário.
- **Processo**: 
  1. Gerar aleatoriamente os 8 primeiros dígitos (raiz)
  2. Adicionar "0001" como identificador de matriz
  3. Calcular os dígitos verificadores usando o algoritmo específico
- **Saída**: Um número de CNPJ válido com 14 dígitos.
- **Critérios de Aceitação**: 
  - O número gerado deve passar na validação matemática de CNPJ
  - Os dígitos verificadores devem estar corretos

#### 2.2.2 Gerar Filiais a partir de uma Matriz
- **Descrição**: O sistema deve gerar CNPJs de filiais baseados em uma matriz.
- **Entrada**: 
  - CNPJ de matriz (gerado pelo sistema)
  - Quantidade de filiais a serem geradas
- **Processo**: 
  1. Manter a raiz do CNPJ da matriz (8 primeiros dígitos)
  2. Alterar o identificador de filial (de 0001 para 0002, 0003, etc.)
  3. Recalcular os dígitos verificadores para cada filial
- **Saída**: Lista de CNPJs válidos para filiais.
- **Critérios de Aceitação**: 
  - Todos os CNPJs devem compartilhar a mesma raiz
  - Os números de filial devem ser incrementais
  - Todos os dígitos verificadores devem estar corretos

#### 2.2.3 Gerar Múltiplos CNPJs
- **Descrição**: O sistema deve gerar múltiplos números de CNPJ válidos.
- **Entrada**: Quantidade de CNPJs a serem gerados (1-100).
- **Processo**: Executa o processo de geração individual repetidamente.
- **Saída**: Lista de CNPJs válidos.
- **Critérios de Aceitação**: 
  - Todos os números gerados devem ser válidos
  - A quantidade deve corresponder ao solicitado

#### 2.2.4 Formatar CNPJ
- **Descrição**: O sistema deve formatar o CNPJ no padrão brasileiro.
- **Entrada**: Número de CNPJ válido.
- **Processo**: Inserir pontos, barra e traço na formatação padrão.
- **Saída**: CNPJ formatado (xx.xxx.xxx/xxxx-xx).
- **Critérios de Aceitação**: 
  - Formato deve seguir o padrão xx.xxx.xxx/xxxx-xx

#### 2.2.5 Copiar CNPJs para Área de Transferência
- **Descrição**: Similar ao 2.1.4, mas para CNPJs.

### 2.3 Geração de Inscrição Estadual

#### 2.3.1 Selecionar Estado (UF)
- **Descrição**: O sistema deve permitir ao usuário selecionar a UF para a qual deseja gerar a IE.
- **Entrada**: Seleção da UF pelo usuário.
- **Processo**: Carregar as regras específicas de geração do estado selecionado.
- **Saída**: Interface preparada para gerar IE do estado selecionado.
- **Critérios de Aceitação**: 
  - Todas as 27 UFs devem estar disponíveis para seleção
  - As regras específicas de cada estado devem ser carregadas corretamente

#### 2.3.2 Gerar IE Individual
- **Descrição**: O sistema deve gerar um número de IE válido para o estado selecionado.
- **Entrada**: 
  - UF selecionada
  - Solicitação de geração
- **Processo**: 
  1. Aplicar regras específicas de geração de IE do estado
  2. Calcular dígitos verificadores conforme regra estadual
- **Saída**: Número de IE válido segundo as regras do estado.
- **Critérios de Aceitação**: 
  - O número deve ser válido conforme algoritmo específico do estado
  - Deve seguir o padrão correto de quantidade de dígitos da UF

#### 2.3.3 Gerar Múltiplas IEs
- **Descrição**: O sistema deve gerar múltiplos números de IE válidos.
- **Entrada**: 
  - UF selecionada
  - Quantidade de IEs a serem geradas (1-100)
- **Processo**: Executa o processo de geração individual repetidamente.
- **Saída**: Lista de IEs válidas para o estado selecionado.
- **Critérios de Aceitação**: 
  - Todos os números gerados devem ser válidos
  - A quantidade deve corresponder ao solicitado

#### 2.3.4 Formatar IE
- **Descrição**: O sistema deve formatar a IE no padrão do estado.
- **Entrada**: 
  - Número de IE válido
  - UF correspondente
- **Processo**: Inserir pontos, traços ou barras conforme padrão do estado.
- **Saída**: IE formatada conforme convenção do estado.
- **Critérios de Aceitação**: 
  - Formato deve seguir o padrão específico do estado

#### 2.3.5 Copiar IEs para Área de Transferência
- **Descrição**: Similar aos itens 2.1.4 e 2.2.5, mas para IEs.

### 2.4 Interface e Navegação

#### 2.4.1 Navegação entre Funcionalidades
- **Descrição**: O sistema deve permitir navegação simples entre as diferentes funcionalidades.
- **Entrada**: Seleção de item no menu de navegação.
- **Processo**: Carregar a página correspondente à seleção.
- **Saída**: Exibição da interface da funcionalidade selecionada.
- **Critérios de Aceitação**: 
  - Navegação deve ocorrer sem erros
  - Estado da página anterior não deve afetar a nova página

#### 2.4.2 Seleção de Temas
- **Descrição**: O sistema deve permitir que o usuário selecione entre os temas disponíveis.
- **Entrada**: Seleção de tema (Claro, Escuro ou Sistema).
- **Processo**: Alterar os estilos visuais da aplicação.
- **Saída**: Interface atualizada com o tema selecionado.
- **Critérios de Aceitação**: 
  - A mudança de tema deve ser imediata
  - O tema deve ser persistido entre sessões

## 3. Fluxos de Processo

### 3.1 Fluxo de Geração de CPF
1. Usuário navega para a página de CPF
2. Usuário define a quantidade desejada
3. Usuário seleciona se deseja formatação
4. Usuário clica no botão "Gerar"
5. Sistema exibe os CPFs gerados
6. Usuário pode copiar os resultados

### 3.2 Fluxo de Geração de CNPJ
1. Usuário navega para a página de CNPJ
2. Usuário define a quantidade desejada
3. Usuário seleciona se deseja formatação
4. Usuário seleciona se deseja gerar filiais
5. Usuário clica no botão "Gerar"
6. Sistema exibe os CNPJs gerados
7. Usuário pode copiar os resultados

### 3.3 Fluxo de Geração de IE
1. Usuário navega para a página de IE
2. Usuário seleciona a UF
3. Usuário define a quantidade desejada
4. Usuário seleciona se deseja formatação
5. Usuário clica no botão "Gerar"
6. Sistema exibe as IEs geradas
7. Usuário pode copiar os resultados

## 4. Requisitos de Interface

### 4.1 Interface de CPF
- Campo para exibição dos resultados
- Controle deslizante para seleção de quantidade
- Caixa de seleção para ativar/desativar formatação
- Botão para gerar os CPFs
- Botão para copiar os resultados

### 4.2 Interface de CNPJ
- Campo para exibição dos resultados
- Controle deslizante para seleção de quantidade
- Caixa de seleção para ativar/desativar formatação
- Caixa de seleção para ativar/desativar geração de filiais
- Botão para gerar os CNPJs
- Botão para copiar os resultados

### 4.3 Interface de IE
- Campo para exibição dos resultados
- Lista suspensa para seleção da UF
- Controle deslizante para seleção de quantidade
- Caixa de seleção para ativar/desativar formatação
- Botão para gerar as IEs
- Botão para copiar os resultados

### 4.4 Interface de Configurações
- Opções de tema (Claro, Escuro, Sistema)
- Informações sobre o aplicativo
- Links para recursos externos (GitHub, suporte)

## 5. Regras de Negócio

### 5.1 Validação de CPF
- Cálculo do primeiro dígito: multiplicar os 9 primeiros dígitos pela sequência decrescente de 10 a 2, somar os resultados, calcular o resto da divisão por 11, e subtrair de 11. Se o resultado for 10 ou 11, o dígito é 0.
- Cálculo do segundo dígito: multiplicar os 10 primeiros dígitos (incluindo o primeiro dígito verificador) pela sequência decrescente de 11 a 2, somar os resultados, calcular o resto da divisão por 11, e subtrair de 11. Se o resultado for 10 ou 11, o dígito é 0.

### 5.2 Validação de CNPJ
- Cálculo do primeiro dígito: multiplicar os 12 primeiros dígitos pela sequência 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2, somar os resultados, calcular o resto da divisão por 11, e subtrair de 11. Se o resultado for 10 ou 11, o dígito é 0.
- Cálculo do segundo dígito: multiplicar os 13 primeiros dígitos (incluindo o primeiro dígito verificador) pela sequência 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2, somar os resultados, calcular o resto da divisão por 11, e subtrair de 11. Se o resultado for 10 ou 11, o dígito é 0.

### 5.3 Validação de IE
- Cada estado possui seu próprio algoritmo de validação
- A implementação deve seguir rigorosamente as regras de cada estado
- O formato e a quantidade de dígitos variam conforme o estado

---

Documento elaborado por: Equipe de Produto  
Última atualização: [Data atual]