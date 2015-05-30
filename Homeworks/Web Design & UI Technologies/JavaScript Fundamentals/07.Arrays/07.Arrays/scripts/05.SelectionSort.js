/*Sorting an array means to arrange its elements in increasing order.
Write a script to sort an array.
Use the selection sort algorithm: Find the smallest element, move it at the first position,
find the smallest from the rest, move it at the second position, etc.
Hint: Use a second array  */

console.log('=====================================');
console.log('05.Selection sort');
console.log('-------------------------');

var array = [2, 11, 1, 23, 3, 8, 12, 4, 4, 5],
    sortedArray = [],
    minIndex,
    i;

console.log('Initial array= [' + array + ']');

while (array.length !== 0) {
    minIndex = 0;
    for (i = 0; i < array.length; i += 1) {
        if (array[minIndex] > array[i]) {
            minIndex = i;
        }        
    }
    sortedArray.push(array[minIndex]);
    array.splice(minIndex, 1);
}

array.push(sortedArray);

console.log('Sorted array= [' + array + ']');
