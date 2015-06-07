/*Write a function that calculates the average age of all females, extracted from an array of persons
Use Array#filter
Use only array methods and no regular loops (for, while)*/

console.log('==================================');
console.log('04. Average age of females');
console.log('---------------------');

var arr = [
        {
            firstName: 'Pesho',
            age: 20,
            gender: 'Male',
            toString: function () { return this.firstName + ', ' + this.age + ' years old, ' + this.gender; }
        },
        {
            firstName: 'Ivancho',
            age: 24,
            gender: 'Male',
            toString: function () { return this.firstName + ', ' + this.age + ' years old, ' + this.gender; }
        },
        {
            firstName: 'Genka',
            age: 18,
            gender: 'Female',
            toString: function () { return this.firstName + ', ' + this.age + ' years old, ' + this.gender; }
        },
        {
            firstName: 'Mariika',
            age: 20,
            gender: 'Female',
            toString: function () { return this.firstName + ', ' + this.age + ' years old, ' + this.gender; }
        },
        {
            firstName: 'Penka',
            age: 22,
            gender: 'Female',
            toString: function () { return this.firstName + ', ' + this.age + ' years old, ' + this.gender; }
        }
];

function calculateAverageFemaleAge(array) {
    var averageAge,
    females = array.filter(function (item) { return item.gender === 'Female'; });

    averageAge = (females.reduce(function (sum, item) {
        return sum + item.age;
    }, 0)) / females.length;

    return averageAge;
}

console.log('Array of people:');
arr.forEach(function (item) { console.log(item.toString()); });

console.log('--------------');
console.log('Average age of all females = ' + calculateAverageFemaleAge(arr));