/*Write a function that formats a string using placeholders.
The function should work with up to 30 placeholders and all types.
Examples:

var str = stringFormat('Hello {0}!', 'Peter'); 
//str = 'Hello Peter!';

var frmt = '{0}, {1}, {0} text {2}';
var str = stringFormat(frmt, 1, 'Pesho', 'Gosho');
//str = '1, Pesho, 1 text Gosho'*/

console.log('==============================');
console.log('11. String format');
console.log('----------------------');

var str,
    frmt;

function stringFormat() {
    var len = arguments.length,
        placeholder,
        result = arguments[0];

    for (i = 1; i < len; i+=1) {
        placeholder = '{' + (i - 1) + '}';
        while (result.indexOf(placeholder) !== -1) {
            result = result.replace(placeholder, arguments[i]);
        }
    }
    return result;
}

str = stringFormat('Hello {0}!', 'Peter');
console.log('str = ' + str);

frmt = '{0}, {1}, {0} text {2}';
str = stringFormat(frmt, 1, 'Pesho', 'Gosho');
console.log('str = ' + str);