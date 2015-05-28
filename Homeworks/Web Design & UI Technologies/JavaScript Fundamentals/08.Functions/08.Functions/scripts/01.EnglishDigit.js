/*Write a function that returns the last digit of given integer as an English word.
Examples:

input	output
512	    two
1024	four
12309	nine   */

var mainSeparator = '===============================',
    innerSeparator = '--------------------';

console.log(mainSeparator);
console.log('01. English digit');
console.log(innerSeparator);

function extractLastDigit(num) {
    var digit = num % 10;
    if (digit < 0) {
        digit *= -1;
    }
    switch (digit) {
        case 1:
            return 'one';
        case 2:
            return 'two';
        case 3:
            return 'three';
        case 4:
            return 'chetiri ;)';
        case 5:
            return 'five';
        case 6:
            return 'six';
        case 7:
            return 'seven';
        case 8:
            return 'eight';
        case 9:
            return 'nine';
        case 0:
            return 'zero';
        default:
            return 'Not a valid integer';
    }
}

console.log('512 --> ' + extractLastDigit(512));
console.log('1024 --> ' + extractLastDigit(1024));
console.log('-12309 --> ' + extractLastDigit(-12309));
console.log('12309.8 --> ' + extractLastDigit(12309.8));
console.log('djagara-djugara --> ' + extractLastDigit('djagara-djugara'));