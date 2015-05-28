// Write a script that prints all the numbers from 1 to N.

var mainSeparator = '=========================================',
    innerSeparator = '------------------------',
    n = prompt('Task 1: Numbers from 1 to N - Enter a number N= :', 5) | 0,
    i;

console.log(mainSeparator);
console.log('01. Numbers');
console.log(innerSeparator);

if (n > 0) {
    for (i = 1; i <= n; i += 1) {
        console.log(i);
    }
}
else {
    for (i = 1; i >= n; i -= 1) {
        console.log(i);
    }
}
