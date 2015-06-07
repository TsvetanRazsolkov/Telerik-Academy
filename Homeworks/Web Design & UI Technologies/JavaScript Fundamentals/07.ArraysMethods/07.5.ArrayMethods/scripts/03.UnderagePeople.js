/*Write a function that prints all underaged persons of an array of person
Use Array#filter and Array#forEach
Use only array methods and no regular loops (for, while)
*/

console.log('==================================');
console.log('03. Underage people');
console.log('---------------------');

var arr = [
        {
            firstName: 'Pesho',
            age: 20,
            toString: function () { return this.firstName + ', ' + this.age + ' years old.'; }
        },
        {
            firstName: 'Gencho',
            age: 16,
            toString: function () { return this.firstName + ', ' + this.age + ' years old.'; }
        },
        {
            firstName: 'Mariika',
            age: 21,
            toString: function () { return this.firstName + ', ' + this.age + ' years old.'; }
        },
        {
            firstName: 'Ivancho',
            age: 24,
            toString: function () { return this.firstName + ', ' + this.age + ' years old.'; }
        },
        {
            firstName: 'Pencho',
            age: 15,
            toString: function () { return this.firstName + ', ' + this.age + ' years old.'; }
        }
];

function chaseUnderagedFromTheClub(array) {
    var underaged = array.filter(function (item) {
        return item.age < 18;
    });

    underaged.forEach(function (item) { console.log(item.toString()); });
}

console.log('Array of people:');
arr.forEach(function (item) { console.log(item.toString()); });

console.log('-------------');
console.log('Underaged people: ');

chaseUnderagedFromTheClub(arr);