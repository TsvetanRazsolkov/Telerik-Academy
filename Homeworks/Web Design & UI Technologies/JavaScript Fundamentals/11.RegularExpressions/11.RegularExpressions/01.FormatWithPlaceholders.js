/*Write a function that formats a string. The function should have placeholders, as shown in the example
Add the function to the String.prototype
Example:
input	                                                        |  output
var options = {name: 'John'};                                   | 
'Hello, there! Are you #{name}?'.format(options);	            |'Hello, there! Are you John'
var options = {name: 'John', age: 13};                          |
'My name is #{name} and I am #{age}-years-old'.format(options);|'My name is John and I am 13-years-old'*/

console.log('=================================');
console.log('01. Format with placeholders');
console.log('-------------------');

var str1 = 'Hello, there! Are you #{name}?',
    str2 = 'My name is #{name} and I am #{age}-years-old';

String.prototype.format = function (options) {
    var result = this,
        regExp,
        prop;

    for (prop in options) {
        regExp = new RegExp('#{' + prop + '}', 'g');

        result = result.replace(regExp, options[prop]);
    }

    return result;
};

console.log(str1.format({ name: 'John' }));
console.log(str2.format({ name: 'John', age: 13 }));