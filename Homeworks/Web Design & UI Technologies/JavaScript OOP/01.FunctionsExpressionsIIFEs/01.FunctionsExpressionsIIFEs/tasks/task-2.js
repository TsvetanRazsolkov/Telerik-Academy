/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function findPrimes(startOfRange, endOfRange) {

	function validateInput(input) {

		var i,
			len = input.length,
			isBotConvertibleToNumber;
	
		if (input.length !== 2) {
			throw Error;
		}
	
		if (isNaN(input[0]) || isNaN(input[1])) {
				throw Error;        
		}
	}

	function checkIfPrime(number) {
		var divider = 2,
			maxDivider = Math.sqrt(number),
			isPrime = true;
	
		if (number < 2) {
			isPrime = false;
			return isPrime;
		}
	
		while (divider <= maxDivider && isPrime) {
			if (number % divider === 0 || number < 2) {
				isPrime = false;
			}
			divider += 1;
		}
	
		return isPrime;
	}

    var primesArray = [],
        i;

    validateInput(arguments);

    for (i = startOfRange * 1; i <= endOfRange * 1; i += 1) {
        if (checkIfPrime(i)) {
            primesArray.push(i);
        }
    }

    return primesArray;
}

module.exports = findPrimes;