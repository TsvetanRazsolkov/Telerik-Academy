/* Write a boolean expression that checks for given integer
   if it can be divided (without remainder) by 7 and 5 in the same time.
	Examples:
n	Divided by 7 and 5?
3	false
0	true
5	false
7	false
35	true
140	true      */

console.log(mainSeparator);
console.log('02. Divisible by 7 and 5');
console.log(innerSeparator);

function isDivisible(num) {
	if (num % 7 === 0 && num % 5 === 0) {
		return true;
	}
	else {
		return false;
	}
}

console.log('3 is divisible by 7 and 5 --> ' + isDivisible(3));
console.log('0 is divisible by 7 and 5 --> ' + isDivisible(0));
console.log('5 is divisible by 7 and 5 --> ' + isDivisible(5));
console.log('7 is divisible by 7 and 5 --> ' + isDivisible(7));
console.log('35 is divisible by 7 and 5 --> ' + isDivisible(35));
console.log('140 is divisible by 7 and 5 --> ' + isDivisible(140));