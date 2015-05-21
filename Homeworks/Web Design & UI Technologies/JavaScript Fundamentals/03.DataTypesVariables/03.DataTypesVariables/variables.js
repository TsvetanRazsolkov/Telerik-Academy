// numbers
var integer = 1,
 float = 1.5,
 notANumber = NaN,
 aLot = Infinity,
// boolean
 boolFalse = false,
 boolTrue = true,
// strings
 emptyString = '',
 quotedString = '"How you doin\'?", Joey said.', // task 2;
// null
 nullVar = null,
// undefined
 undefinedVar = undefined,
// object
 notEmptyObject = {
     objName: 'some name',
     objValue: 'useless'
 },
//array
array = [integer, float, notANumber, aLot, boolFalse, boolTrue, emptyString,
             quotedString, nullVar, undefinedVar, notEmptyObject];

// function
function getType(obj) {
    if (obj === null) {
        console.log('type of ' + obj + ' --> ' + typeof obj + '// Specific for the language -"typeof null" is "object"');
    }
    else {
        console.log('type of ' + obj + ' --> ' + typeof obj);
    }
}

for (var i = 0, len = array.length; i < len; i += 1) {
    getType(array[i]);
}

console.log('type of array --> ' + typeof array);
console.log('type of function --> ' + typeof getType);