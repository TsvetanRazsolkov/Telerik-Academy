/*Write a JavaScript function to check if in a given expression the brackets are put correctly.
Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)).*/

console.log('==============================');
console.log('02. Correct brackets');
console.log('----------------------');

function areBracketsCorrect(expression) {
    var bracketCounter = 0,
        i,
        len = expression.length;

    for (i = 0; i < len; i += 1) {
        if (expression[i] === '(') {
            bracketCounter += 1;
        }
        else if (expression[i] === ')') {
            bracketCounter -= 1;
        }
        if (bracketCounter < 0) {
            return false;
        }
    }
    if (bracketCounter === 0) {
        return true;
    }
    else {
        return false;
    }
}

console.log('((a+b)/5-d) --> the brackets are: ' + areBracketsCorrect('((a+b)/5-d)'));
console.log('(((a+b)/5-d) --> the brackets are: ' + areBracketsCorrect('(((a+b)/5-d)'));
console.log(')(a+b)) --> the brackets are: ' + areBracketsCorrect(')(a+b))'));