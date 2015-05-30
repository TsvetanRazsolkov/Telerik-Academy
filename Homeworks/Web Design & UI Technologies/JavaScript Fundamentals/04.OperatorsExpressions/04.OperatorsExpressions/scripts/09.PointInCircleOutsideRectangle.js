/*Write an expression that checks for given point P(x, y) if it is within the circle K( (1,1), 3)
and out of the rectangle R(top=1, left=-1, width=6, height=2).
Examples:
x	    y	    inside K & outside of R
1	    2	    yes
2.5	    2	    yes
-100	-100	no       */

console.log('=========================================================');
console.log('09. Point in circle and outside a rectangle');
console.log('-----------------------');

var xCircleCenter = 1,
    yCircleCenter = 1,
    radiusCircle = 3,
    xRectangleLeft = -1,
    xRectangleRight = 5,
    yRectangleTop = 1,
    yRectangleBottom = -1;

function pointInCircle(x, y) {
    var isInsideCircle = Math.pow(x - xCircleCenter, 2) + Math.pow(y - yCircleCenter, 2) < Math.pow(radiusCircle, 2);
    return isInsideCircle;
}

function pointOutsideRectangle(x, y) {
    var isOutsideRectangle = true;
    if (x >= xRectangleLeft && x <= xRectangleRight && y <= yRectangleTop && y >= yRectangleBottom) {
        isOutsideRectangle = false;
    }
    return isOutsideRectangle;
}

console.log('x= 1, y= 2, inside K & outside of R --> ' + (pointInCircle(1, 2) && pointOutsideRectangle(1, 2) ? 'yes' : 'no'));
console.log('x= 2.5, y= 2, inside K & outside of R --> ' + (pointInCircle(2.5, 2) && pointOutsideRectangle(2.5, 2) ? 'yes' : 'no'));
console.log('x= -100, y= -100, inside K & outside of R --> ' + (pointInCircle(-100, -100) && pointOutsideRectangle(-100, -100) ? 'yes' : 'no'));