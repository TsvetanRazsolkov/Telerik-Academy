/*Write a script that finds the maximal increasing sequence in an array.
Example:
input	                result
3, 2, 3, 4, 2, 2, 4	    2, 3, 4 */

console.log(mainSeparator);
console.log('04.Maximal increasing sequence');
console.log(innerSeparator);

var arr = [3, 2, 3, 4, 2, 2, 4],
    i,
    len = arr.length,
    start = arr[0],
    bestStartIndex = 0,
    bestLength = 1,
    currentLength,
    result;

for (i = 1; i < len; i += 1) {
    if ((arr[i] - arr[i-1]) === 1) {
        currentLength += 1;
    }
    else if ((arr[i] - arr[i - 1]) !== 1) {
        currentLength = 1;
    }
    if (currentLength > bestLength) {
        bestLength = currentLength;
        bestStartIndex = i - bestLength + 1;
    }
}

result = arr.slice(bestStartIndex, bestStartIndex + bestLength);
console.log('array= [' + arr.join(', ') + ']');
console.log('max increasing sequence= ' + result.join(', '));