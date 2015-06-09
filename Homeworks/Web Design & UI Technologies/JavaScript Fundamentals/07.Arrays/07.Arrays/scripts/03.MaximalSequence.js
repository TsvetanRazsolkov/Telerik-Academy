/* Write a script that finds the maximal sequence of equal elements in an array.
Example:
    input	                    result
2, 1, 1, 2, 3, 3, 2, 2, 2, 1	2, 2, 2  */

console.log('=====================================');
console.log('03.Maximal sequence');
console.log('-------------------------');

var arr = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1],
    i,
    len = arr.length,
    start = arr[0],
    bestStartIndex = 0,
    bestLength = 1,
    currentLength = 0,
    result;

for (i = 0; i < len; i += 1) {
    if (arr[i] === start) {
        currentLength += 1;
    }
    else if (arr[i] !== start) {
        currentLength = 1;
        start = arr[i];
    }
    if (currentLength > bestLength) {
        bestLength = currentLength;
        bestStartIndex = i - bestLength + 1;
    }
}

result = arr.slice(bestStartIndex, bestStartIndex + bestLength);
console.log('array= [' + arr.join(', ') + ']');
console.log('max sequence= ' + result.join(', '));
