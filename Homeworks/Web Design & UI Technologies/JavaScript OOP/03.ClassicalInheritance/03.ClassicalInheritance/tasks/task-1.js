/* Task Description */
/* 
	Create a function constructor for Person. Each Person must have:
	*	properties `firstname`, `lastname` and `age`
		*	firstname and lastname must always be strings between 3 and 20 characters, containing only Latin letters
		*	age must always be a number in the range 0 150
			*	the setter of age can receive a convertible-to-number value
		*	if any of the above is not met, throw Error 		
	*	property `fullname`
		*	the getter returns a string in the format 'FIRST_NAME LAST_NAME'
		*	the setter receives a string is the format 'FIRST_NAME LAST_NAME'
			*	it must parse it and set `firstname` and `lastname`
	*	method `introduce()` that returns a string in the format 'Hello! My name is FULL_NAME and I am AGE-years-old'
	*	all methods and properties must be attached to the prototype of the Person
	*	all methods and property setters must return this, if they are not supposed to return other value
		*	enables method-chaining
*/
function solve() {
    var Person = (function () {
        function Person(fname, lname, age) {
            this.firstname = fname;
            this.lastname = lname;
            this.age = age;
        }

        function validateName(name) {
            if (typeof name !== 'string') {
                throw new Error('Input name is not a string');
            }
            //if (!/^[A-Za-z]{3,20}$/.test(name.trim())) {
            //    throw new Error('Invalid name - characters must be latin letters and length between 3 and 20 symbols');
            //}
            if (name.trim().length < 3 || name.trim().length > 20) {
                throw new Error('Invalid name - must be between 3 and 20 symbols');
            }
            if (!name.trim().split('').some(function (item) {
                    return (item.charCodeAt(0) > 64 && item.charCodeAt(0) < 91) ||
                            (item.charCodeAt(0) > 96 && item.charCodeAt(0) < 123);
            })) {
                throw new Error('Invalid name - characters must be latin letters.');
            }
        }

        function validateAge(age) {
            if (isNaN(parseFloat(age))) {
                throw new Error('Age is not a valid number');
            }

            age = parseFloat(age);
            if (age < 0 || age > 150) {
                throw new Error('Invalid age - must be between 0 and 150');
            }
        }

        Object.defineProperty(Person.prototype, 'firstname', {
            get: function () {
                return this._firstname;
            },
            set: function (value) {
                validateName(value);
                this._firstname = value.trim();
            }
        });

        Object.defineProperty(Person.prototype, 'lastname', {
            get: function () {
                return this._lastname;
            },
            set: function (value) {
                validateName(value);
                this._lastname = value.trim();
            }
        });

        Object.defineProperty(Person.prototype, 'age', {
            get: function () {
                return this._age;
            },
            set: function (value) {
                validateAge(value);
                this._age = parseInt(value);
            }
        });

        Object.defineProperty(Person.prototype, 'fullname', {
            get: function () {
                return this.firstname + ' ' + this.lastname;
            },
            set: function (value) {

                var fullnameAsArray = value.trim().split(' ');

                this.firstname = fullnameAsArray[0];
                this.lastname = fullnameAsArray[1];
            }
        });

        Person.prototype.introduce = function () {
            var result = 'Hello! My name is ' + this.fullname + ' and I am ' + this.age + '-years-old';
            return result;
        };

        return Person;
    }());

    return Person;
}

module.exports = solve;