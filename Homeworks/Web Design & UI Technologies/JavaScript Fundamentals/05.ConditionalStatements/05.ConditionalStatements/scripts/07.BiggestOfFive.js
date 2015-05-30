/*Write a script that finds the greatest of given 5 variables.
Use nested if statements.
Examples:

a	b	    c	    d	e	    biggest
5	2	    2	    4	1	    5
-2	-22	    1	    0	0	    1
-2	4	    3	    2	0	    4
0	-2.5	0	    5	5	    5
-3	-0.5	-1.1	-2	-0.1	-0.1   */

console.log('============================================');
console.log('07.The biggest of five numbers');
console.log('---------------------------------');

function printGreatestOfFive(a, b, c, d, e) {
    var printInput = 'a= ' + a + ', b= ' + b + ', c= ' + c + ', d= ' + d + ', e= ' + e + ' --> biggest= ';
    if (a > b) {
        if (a > c) {
            if (a > d) {
                if (a > e) {
                    console.log(printInput + a);
                }
                else {
                    console.log(printInput + e);
                }
            }
            else {
                if (d > e) {
                    console.log(printInput + d);
                }
                else {
                    console.log(printInput + e);
                }
            }
        }
        else {
            if (c > d) {
                if (c > e) {
                    console.log(printInput + c);
                }
                else {
                    console.log(printInput + e);
                }
            }
            else {
                if (d > e) {
                    console.log(printInput + d);
                }
                else {
                    console.log(printInput + e);
                }
            }
        }
    }
    else {
        if (b > c) {
            if (b > d) {
                if (b > e) {
                    console.log(printInput + b);
                }
                else {
                    console.log(printInput + e);
                }
            }
            else {
                if (d > e) {
                    console.log(printInput + d);
                }
                else {
                    console.log(printInput + e);
                }
            }
        }
        else {
            if (c > d) {
                if (c > e) {
                    console.log(printInput + c);
                }
                else {
                    console.log(printInput + e);
                }
            }
            else {
                if (d > e) {
                    console.log(printInput + d);
                }
                else {
                    console.log(printInput + e);
                }
            }
        }
    }
}

printGreatestOfFive(5, 2, 2, 4, 1);
printGreatestOfFive(-2, -22, 1, 0, 0);
printGreatestOfFive(-2, 4, 3, 2, 0);
printGreatestOfFive(0, -2.5, 0, 5, 5);
printGreatestOfFive(-3, -0.5, -1.1, -2, -0.1);
