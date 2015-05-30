// Write a script that finds the lexicographically smallest and largest property in document, window and navigator objects.

console.log('=========================================');
console.log('04. Lexicographically smallest and largest property in document, window and navigator objects');
console.log('------------------------');

var largest,
    smallest,
    prop,
    result;

function getSmallestAndLargest(object) {
    largest = '';
    smallest = 'zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz';
    result = '';

    for (prop in object) {
        if (prop < smallest) {
            smallest = prop;
        }
        if (prop > largest) {
            largest = prop;
        }
    }

    result = 'smallest= ' + smallest + ', largest= ' + largest;
    return result;
}

console.log('window --> ' + getSmallestAndLargest(window));
console.log('document --> ' + getSmallestAndLargest(document));
console.log('navigator --> ' + getSmallestAndLargest(navigator));
