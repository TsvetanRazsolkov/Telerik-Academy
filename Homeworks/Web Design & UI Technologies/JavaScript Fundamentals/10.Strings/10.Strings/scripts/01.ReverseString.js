/*Write a JavaScript function that reverses a string and returns it.
Example:

input	output
sample	elpmas  */

console.log('==============================');
console.log('01. Reverse string');
console.log('----------------------');

function reverseString(inputStr) {
    var len = inputStr.length,
        reversedStr = '',
        i;
    for (i = len - 1; i >= 0; i -= 1) {
        reversedStr += inputStr[i];
    }
    return reversedStr;
}

console.log('sample --> ' + reverseString('sample'));