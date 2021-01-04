# Linguagens de Programação  
## Projeto 2  

---  

## Título do projeto  
Wolf and Sheep

## Autoria  
André Figueira - 21901435
Hugo Carvalho - 21901624
João Matos - 21901219

1. **First Commit** - Hugo Carvalho    
    - Primeiro commit, início do projeto.  
2. **UI, Board, initial positions added** - Hugo Carvalho  
    - Design da interface, tabuleiro de jogo e posições iniciais adicionados. 
4. **Board and Wolf Movement** - André Figueira  
    - Movimento do Lobo e melhoria do tabuleiro de jogo.
5. **Input Thread and GameLoop** - João Matos  
    - Uso de diversas threads adicionado, de modo a correr métodos em paralelo. Gameloop adicionado.  
6. **UI update, game animation added** - Hugo Carvalho  
    - Atualização do tabuleiro de jogo, incluíndo animação.  
7. **XML Documentation added, Fixes** - João Matos  
    - Adicionados comentários em falta, pequenos bugfixes.
8. **Warnings fixed UI polish** - André Figueira  
    - Resolução de restantes avisos, melhoria na interface do jogo.

## Arquitetura da solução  

Na nossa solução utilizámos o *Single Responsibility Principle* e o *Facade Design Pattern* sendo que o utilizador apenas interage com uma classe, sendo essa classe responsável por interagir com as restantes, simplificando assim o uso do programa para o utilizador, escondendo complexidades.  

A nossa solução consiste numa classe `Board` que contém o tabuleiro de jogo, sendo este um array bidimensional de caracteres (`char[,]`), que por sua vez são manipulados através de uma enumeração `Pieces` que contém caracteres como valor.  
Temos depois uma classe `UserInterface` que é responsável pelas impressões na consola e a leitura de caracteres inseridos na mesma.  
Por fim temos a classe `GameLoop` que contém uma instância de `Board` e `UserInterface` e conseguindo assim imprimir na consola usando a classe `UserInterface`, e ler dados inseridos pelo jogador, que depois serão processados e sendo válidos, usados pela instância de `Board` para mover as peças e passar assim o turno.  
Dada a vitória é impressa a mensagem do vencedor e termina o programa.

### UML  
![UML](UML.png)

### Fluxograma  
![Fluxogram](Fluxogram.png)

## Referências  
- StackOverflow  
- Microsoft .NET API