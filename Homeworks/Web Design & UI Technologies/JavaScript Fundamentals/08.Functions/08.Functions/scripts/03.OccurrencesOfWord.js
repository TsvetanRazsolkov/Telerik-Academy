/*Write a function that finds all the occurrences of word in a text.
The search can be case sensitive or case insensitive.
Use function overloading. */

console.log(mainSeparator);
console.log('03. Occurrences of a word');
console.log(innerSeparator);

var text = 'Bla, blablaika, Bla, ..Bla,.bla,.Bla.,?Bla,!.bla bla';

// With regular expression:
function findWordOccurrencesRegEx(text, word, caseSensitive) {
    var pattern = '\\b' + word + '\\b',
        flag = caseSensitive ? 'g' : 'gi',
        re = new RegExp(pattern, flag);

    return text.match(re);
}

// Without regular expression(a bit faster( http://jsperf.com/regex-vs-no-regex ) and a waste of time :) ):
function findWordOccurrencesNoRegEx(text, word, caseSensitive) {
    var punctuation = [',', '.', ';', '!', '?', '-'],
        i,
        splitArr,
        len,
        result = [];

    for (i = 0, len = punctuation.length; i < len; i +=1) {
        splitArr = text.split(punctuation[i]);
        text = splitArr.join(' ');
    }
    splitArr = text.split(' ');

    for (i = 0, len = splitArr.length; i < len; i += 1) {
        if (caseSensitive) {
            if (splitArr[i] === word) {
                result.push(splitArr[i]);
            }
        }
        else {
            if (splitArr[i].toUpperCase() === word.toUpperCase()) {
                result.push(splitArr[i]);
            }
        }
        
    }
    return result;
}

console.log(text);
console.log(innerSeparator);
console.log('With regular expression:');
console.log('Case sensitive search --> ' + findWordOccurrencesRegEx(text, 'bla', true));
console.log('Case insensitive search --> ' + findWordOccurrencesRegEx(text, 'bla', false));
console.log(innerSeparator);
console.log('No regular expression:');
console.log('Case sensitive search --> ' + findWordOccurrencesNoRegEx(text, 'bla', true));
console.log('Case insensitive search --> ' + findWordOccurrencesNoRegEx(text, 'bla', false));
