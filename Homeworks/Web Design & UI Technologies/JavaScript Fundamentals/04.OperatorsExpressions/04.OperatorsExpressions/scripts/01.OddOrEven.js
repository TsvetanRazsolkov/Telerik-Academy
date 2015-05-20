/* Write an expression that checks if given integer is odd or even.
Examples:
n	Odd?
3	true
2	false
-2	false
-1	true
0	false     */

innerSeparator = '-----------------------'; // global variable for all scripts - wrong, but useful ;)
mainSeparator = '========================================================='; // global variable for all scripts - wrong, but useful ;)

console.log(mainSeparator);
console.log('01. Odd or even ');
console.log(innerSeparator);

function checkIfOdd(num) {
	if (num % 2 !== 0) {
		return true;
	}
	else {
		return false;
	}
}

console.log('3 is Odd --> ' + checkIfOdd(3));
console.log('2 is Odd --> ' + checkIfOdd(2));
console.log('-2 is Odd --> ' + checkIfOdd(-2));
console.log('-1 is Odd --> ' + checkIfOdd(-1));
console.log('0 is Odd --> ' + checkIfOdd(0));