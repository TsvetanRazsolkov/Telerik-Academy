/*Write a function that finds the youngest male person in a given array of people and prints his full name
Use only array methods and no regular loops (for, while)
Use Array#find*/

console.log('==================================');
console.log('05. Youngest person');
console.log('---------------------');

var arr = [
        {
            firstName: 'Pesho',
            lastName: 'Peshov',
            age: 20,
            gender: 'Male',
            toString: function () { return this.firstName + ' ' + this.lastName + ', ' + this.age + ' years old, ' + this.gender; }
        },
        {
            firstName: 'Ivancho',
            lastName: 'Ivanov',
            age: 24,
            gender: 'Male',
            toString: function () { return this.firstName + ' ' + this.lastName + ', ' + this.age + ' years old, ' + this.gender; }
        },
        {
            firstName: 'Mladen',
            lastName: 'Mladenov',
            age: 18,
            gender: 'Male',
            toString: function () { return this.firstName + ' ' + this.lastName + ', ' + this.age + ' years old, ' + this.gender; }
        },
        {
            firstName: 'Mariika',
            lastName: 'Marieva',
            age: 17,
            gender: 'Female',
            toString: function () { return this.firstName + ' ' + this.lastName + ', ' + this.age + ' years old, ' + this.gender; }
        },
        {
            firstName: 'Penka',
            lastName: 'Penkova',
            age: 22,
            gender: 'Female',
            toString: function () { return this.firstName + ' ' + this.lastName + ', ' + this.age + ' years old, ' + this.gender; }
        }
];

function findYoungest(array) {
    var result;

    if (!Array.prototype.find) {
        Array.prototype.find = function (callback) {
            var i, len = this.length;
            for (i = 0; i < len; i += 1) {
                if (callback(this[i], i, this)) {
                    return this[i];
                }
            }
        };
    }

    result = array.sort(function (x, y) { return x.age - y.age; })
                  .find(function (item) { return item.gender === 'Male'; });

    console.log(result.toString());
}

console.log('Array of people:');
arr.forEach(function (item) { console.log(item.toString()); });

console.log('--------------');
findYoungest(arr);
