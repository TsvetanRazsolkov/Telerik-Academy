//Write a function that makes a deep copy of an object.
//The function should work for both primitive and reference types.

console.log('=================================');
console.log('03. Deep copy');
console.log('-------------------------');

var someObj = {
    a: 5,
    b: 7,
    arr: [1, 2, 3, 4, 5],
    toString: function () {
        return '{' + 'a: ' + this.a + ', b: ' + this.b + ', arr: ' + this.arr + '}';
    }
},
    somePrimitiveType = 'Squirrel',
    copiedObj,
    copiedPrimitive;

function deepCopy(obj) {
    if (obj === null || typeof (obj) !== 'object') {
        return obj;
    }

    var result = obj.constructor();

    for (var key in obj) {
        if (Object.prototype.hasOwnProperty.call(obj, key)) {
            result[key] = deepCopy(obj[key]);
        }
    }
    return result;
}

copiedObj = deepCopy(someObj);
copiedPrimitive = deepCopy(somePrimitiveType);

console.log('Primitive type: ' + somePrimitiveType);
console.log('Copied primitive type: ' + copiedPrimitive);
somePrimitiveType = 'Not a squirrel';
console.log('Primitive type after a change: ' + somePrimitiveType);
console.log('Copied primitive type from before the change: ' + copiedPrimitive);

console.log('-------------------------');
console.log('Reference type: ' + someObj);
console.log('Copy of reference type: ' + copiedObj);
someObj.a = 'Chocolate';
someObj.arr = ['a', 'b', 'c', 'd', 'e'];
console.log('Reference type after a change: ' + someObj);
console.log('Copy of reference type from before the change: ' + copiedObj);