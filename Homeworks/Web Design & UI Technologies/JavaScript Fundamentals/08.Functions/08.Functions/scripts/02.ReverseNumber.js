/*Write a function that reverses the digits of given decimal number.
Example:

input	output
256	    652
123.45	54.321  */

console.log(mainSeparator);
console.log('02. Reverse number');
console.log(innerSeparator);

var bla = 15;

function reverseNumber(num) {
    var result = '',
        len,
        i;

    if (isNaN(num)) {
        return 'not a number';
    }
    else {
        num = num.toString();
        len = num.length;
        for (i = len - 1; i >= 0; i -= 1) {
            result += num[i];
        }
        return result;
    }
}

console.log('256 --> ' + reverseNumber(256));
console.log('123.45 --> ' + reverseNumber(123.45));