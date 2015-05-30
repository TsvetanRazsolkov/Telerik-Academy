/* Write an expression that calculates rectangle’s area by given width and height.
Examples:
width	height	area
3	    4	    12
2.5	    3	    7.5
5	    5	    25     */

console.log('=========================================================');
console.log('03. Rectangle area');
console.log('-----------------------');

function calculateRectArea(width, height) {
	var area = width * height;
	console.log('width = ' + width + ', height = ' + height + ', area = ' + area);
}

calculateRectArea(3, 4);
calculateRectArea(2.5, 3);
calculateRectArea(5, 5);