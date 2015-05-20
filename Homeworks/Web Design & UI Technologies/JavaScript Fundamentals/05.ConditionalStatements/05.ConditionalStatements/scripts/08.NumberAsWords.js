/*Write a script that converts a number in the range [0…999] to words, corresponding to its English pronunciation.
Examples:
numbers	number as words
0	    Zero
9	    Nine
10	    Ten
12	    Twelve
19	    Nineteen
25	    Twenty five
98	    Ninety eight
98	    Ninety eight
273	    Two hundred and seventy three
400	    Four hundred
501	    Five hundred and one
617	    Six hundred and seventeen
711	    Seven hundred and eleven
999	    Nine hundred and ninety nine   */

console.log(mainSeparator);
console.log('08.Number as words');
console.log(innerSeparator);

function getDigit(digit) {
    switch (digit) {
        case 0: return 'zero';
        case 1: return 'one';
        case 2: return 'two';
        case 3: return 'three';
        case 4: return 'four';
        case 5: return 'five';
        case 6: return 'six';
        case 7: return 'seven';
        case 8: return 'eight';
        case 9: return 'nine';
        default: return '';
    }
}

function getScores(digit) {
    switch (digit) {
        case 2: return 'twenty';
        case 3: return 'thirty';
        case 4: return 'forty';
        case 5: return 'fifty';
        case 6: return 'sixty';
        case 7: return 'seventy';
        case 8: return 'eighty';
        case 9: return 'ninety';
        default: return '';
    }
}

function getTeens(digit) {
    switch (digit) {
        case 10: return 'ten';
        case 11: return 'eleven';
        case 12: return 'twelve';
        case 13: return 'thirteen';
        case 14: return 'fourteen';
        case 15: return 'fifteen';
        case 16: return 'sixteen';
        case 17: return 'seventeen';
        case 18: return 'eighteen';
        case 19: return 'nineteen';
        default: return '';
    }
}

function printNumberAsWords(num) {
    var result = '',
        printTemplate = 'number= ' + num + ', number as words --> ',
        hundreds = Math.floor(num / 100) % 10,
        scores = Math.floor(num / 10) % 10,
        ones = num % 10;

    if (num >= 0 && num <= 999 && !isNaN(num) && num !== '') {

        if (hundreds === 0 && scores === 0 && ones === 0) {
            result = 'zero';
        }

        if (hundreds > 0) {
            result += getDigit(hundreds) + ' hundred';
        }

        if (scores > 0 || ones > 0) {
            if (result.length > 0) {
                result += ' and ';
            }

            if (scores > 0) {
                if (scores === 1) {
                    result += getTeens(scores * 10 + ones);
                    console.log(printTemplate + result);
                    return;
                }
                else {
                    result += getScores(scores);
                }
            }

            if (ones > 0) {
                if (scores > 0) {
                    result += ' ';
                }

                result += getDigit(ones);
            }
        }

        console.log(printTemplate + result);
    }
    else {
        console.log('Invalid input, not that it is possible with this setup, but still ... :)');
    }
}

printNumberAsWords(0);
printNumberAsWords(9);
printNumberAsWords(10);
printNumberAsWords(12);
printNumberAsWords(19);
printNumberAsWords(25);
printNumberAsWords(98);
printNumberAsWords(98);
printNumberAsWords(273);
printNumberAsWords(400);
printNumberAsWords(501);
printNumberAsWords(617);
printNumberAsWords(711);
printNumberAsWords(999);