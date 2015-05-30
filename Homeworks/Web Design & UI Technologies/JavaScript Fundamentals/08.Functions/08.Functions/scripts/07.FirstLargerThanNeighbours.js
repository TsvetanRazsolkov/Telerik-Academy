/*Write a function that returns the index of the first element in array that is larger than its neighbours or -1,
 if there’s no such element. Use the function from the previous exercise.*/

console.log('===============================');
console.log('07. First larger than neighrbours');
console.log('--------------------');

var arrayWithLarger = [1, 3, 2, 3],
    arrayWithoutLarger = [1, 2, 3, 4];

function indexOfFirstLargerThanNeighbours(arr) {
    var i,
        len = arr.length;

    for (i = 1; i < len - 1; i+=1) {
        if (checkElement(arr, i)) {
            return i;
        }
    }
    return -1;
}

console.log('Array= ' + arrayWithLarger);
console.log('Index of first larger than neighbours= ' + indexOfFirstLargerThanNeighbours(arrayWithLarger));
console.log('--------------------');
console.log('Array= ' + arrayWithoutLarger);
console.log('Index of first larger than neighbours= ' + indexOfFirstLargerThanNeighbours(arrayWithoutLarger));

