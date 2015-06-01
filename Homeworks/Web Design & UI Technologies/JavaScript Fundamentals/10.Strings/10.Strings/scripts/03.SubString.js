/*Write a JavaScript function that finds how many times a substring is contained in a given text
(perform case insensitive search).
Example:
The target sub-string is in

The text is as follows: We are living in an yellow submarine. We don't have anything else.
inside the submarine is very tight. So we are drinking all the day.
We will move out of it in 5 days.

The result is: 9*/

console.log('==============================');
console.log('03. Sub-string in text');
console.log('----------------------');

var text = 'We are living in an yellow submarine. We don\'t have anything else.inside the submarine is very tight. So we are drinking all the day.We will move out of it in 5 days.',
    target = 'in';

function countSubStrOccurrences(text, target) {
    var count = 0,
        position = 0,
        indexOfTarget,
        len = target.length;

    while (true) {
        indexOfTarget = text.toUpperCase().indexOf(target.toUpperCase(), position);

        if ( indexOfTarget !== -1) {
            count += 1;
            position = indexOfTarget + len;
        }
        else {
            break;
        }
    }
    return count;
}

console.log('Occurrences of the substring "' + target + '" in the searched text: ' + countSubStrOccurrences(text, target) + ' times');