// Write a function that groups an array of persons by first letter of
// first name and returns the groups as a JavaScript Object
// Use Array#reduce
// Use only array methods and no regular loops (for, while)
// Example:   
//     result = {
//         'a': [{
//             firstname: 'Asen',
//             /* ... */
//          }, {
//             firstname: 'Anakonda',
//             /* ... */
//          }],
//         'j': [{
//             firstname: 'John',
//             /* ... */
//         }]
//      };

console.log('==================================');
console.log('06. Group people');
console.log('---------------------');

var arr = [
        {
            firstName: 'Pesho',
            lastName: 'Peshov',
            age: 20,
            gender: 'Male'
        },
        {
            firstName: 'Ivancho',
            lastName: 'Ivanov',
            age: 24,
            gender: 'Male'
        },
        {
            firstName: 'Mladen',
            lastName: 'Mladenov',
            age: 18,
            gender: 'Male'
        },
        {
            firstName: 'Mariika',
            lastName: 'Marieva',
            age: 17,
            gender: 'Female'
        },
        {
            firstName: 'Penka',
            lastName: 'Penkova',
            age: 22,
            gender: 'Female'
        }
],
    result = {};

function groupByFirstName(arr) {
    var groups = arr.reduce(function (tempResult, currentPerson) {
        var propName = currentPerson.firstName[0].toLowerCase();

        if (!tempResult[propName]) {
            tempResult[propName] = [currentPerson];
        }
        else {
            tempResult[propName].push(currentPerson);
        }

        return tempResult;

    }, {});

    return groups;
}

arr.sort(function (x, y) { return x.firstName < y.firstName ? -1 : 1; });

result = groupByFirstName(arr);

console.log('JSON object with people grouped by the first letter of their names:');
console.log(result);