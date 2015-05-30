/*Write an expression that checks for given integer
  if its third digit (right-to-left) is 7.
Examples:

n	    Third digit 7?
5	    false
701	    true
1732	true
9703	true
877	    false
777877	false
9999799	true         */

console.log('=========================================================');
console.log('04. Third digit');
console.log('-----------------------');

function checkThirdDigit(num) {
    var isSeven = Math.floor((num / 100) % 10) === 7;
    console.log('third digit of ' + num + ' is 7 --> ' + isSeven);
}

checkThirdDigit(5);
checkThirdDigit(701);
checkThirdDigit(1732);
checkThirdDigit(9703);
checkThirdDigit(877);
checkThirdDigit(777877);
checkThirdDigit(9999799);