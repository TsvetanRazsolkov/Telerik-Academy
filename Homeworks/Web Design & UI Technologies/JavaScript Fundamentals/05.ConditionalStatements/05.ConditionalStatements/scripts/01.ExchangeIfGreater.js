/*Write an if statement that takes two double variables a and b and exchanges their values if the first one
is greater than the second. As a result print the values a and b, separated by a space.
Examples:
a    b    result
5    2    2 5
3    4    3 4
5.5  4.5  4.5 5.5   */

var mainSeparator = '============================================';
	innerSeparator = '---------------------------------';
	
console.log(mainSeparator);
console.log('01.Exchange if greater');
console.log(innerSeparator);

function exchangeIfGreater(a, b) {
    var temp;
    console.log('a= ' + a + ', b= ' + b);
    if (a > b) {
        temp = a;
        a = b;
        b = temp;
    }
    console.log('result --> a= ' + a + ', b= ' + b);
}

exchangeIfGreater(5, 2);
exchangeIfGreater(3, 4);
exchangeIfGreater(5.5, 4.5);



