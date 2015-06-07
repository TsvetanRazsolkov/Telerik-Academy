//Write a function that checks if an array of person contains only people of age (with age 18 or greater)
//Use only array methods and no regular loops (for, while)

console.log('==================================');
console.log('02. People of age');
console.log('---------------------');

var arrNotOfAge = [
        {
            firstName: 'Pesho',
            age: 20,
            toString: function () { return this.firstName + ', ' + this.age + ' years old.'; }
        },
        {
            firstName: 'Gosho',
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
],
    arrOfAge = [
        {
            firstName: 'Pesho',
            age: 20,
            toString: function () { return this.firstName + ', ' + this.age + ' years old.'; }
        },
        {
            firstName: 'Gosho',
            age: 25,
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
    ];

function checkPeopleOfAge(array) {
    return array.every(function (item) {
        return item.age >= 18;
    }) ? 'Every person in the array is of age.' : 'Not all people are of age.';
}

console.log('Array of people:');
arrNotOfAge.forEach(function (item) {
    console.log(item.toString());
});

console.log(checkPeopleOfAge(arrNotOfAge));

console.log('------------------');

console.log('Array of people:');
arrOfAge.forEach(function (item) {
    console.log(item.toString());
});

console.log(checkPeopleOfAge(arrOfAge));