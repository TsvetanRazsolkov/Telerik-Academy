/*Write an expression that checks if given point P(x, y) is within a circle K(O, 5).
Examples:

x	    y	    inside
0	    1	    true
-2	    0	    true
-1	    2	    true
1.5	    -1	    true
-1.5	-1.5	true
100	    -30	    false
0	    0	    true
0.2	    -0.8	true
0.9	    -1.93	true
1	    1.655	true        */

console.log(mainSeparator);
console.log('06. Point in circle');
console.log(innerSeparator);

var circleCenterX = 0,
    circleCenterY = 0,
    circleRadius = 5;

function checkPoint(x, y) {
    var isInsideCircle = Math.pow(x - circleCenterX, 2) + Math.pow(y - circleCenterY, 2) < Math.pow(circleRadius, 2);

    console.log('x= ' + x + ', y= ' + y + ', inside --> ' + isInsideCircle);
}

checkPoint(0, 1);
checkPoint(0, 5);
checkPoint(1.5, -1);
checkPoint(-10, 2);