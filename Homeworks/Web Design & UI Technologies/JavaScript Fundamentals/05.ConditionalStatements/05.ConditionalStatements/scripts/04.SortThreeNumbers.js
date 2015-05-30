/*Sort 3 real values in descending order.
Use nested if statements.
Note: Don’t use arrays and the built-in sorting functionality.

Examples:

a	    b	    c	    result
5	    1	    2	    5 2 1
-2	    -2	    1	    1 -2 -2
-2	    4	    3	    4 3 -2
0	    -2.5	5	    5 0 -2.5
-1.1	-0.5	-0.1	-0.1 -0.5 -1.1
10	    20	    30	    30 20 10
1	    1	    1	    1 1 1          */

console.log('============================================');
console.log('04.Sort three numbers');
console.log('---------------------------------');

function printSortedThreeNumbers(a, b, c) {
    if (a > b) {
        if (a > c) {
            if (b > c) {
                console.log('a= ' + a + ', b= ' + b + ', c= ' + c + ' --> result: ' + a + ' ' + b + ' ' + c);
            }
            else {
                console.log('a= ' + a + ', b= ' + b + ', c= ' + c + ' --> result: ' + a + ' ' + c + ' ' + b);
            }
        }
        else {
            console.log('a= ' + a + ', b= ' + b + ', c= ' + c + ' --> result: ' + c + ' ' + a + ' ' + b);
        }
    }
    else {
        if (b > c) {
            if (a > c) {
                console.log('a= ' + a + ', b= ' + b + ', c= ' + c + ' --> result: ' + b + ' ' + a + ' ' + c);
            }
            else {
                console.log('a= ' + a + ', b= ' + b + ', c= ' + c + ' --> result: ' + b + ' ' + c + ' ' + a);
            }
        }
        else {
            console.log('a= ' + a + ', b= ' + b + ', c= ' + c + ' --> result: ' + c + ' ' + b + ' ' + a);
        }
    }
}

printSortedThreeNumbers(5, 1, 2);
printSortedThreeNumbers(-2, -2, 1);
printSortedThreeNumbers(-2, 4, 3);
printSortedThreeNumbers(0, -2.5, 5);
printSortedThreeNumbers(-1.1, -0.5, -0.1);
printSortedThreeNumbers(10, 20, 30);
printSortedThreeNumbers(1, 1, 1);