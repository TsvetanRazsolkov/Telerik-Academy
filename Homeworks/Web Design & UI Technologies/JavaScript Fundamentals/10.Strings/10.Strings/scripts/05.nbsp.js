//Write a function that replaces non breaking white-spaces in a text with &nbsp;

console.log('==============================');
console.log('05. nbsp');
console.log('----------------------');

var textToReplace = '1SPACE 2SPACES  3SPACES   1SPACE END',
    target = ' ',
    replacement = '&nbsp;',
    newText;

function replaceAll(text,target, replacement) {
    while (text.indexOf(target) !== -1) {
        text = text.replace(target, replacement);
    }

    return text;
}

console.log(textToReplace);
newText = replaceAll(textToReplace, target, replacement);
console.log(newText);