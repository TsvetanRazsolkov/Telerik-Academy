/*Write a script that finds the biggest of three numbers.
Use nested if statements.
Examples:

a	    b	    c	    biggest
5	    2	    2	    5
-2	    -2	    1	    1
-2	    4	    3	    4
0	    -2.5	5	    5
-0.1	-0.5	-1.1	-0.1    */

console.log('============================================');
console.log('03.The biggest of three');
console.log('---------------------------------');

function printBiggest(a, b, c) {
    if (a > b) {
        if (a > c) {
            console.log('a= ' + a + ', b= ' + b + ', c= ' + c + ' --> biggest= ' + a);
        }
        else {
            console.log('a= ' + a + ', b= ' + b + ', c= ' + c + ' --> biggest= ' + c);
        }
    }
    else {
        if (b > c) {
            console.log('a= ' + a + ', b= ' + b + ', c= ' + c + ' --> biggest= ' + b);
        }
        else {
            console.log('a= ' + a + ', b= ' + b + ', c= ' + c + ' --> biggest= ' + c);
        }
    }
}

printBiggest(5, 2, 2);
printBiggest(-2, -2, 1);
printBiggest(-2, 4, 3);
printBiggest(0, -2.5, 5);
printBiggest(-0.1, -0.5, -1.1);