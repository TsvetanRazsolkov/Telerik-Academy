﻿// Write a script that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time

console.log(mainSeparator);
console.log('02. Numbers not divisible by 3 and 7 at the same time');
console.log(innerSeparator);

var i,
    n = prompt('Task 2: Numbers not divisible - Enter number N= :', 22);

for (i = 1; i <= n; i += 1) {
    if (i % 3 === 0 && i % 7 === 0) {
        continue;
    }
    console.log(i);
}