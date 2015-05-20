/*Write a script that shows the sign (+, - or 0) of the product of three real numbers, without calculating it.
Use a sequence of if operators.
Examples:

a	b	    c	    result
5	2	    2	    +
-2	-2	    1	    +
-2	4	    3	    -
0	-2.5	4	    0
-1	-0.5	-5.1	-        */

console.log(mainSeparator);
console.log('02.Multiplication sign');
console.log(innerSeparator);

function showSign(a, b, c) {
    var numbers = [a, b ,c],
        minusCount = 0,
        i,
        len = numbers.length;

    if (a === 0 || b === 0 || c === 0) {
        console.log('a= ' + a + ', b= ' + b + ', c= ' + c + ' --> ' + '0');
    }
    else {
        for (i = 0; i < len; i += 1) {
            if (numbers[i] < 0) {
                minusCount += 1;
            }
        }
        if (minusCount % 2 === 0) {
            console.log('a= ' + a + ', b= ' + b + ', c= ' + c + ' --> ' + '+');
        }
        else {
            console.log('a= ' + a + ', b= ' + b + ', c= ' + c + ' --> ' + '-');
        }
    }
}

showSign(5, 2, 2);
showSign(-2, -2, 1);
showSign(-2, 4, 3);
showSign(0, -2.5, 4);
showSign(-1, -0.5, -5.1);