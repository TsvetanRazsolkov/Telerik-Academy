/*Write a function that finds the youngest person in a given array of people and prints his/hers full name
Each person has properties firstname, lastname and age.
Example:
var people = [
  { firstname : 'Gosho', lastname: 'Petrov', age: 32 }, 
  { firstname : 'Bay', lastname: 'Ivan', age: 81},… ];   */

console.log('=================================');
console.log('05. Youngest person');
console.log('-------------------------');

var people = [
  { firstname: 'Pesho', lastname: 'Kelesho', age: 32, toString: function () { return '{' + this.firstname + ' ' + this.lastname + ', ' + this.age + '}'; } },
  { firstname: 'Bay', lastname: 'Ivan', age: 81, toString: function () { return '{' + this.firstname + ' ' + this.lastname + ', ' + this.age + '}'; } },
  { firstname: 'Tosho', lastname: 'KashlqLosho', age: 25, toString: function () { return '{' + this.firstname + ' ' + this.lastname + ', ' + this.age + '}'; } },
  { firstname: 'Mladen', lastname: 'Mladenov', age: 18, toString: function () { return '{' + this.firstname + ' ' + this.lastname + ', ' + this.age + '}'; } },
  { firstname: 'Gogo', lastname: 'QdeMnogo', age: 40, toString: function () { return '{' + this.firstname + ' ' + this.lastname + ', ' + this.age + '}'; } },
  { firstname: 'Ruska', lastname: 'ShteTeShruska', age: 30, toString: function () { return '{' + this.firstname + ' ' + this.lastname + ', ' + this.age + '}'; } }
],
    ind;

console.log('Array: ');
for (ind = 0; ind < people.length; ind += 1) {
    console.log(people[ind].toString());
}

function findYoungest(arr) {
    var minAge = arr[0].age,
        i,
        indexOfYoungest = 0,
        len = arr.length;
    for (i = 0; i < len; i += 1) {
        if (arr[i].age < minAge) {
            minAge = arr[i].age;
            indexOfYoungest = i;
        }
    }

    console.log('Youngest person: ' + arr[indexOfYoungest].firstname + ' ' + arr[indexOfYoungest].lastname);
}

findYoungest(people);
