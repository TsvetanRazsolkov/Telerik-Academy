/*Write a script that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots).
Calculates and prints its real roots.
Note: Quadratic equations may have 0, 1 or 2 real roots.

Examples:

a	    b	c	 roots
2	    5	-3	 x1=-3; x2=0.5
-1	    3	0	 x1=3; x2=0
-0.5	4	-8	 x1=x2=4
5	    2	8	 no real roots    */

console.log('============================================');
console.log('06.Quadratic equation');
console.log('---------------------------------');

var input,
    coefficients,
    a,
    b,
    c;

function parseCoefficients(input) {
    // TODO:
    return input.split(' ');
}

function solveEquation(input) {
    var discriminant,
        x1,
        x2;

    coefficients = parseCoefficients(input);
    a = coefficients[0] * 1;
    b = coefficients[1] * 1;
    c = coefficients[2] * 1;

    discriminant = Math.pow(b, 2) - 4 * a * c;

    if (discriminant < 0) {
        console.log('a= ' + a + ', b= ' + b + ', c= ' + c + ' --> no real roots');
    }
    else if (discriminant === 0) {
        x1 = -b / (2 * a);
        console.log('a= ' + a + ', b= ' + b + ', c= ' + c + ' --> x1=x2= ' + x1);
    }
    else {
        x1 = (-b - Math.sqrt(discriminant)) / (2 * a);
        x2 = (-b + Math.sqrt(discriminant)) / (2 * a);
        console.log('a= ' + a + ', b= ' + b + ', c= ' + c + ' --> x1= ' + x1 + '; x2= ' + x2);
    }
}

while (input !== 'spri be') {
    input = prompt('Task 6: Quadratic euation - Enter coefficients a, b, c separated by a SPACE: / Or "spri be" to stop prompting / Or click Cancel');
    if (input === null) {
        console.log('Reload page to start scripts again.');
        break;
    }
    solveEquation(input);
}

