//Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

console.log('==============================');
console.log('10. Find palindromes');
console.log('----------------------');

var text = 'ABBA, lamal, exe, cat, dog.',
    textAsArray = text.split(/\s*\W\s*/),
    i,
    len = textAsArray.length,
    palindromesArray = [];

function checkPalindrome(word) {
    var wordLen = word.length,
    j;
    if (wordLen < 2) {
        return false;
    }

    for (j = 0; j < wordLen/2; j += 1) {
        if (word[j] !== word[wordLen - 1 - j]) {
            return false;
        }
    }
    return true;
}

for (i = 0; i < len; i += 1) {
    if (checkPalindrome(textAsArray[i])) {
        palindromesArray.push(textAsArray[i]);
    }
}

console.log(text);
console.log('Palindromes: ');
console.log(palindromesArray);