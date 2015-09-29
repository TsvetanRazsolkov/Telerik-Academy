
## Strategy

Описание 

 Strategy е поведенчески шаблон за дизайн, който позволява да избираме поведението на даден алгоритъм по време на изпълнение.
 
 Strategy дефинира семейство от алгоритми , енкапсулира всеки един от тях и ги прави взаимно заменяеми, обособявайки абстракцията в интерфейс, а конкретните имплементации в класове наследници.
Всяко отделно поведение е дефинирано като интерфейс и отделни класове имплементират тези интерфейси. Това позволява по-добро разграничение между поведение и класовете, които го ползват, възможност за промяна на поведението без "чупене" на използващите го класове, както и добавяне на нова имплементация на съответното поведение без да се налага промяна никъде(Open-close principle).
 
Принципна схема:
![enter image description here](https://sourcemaking.com/files/v2/content/patterns/Strategy_-2x.png)

Пример с конкретна опростена имплементация е предоставен в съпровождащия C# проект с име *Strategy*.
