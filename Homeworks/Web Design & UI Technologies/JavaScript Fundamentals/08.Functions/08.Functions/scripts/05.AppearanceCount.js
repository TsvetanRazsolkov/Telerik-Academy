// Write a function that counts how many times given number appears in given array.
// Write a test function to check if the function is working correctly.

console.log('===============================');
console.log('05. Appearance count');
console.log('--------------------');

function countAppearances(arr, num) {
    var i,
        result = 0,
        len = arr.length;

    for (i = 0; i < len; i += 1) {
        if (arr[i] === num) {
            result += 1;
        }
    }
    return result;
}

function testFunc() {
    var array = [1, 1, 12, 12, 12, 6, 6, 6],
        testNum1 = 12,
        testNum2 = 6,
        testNum3 = 444,
        expRes1 = 3,
        expRes2 = 3,
        expRes3 = 0;

    console.log('Array: ' + array);
    console.log('Test 1 with number= ' + testNum1 + ', expected 3 --> ' + (countAppearances(array, testNum1) === expRes1));
    console.log('Test 2 with number= ' + testNum2 + ', expected 3 --> ' + (countAppearances(array, testNum2) === expRes2));
    console.log('Test 3 with number= ' + testNum3 + ', expected 0 --> ' + (countAppearances(array, testNum3) === expRes3));
}

testFunc();
