// Write a function to count the number of div elements on the web page

console.log('===============================');
console.log('04. Number of elements');
console.log('--------------------');

function countElements(element) {
    var elementsCount = document.getElementsByTagName(element).length;
    return elementsCount;
}

console.log('Number of DIVs on the page --> ' + countElements('div'));
