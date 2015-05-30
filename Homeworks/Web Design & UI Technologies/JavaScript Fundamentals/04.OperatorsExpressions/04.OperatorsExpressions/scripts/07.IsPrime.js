/*Write an expression that checks if given positive integer number n (n ≤ 100) is prime.
Examples:
n	Prime?
1	false
2	true
3	true
4	false
9	false
37	true
97	true
51	false
-3	false
0	false       */

console.log('=========================================================');
console.log('07. Is prime?');
console.log('-----------------------');

function isNumberPrime(num) {
    var isPrime = true,
        maxDivider = Math.sqrt(num),
        divider = 2;

	if (num < 2) {
		isPrime = false;
	}

	while (divider <= maxDivider && isPrime) {
		if (num % divider === 0) {
			isPrime = false;
		}
		divider += 1;
	}

	console.log(num + ' Prime? --> ' + isPrime);
}

isNumberPrime(1);
isNumberPrime(2);
isNumberPrime(3);
isNumberPrime(4);
isNumberPrime(9);
isNumberPrime(37);
isNumberPrime(97);
isNumberPrime(51);
isNumberPrime(-3);
isNumberPrime(0);