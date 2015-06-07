/*You are given a text. Write a function that changes the text in all regions:

<upcase>text</upcase> to uppercase.
<lowcase>text</lowcase> to lowercase
<mixcase>text</mixcase> to mix casing(random)
Example:
We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>.
We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.

The expected result:
We are LiVinG in a YELLOW SUBMARINE. We dOn'T have anything else.

Note: Regions can be nested.*/

console.log('==============================');
console.log('04. Parse tags');
console.log('----------------------');

var text = 'We are <mixcase>living</mixcase> in a <upcase>yellow <lowcase>sub</lowcase>marine</upcase>.We <mixcase>don\'t</mixcase> have <lowcase>anYTHing</lowcase> else.';

function mixCase(letter) {
    var upper = Math.random() > 0.5;
    if (upper) {
        return letter.toUpperCase();
    }
    else {
        return letter.toLowerCase();
    }
}

function lowCase(letter) {
    return letter.toLowerCase();
}

function upCase(letter) {
    return letter.toUpperCase();
}

function changeTextInTags(text) {
    var result = "",
        cases = [],
        currentLetter,
        i,
        j,
        textLen = text.length;

    for (i = 0; i < textLen; i += 1) {
        if (text[i] === '<') {
            i += 1;
            if (text[i] === "/") {
                cases.pop();
                while (text[i] !== '>') {
                    i += 1;
                }
            }
            else if (text[i] === 'm') {
                cases.push(mixCase);
                while (text[i] !== '>') {
                    i += 1;
                }
            }
            else if (text[i] === 'u') {
                cases.push(upCase);
                while (text[i] !== '>') {
                    i += 1;
                }
            }
            else if (text[i] === 'l') {
                cases.push(lowCase);
                while (text[i] !== '>') {
                    i += 1;
                }
            }
            else {
                console.log('Invalid tag name.');
            }
        }
        else {
            if (cases.length === 0) {
                result += text[i];
            }
            else {
                currentLetter = text[i];

                currentLetter = cases[cases.length - 1](currentLetter);

                result += currentLetter;
            }
        }
    }
    return result;
}

console.log('Text with tags: ');
console.log(text);
console.log('Changed text: ');
console.log(changeTextInTags(text));