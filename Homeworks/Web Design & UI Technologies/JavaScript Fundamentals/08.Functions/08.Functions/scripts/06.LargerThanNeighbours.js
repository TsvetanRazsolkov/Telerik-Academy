// Write a function that checks if the element at given position in given array of integers
// is bigger than its two neighbours (when such exist).

console.log(mainSeparator);
console.log('06. Larger than neighbours');
console.log(innerSeparator);

var array = [1, 3, 2, 3];

function checkElement(arr, index) {

    if (index < 1 || index >= arr.length - 1) {
        return 0;
    }
    else {
        if (arr[index] > arr[index - 1] && arr[index] > arr[index + 1]) {
            return 1;
        }
        else {
            return 0;
        }
    }
}

console.log('Array= ' + array);
console.log('Element at index 1(3) is bigger than its two neighbours --> ' + (checkElement(array, 1) ? 'Yes' : 'No'));
console.log('Element at index 2(2) is bigger than its two neighbours --> ' + (checkElement(array, 2) ? 'Yes' : 'No'));
console.log('Element at index 0(1) is bigger than its two neighbours --> ' + (checkElement(array, 0) ? 'Yes' : 'No'));
