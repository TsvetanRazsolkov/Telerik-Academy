/*Write a boolean expression for finding if the bit #3 (counting from 0)
of a given integer.
The bits are counted from right to left, starting from bit #0.
The result of the expression should be either 1 or 0.
Examples:

n	    binary representation	bit #3
5	    00000000 00000101	    0
8	    00000000 00001000	    1
0	    00000000 00000000	    0
15	    00000000 00001111	    1
5343	00010100 11011111	    1
62241	11110011 00100001	    0                           */


console.log('=========================================================');
console.log('05. Third bit');
console.log('-----------------------');

function binaryRepresentation(num) {
    var binNum = num.toString(2);
    var pad = "0000000000000000";
    var paddedNum = pad.substring(0, pad.length - binNum.length) + binNum;
    var result = paddedNum.substr(0, 8) + ' ' + paddedNum.substr(8, paddedNum.length - 8);
    return result;
}

function printThirdBit(num) {
    var mask = 1 << 3;
    var thirdBit = (num & mask) >> 3;
    console.log('number = ' + num + ', binary representation = ' + binaryRepresentation(num) + ', bit #3 = ' + thirdBit);
}

printThirdBit(5);
printThirdBit(8);
printThirdBit(0);
printThirdBit(15);
printThirdBit(5343);
printThirdBit(62241);