/*Write a function that groups an array of people by age, first or last name.
The function must return an associative array, with keys - the groups, and values - arrays with people in this groups
Use function overloading (i.e. just one function)

Example:

var people = {…};
var groupedByFname = group(people, 'firstname');
var groupedByAge= group(people, 'age');           */

console.log('=================================');
console.log('06. Nameless task');
console.log('-------------------------');

var people = [
  { firstname: 'Pesho', lastname: 'Ivanov', age: 30, toString: function () { return '{' + this.firstname + ' ' + this.lastname + ', ' + this.age + '}'; } },
  { firstname: 'Gosho', lastname: 'Ivanov', age: 30, toString: function () { return '{' + this.firstname + ' ' + this.lastname + ', ' + this.age + '}'; } },
  { firstname: 'Gosho', lastname: 'Ivanov', age: 25, toString: function () { return '{' + this.firstname + ' ' + this.lastname + ', ' + this.age + '}'; } },
  { firstname: 'Pesho', lastname: 'Peshov', age: 30, toString: function () { return '{' + this.firstname + ' ' + this.lastname + ', ' + this.age + '}'; } },
  { firstname: 'Gosho', lastname: 'Peshov', age: 25, toString: function () { return '{' + this.firstname + ' ' + this.lastname + ', ' + this.age + '}'; } }
],
    ind;

console.log('Array: ');
for (ind = 0; ind < people.length; ind += 1) {
    console.log(people[ind].toString());
}

function groupPeople(arr, property) {
    var i,
        len = arr.length,
        result = {};

    switch (property) {
        case 'firstname':
            for (i = 0; i < len; i += 1) {
                if (result[arr[i].firstname]) {
                    result[arr[i].firstname].push(arr[i]);
                } else {
                    result[arr[i].firstname] = [arr[i]];
                }
            }
            return result;
        case 'lastname':
            for (i = 0; i < len; i += 1) {
                if (result[arr[i].lastname]) {
                    result[arr[i].lastname].push(arr[i]);
                } else {
                    result[arr[i].lastname] = [arr[i]];
                }
            }
            return result;
        case 'age':
            for (i = 0; i < len; i += 1) {
                if (result[arr[i].age]) {
                    result[arr[i].age].push(arr[i]);
                } else {
                    result[arr[i].age] = [arr[i]];
                }
            }
            return result;
        default:
            return 'No such property.';
    }    
}

console.log('-------------------------');
console.log('By first name');
console.log(groupPeople(people, 'firstname'));
console.log('By last name');
console.log(groupPeople(people, 'lastname'));
console.log('By age');
console.log(groupPeople(people, 'age'));