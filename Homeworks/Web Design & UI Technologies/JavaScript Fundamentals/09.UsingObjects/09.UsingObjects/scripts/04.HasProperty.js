/*Write a function that checks if a given object contains a given property.

var obj  = …;
var hasProp = hasProperty(obj, 'length');  */

console.log('=================================');
console.log('04. Has property');
console.log('-------------------------');

var obj = {
    pesho: 1,
    gosho: 2,
    tosho: 3,
    toString: function () {
        return '{' + 'pesho: ' + this.pesho + ', gosho: ' + this.gosho + ', tosho: ' + this.tosho + '}';
    }
},
    arr = [1, 2, 3, 4, 5];

function hasProperty(obj, property) {
    return obj.hasOwnProperty(property);
}

console.log('Object: ' + obj + ', has property "length" --> ' + hasProperty(obj, 'length'));
console.log('Object: ' + obj + ', has property "pesho" --> ' + hasProperty(obj, 'pesho'));

console.log('Object: ' + arr + ', has property "length" --> ' + hasProperty(arr, 'length'));
console.log('Object: ' + arr + ', has property "pesho" --> ' + hasProperty(arr, 'pesho'));

