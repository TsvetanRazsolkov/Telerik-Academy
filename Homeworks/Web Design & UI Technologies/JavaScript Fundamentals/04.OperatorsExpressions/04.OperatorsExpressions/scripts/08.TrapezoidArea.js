﻿/*Write an expression that calculates trapezoid's area by given sides a and b and height h.
Examples:
a	    b	    h	    area
5	    7	    12	    72
2	    1	    33	    49.5
8.5	    4.3	    2.7	    17.28
100	    200	    300	    45000
0.222	0.333	0.555	0.1540125    */

console.log('=========================================================');
console.log('08. Trapezoid area');
console.log('-----------------------');

function printTrapArea(a, b, h) {
    var area = ((a + b)/2) * h;

    console.log('a= ' + a + ', b= ' + b + ', h= ' + h + ', area= ' + area);
}

printTrapArea(5, 7, 12);
printTrapArea(2, 1, 33);
printTrapArea(8.5, 4.3, 2.7);
printTrapArea(100, 200, 300);
printTrapArea(0.222, 0.333, 0.555);