/*Write a script that finds the most frequent number in an array.
Example:
input	                                result
4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3	4 (5 times) */

console.log(mainSeparator);
console.log('06.Most frequent number');
console.log(innerSeparator);

var arr = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3],
    len = arr.length,
    solutionArr = [],// the numbers from the initial array will be kept here as indices, and
                     // the values will be the number of occurences of the specific number.
    i,
    bestFrequency = 0,
    mostFrequentNumber;

for (i = 0; i < len; i+=1) {
    if (solutionArr[arr[i]] !== undefined) { // the number arr[i] has been found already;
        solutionArr[arr[i]] += 1;
        if (solutionArr[arr[i]] > bestFrequency) {
            bestFrequency = solutionArr[arr[i]];
            mostFrequentNumber = arr[i];
        }
    }
    else {
        solutionArr[arr[i]] = 1; // the number arr[i] is found for the first time;
    }
}

console.log('Initial array= [' + arr.join(', ') + ']');
console.log('most frequent number --> ' + mostFrequentNumber + '(' + bestFrequency + ')');