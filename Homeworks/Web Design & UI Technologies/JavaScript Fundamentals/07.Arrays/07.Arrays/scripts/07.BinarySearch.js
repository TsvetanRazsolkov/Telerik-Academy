//Write a script that finds the index of given element in a sorted array of integers
//by using the binary search algorithm.

console.log(mainSeparator);
console.log('07. Binary search');
console.log(innerSeparator);

var arr = [1, 2, 3, 4, 5, 6, 8, 9, 11, 14, 15],
    srchValRec = 3,
    srchValIt = 0,
    minInd = 0,
    maxInd = arr.length - 1,
    midInd;

function binarySearchRecursive(array, number, min, max) {
    midInd = (min + (max - min) / 2) | 0;

    if (max < min) {
        return -1;
    }
    else {
        if (array[midInd] < number) {
            return binarySearchRecursive(arr, number, midInd + 1, max);
        }
        else if (array[midInd] > number) {
            return binarySearchRecursive(arr, number, min, midInd - 1);
        }
        else {
            return midInd;
        }
    }
}

function binarySearchIterative(array, number, min, max) {
    while (max >= min) {
        midInd = (min + (max - min) / 2) | 0;

        if (array[midInd] === number) {
            return midInd;
        }
        else if (array[midInd] < number) {
            min = midInd + 1;
        }
        else {
            max = midInd - 1;
        }
    }
    return -1;
}

console.log('Array= [' + arr.join(', ') + ']');
console.log('Index of ' + srchValIt + '= ' + binarySearchIterative(arr, srchValIt, minInd, maxInd) + ' -> iterative');
console.log('Index of ' + srchValRec + '= ' + binarySearchRecursive(arr, srchValRec, minInd, maxInd) + ' -> recursive');