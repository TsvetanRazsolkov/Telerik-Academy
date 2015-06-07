/*Write a function for creating persons.
Each person must have firstname, lastname, age and gender (true is female, false is male)
Generate an array with ten person with different names, ages and genders*/

console.log('==================================');
console.log('01. Make person');
console.log('---------------------');

var people = [1, 2, 3, 4, 5, 6, 7 , 8, 9, 10];

function makePerson(fname, lname, age, gender) {
    return {
        firstname: fname,
        lastname: lname,
        age: age,
        gender: gender,
        toString: function () {
            return 'firstname: ' + this.firstname + '\n\r' +
                   'lastname: ' + this.lastname + '\n\r' +
                   'age: ' + this.age + '\n\r' +
                   'gender: ' + (this.gender ? 'Female' : 'Male');
        }
    };
}

function generatePeople() {
    var fname = 'Name' + ((Math.random()*10) |0),
        lname = 'Family' + ((Math.random()*10) | 0),
        age = (Math.random()*100) | 0,
        gender = Math.random() > 0.5;

    return makePerson(fname, lname, age, gender);
}

var result = people.map(generatePeople);

result.forEach(function (item, index) {
    console.log('Person' + (index + 1) + ': ' + '\n\r' + item.toString() + '\n\r' + '------------------');
});
