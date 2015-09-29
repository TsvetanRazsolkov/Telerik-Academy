
## Proxy

Описание

Proxy е структурен шаблон за дизайн (structural design pattern). Този шаблон представлява междинен клас, който ни дава възможност да комуникираме с основния. Има различни приложения спрямо това кой вид Proxy ползваме - Remote, Virtual, Protection.

 - Remote Proxy - служи за обработване на данни при прехвърляне(кодира, прави статистика, логва информация).
 - Virtual Proxy - служи за достъпване на допълнителна информация при евентуална нужда от нея и кеширането и.
 - Protection Proxy - служи за добавяне на валидации и както за достъпване на ресурс, ако клиента е оторизиран.

Някои от често срещаните примери за употреба на прокси шаблона:

- Добавяне на секюрити достъп към съществуващ обект. Прокси обектът ще прецени дали клиентът да достъпи реалния обект.
- Осигуряване на интерфейс за отдалечени ресурси, като web service.
- Координиране на скъпи операции върху отдалечени ресурси.
- Добавяне на thread-safe feature към съществуващ клас без промяна на кода му.

Принципна схема:
![enter image description here](http://www.devlake.com/design-patterns/proxy/proxy1.PNG)

Пример с конкретна опростена имплементация е предоставен в съпровождащия C# проект с име *Proxy*.
