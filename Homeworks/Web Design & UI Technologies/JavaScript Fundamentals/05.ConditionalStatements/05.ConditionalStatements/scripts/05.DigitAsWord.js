/*Write a script that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English).
Print “not a digit” in case of invalid input.
Use a switch statement.
Examples:
digit	result
2	    two
1	    one
0	    zero
5	    five
-0.1    not a digit
hi	    not a digit
9	    nine
10	    not a digit  */

console.log(mainSeparator);
console.log('05.Digit as word');
console.log(innerSeparator);

var input;

function printDigitAsWord(input) {
    var digitAsNumber = input * 1;
    switch (digitAsNumber) {
        case 0:
            console.log('input= ' + input + ', result= zero');
            break;
        case 1:
            console.log('input= ' + input + ', result= one');
            break;
        case 2:
            console.log('input= ' + input + ', result= two');
            break;
        case 3:
            console.log('input= ' + input + ', result= three');
            break;
        case 4:
            console.log('input= ' + input + ', result= four');
            break;
        case 5:
            console.log('input= ' + input + ', result= five');
            break;
        case 6:
            console.log('input= ' + input + ', result= six');
            break;
        case 7:
            console.log('input= ' + input + ', result= seven');
            break;
        case 8:
            console.log('input= ' + input + ', result= eight');
            break;
        case 9:
            console.log('input= ' + input + ', result= nine');
            break;
        default:
            console.log('input= ' + input + ', result= not a digit');
            break;
    }
}

while (input !== 'stop') {
    input = prompt('Task 5: Digit as word - Enter a digit: / Enter "stop" to stop prompting / Or click Cancel :)', '');
    if (input === null) {
        console.log('Reload page to start the scripts again.');
        break;
    }
    printDigitAsWord(input);    
}