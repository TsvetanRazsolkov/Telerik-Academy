/*Write a function that reverses the digits of given decimal number.
Example:

input	output
256	    652
123.45	54.321  */

console.log('===============================');
console.log('02. Reverse number');
console.log('--------------------');

var bla = 15;

function reverseNumber(num) {
    var result = '',
        len,
        i;

    if (isNaN(num)) {
        return 'not a number';
    }
    else {
	    if(num < 0) {
		num *= -1;
		result += '-';
		}
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
console.log('-654.321 --> ' + reverseNumber(-654.321));