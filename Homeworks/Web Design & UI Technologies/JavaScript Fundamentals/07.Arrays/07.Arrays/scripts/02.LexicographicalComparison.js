// Write a script that compares two char arrays lexicographically (letter by letter).

console.log('=====================================');
console.log('02.Lexicographically comparison');
console.log('-------------------------');

var i,
    shorterLength,
    result;

function compareArrays(firstArr, secondArr) {
    shorterLength = Math.min(firstArr.length, secondArr.length);
    result = 'first array= [' + firstArr.join(', ') +
             '], second array= [' + secondArr.join(', ') + '] ';

    for (i = 0; i < shorterLength; i += 1) {
        if (firstArr[i] < secondArr[i]) {
            result += '--> first array comes before the second lexicographically.';
            return result;
        }
        if (firstArr[i] > secondArr[i]) {
            result += '--> second array comes before the first lexicographically.';
            return result;
        }
    }

    if (firstArr.length === secondArr.length) {
        result += '--> the two arrays are lexicographically equal.';
        return result;
    }

    else if (firstArr.length > secondArr.length) {
        result += '--> second array comes before the first lexicographically.';
        return result;
    }
    else {
        result += '--> first array comes before the second lexicographically.';
        return result;
    }
}

console.log(compareArrays(['a', 'b', 'c'], ['a', 'b', 'c']));
console.log('-------------------------');
console.log(compareArrays(['u', 'f', 'h'], ['u', 'f', 'h', 'c']));
console.log('-------------------------');
console.log(compareArrays(['b', 'l', 'a'], ['a', 'l', 'b']));

