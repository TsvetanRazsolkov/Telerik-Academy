// Write a script that finds the max and min number from a sequence of numbers.

console.log(mainSeparator);
console.log('03. Min/Max of sequence');
console.log(innerSeparator);

var numbers = [1, 2, 3, 4, 5, 7.5, -0.12],
    max = Number.MIN_SAFE_INTEGER,
    min = Number.MAX_SAFE_INTEGER,
    i,
    len = numbers.length;

for (i = 0; i < len; i += 1) {
    if (numbers[i] >= max) {
        max = numbers[i];
    }
    if (numbers[i] <= min) {
        min = numbers[i];
    }
}

console.log(numbers + ' --> max= ' + max + ', min= ' + min);