/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/

function sum(arrayOfNumbers) {
    var resultSum = 0,
        i;

    if (!Array.isArray(arrayOfNumbers) || arrayOfNumbers === undefined) {
        throw Error;
    }
    else if (arrayOfNumbers.length === 0) {
        return null;
    }
    else {
        for (i = 0; i < arrayOfNumbers.length; i += 1) {
            if (isNaN(Number(arrayOfNumbers[i]))) {
                throw Error;
            }
            resultSum += Number(arrayOfNumbers[i]);
        }
    }

    return resultSum;
}

module.exports = sum;