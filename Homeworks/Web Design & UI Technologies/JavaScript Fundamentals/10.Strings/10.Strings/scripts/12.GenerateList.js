/*Write a function that creates a HTML <ul> using a template for every HTML <li>.
The source of the list should be an array of elements.
Replace all placeholders marked with –{…}– with the value of the corresponding property of the object.

Example: HTML:
<div data-type="template" id="list-item">
 <strong>-{name}-</strong> <span>-{age}-</span>
/div>
JavaScript:
var people = [{name: 'Peter', age: 14},…];
var tmpl = document.getElementById('list-item').innerHtml;
var peopleList = generateList(people, template);
//peopleList = '<ul><li><strong>Peter</strong> <span>14</span></li><li>…</li>…</ul>'*/

console.log('==============================');
console.log('12. Generate list');
console.log('----------------------');

var people = [{ name: 'Peter', age: 14 },
              { name: 'Pesho', age: 15 },
              { name: 'Bai Pesho', age: 16 }],
             tmpl = document.getElementById('list-item').innerHTML;

console.log('Click the button to generate a list.');

function generateList(people, template) {
    var ul = document.createElement('ul'),
        i,
        len = people.length,
        li;

    for (i = 0; i < len; i += 1) {
        li = document.createElement('li');
        li.innerHTML = template.replace("-{name}-", people[i].name).replace("-{age}-", people[i].age);
        ul.appendChild(li);
    }

    document.body.appendChild(ul);
}

