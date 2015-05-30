/*Write functions for working with shapes in standard Planar coordinate system.
Points are represented by coordinates P(X, Y)
Lines are represented by two points, marking their beginning and ending L(P1(X1,Y1), P2(X2,Y2))
Calculate the distance between two points.
Check if three segment lines can form a triangle.*/

var firstLine,
    secondLine,
    thirdLine;

function buildPoint(x, y) {
    return {
        x: x,
        y: y,
        toString: function () {
            return '(' + this.x + ', ' + this.y + ')';
        }
    };
}

function buildLine(x1, y1, x2, y2) {
    return {
        p1: buildPoint(x1, y1),
        p2: buildPoint(x2, y2),
        toString: function () {
            return 'L(P1' + this.p1.toString() + ', P2' + this.p2.toString() + ')';
        }
    };
}

function calcDistanceBetweenPoints(p1, p2) {
    var distX = p1.x - p2.x,
        distY = p1.y - p2.y,
        distance;
    distance = Math.sqrt(distX * distX + distY * distY);
    return distance;
}

function checkIfTriangleIsPossible(a, b, c) {
    var aLength = calcDistanceBetweenPoints(a.p1, a.p2),
        bLength = calcDistanceBetweenPoints(b.p1, b.p2),
        cLength = calcDistanceBetweenPoints(c.p1, c.p2);

    return ((aLength + bLength) > cLength && (aLength + cLength) > bLength && (bLength + cLength) > aLength);
}

firstLine = buildLine(0, 0, 2, 2);
secondLine = buildLine(0, 0, 3, 3);
thirdLine = buildLine(0, 0, 2, 2);

console.log('=================================');
console.log('01. Planar coordinates');
console.log('-------------------------');

console.log('first line: ' + firstLine.toString());
console.log('second line: ' + secondLine.toString());
console.log('third line: ' + thirdLine.toString());
console.log('-------------------------');
console.log('Distance between P1 and P2 of first line= ' + calcDistanceBetweenPoints(firstLine.p1, firstLine.p2));
console.log('Distance between P1 and P2 of second line= ' + calcDistanceBetweenPoints(secondLine.p1, secondLine.p2));
console.log('Distance between P1 and P2 of third line= ' + calcDistanceBetweenPoints(thirdLine.p1, thirdLine.p2));
console.log('-------------------------');
console.log('The three lines ' + (checkIfTriangleIsPossible(firstLine, secondLine, thirdLine) ? 'CAN' : 'CANNOT') + ' form a triangle.');