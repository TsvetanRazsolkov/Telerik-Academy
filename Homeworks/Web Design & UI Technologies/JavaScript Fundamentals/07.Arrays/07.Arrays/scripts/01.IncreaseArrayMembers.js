// Write a script that allocates array of 20 integers and initializes each element
// by its index multiplied by 5. Print the obtained array on the console.

var intArray = [],
	index,
	arrToPrint;

for (index = 0; index < 20; index += 1) {
	intArray[index] = index * 5;
}

arrToPrint = intArray.join(', ');

console.log('=====================================');
console.log('01.Increase array members');
console.log('-------------------------');

console.log(arrToPrint);

