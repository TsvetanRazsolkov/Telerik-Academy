/*Write a function that removes all elements with a given value.
Attach it to the array type.
Read about prototype and how to attach methods.

var arr = [1,2,1,4,1,3,4,1,111,3,2,1,'1'];
arr.remove(1); //arr = [2,4,3,4,111,3,2,'1']; */

var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];

console.log('=================================');
console.log('02. Remove elements');
console.log('-------------------------');

Array.prototype.removeElements = function (value) {
    for (var i = this.length - 1; i >= 0; i -= 1) {
        if (this[i] === value) {
            this.splice(i, 1);
        }
    }
};

console.log('Initial array: ' + arr);
arr.removeElements(1);
console.log('Array with removed all elements with numeric value 1: ' + arr);