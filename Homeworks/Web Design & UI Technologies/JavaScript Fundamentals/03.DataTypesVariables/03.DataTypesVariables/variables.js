// numbers
var integer = 1;
var float = 1.5;
var notANumber = NaN;
var aLot = Infinity;

// boolean
var boolFalse = false;
var boolTrue = true;

// strings
var emptyString = '';
var quotedString = '"How you doin\'?", Joey said.'; // task 2;

// null
var nullVar = null;

// undefined
var undefinedVar = undefined;

// object
var notEmptyObject = {
    objName: 'some name',
    objValue: 'useless'
}

// function
function getType(obj) {
    if (obj === null) {
        console.log('type of ' + obj + ' --> ' + typeof obj + '// Specific for the language -"typeof null" is "object"');
    }
    else {
        console.log('type of ' + obj + ' --> ' + typeof obj);
    }
}

//array
var array = [integer, float, notANumber, aLot, boolFalse, boolTrue, emptyString,
             quotedString, nullVar, undefinedVar, notEmptyObject];

for (var i = 0, len = array.length; i < len; i += 1) {
    getType(array[i])
}

console.log('type of array --> ' + typeof array);
console.log('type of function --> ' + typeof getType);