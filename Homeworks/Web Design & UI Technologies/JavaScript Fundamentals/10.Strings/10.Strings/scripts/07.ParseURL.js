/*Write a script that parses an URL address given in the format:
[protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements.
Return the elements in a JSON object.
Example:
URL:
http://telerikacademy.com/Courses/Courses/Details/239
result:
{ protocol: http, 
server: telerikacademy.com 
resource: /Courses/Courses/Details/239  */

console.log('==============================');
console.log('07. Parse URL');
console.log('----------------------');

var url = 'http://telerikacademy.com/Courses/Courses/Details/239',
    endIndexOfProtocol,
    endIndexOfServer,
    result = {};

endIndexOfProtocol = url.indexOf('://');
result.protocol = url.substring(0, endIndexOfProtocol);

endIndexOfServer = url.indexOf('/', endIndexOfProtocol + 3);
result.server = url.substring(endIndexOfProtocol + 3, endIndexOfServer);

result.resource = url.substring(endIndexOfServer, url.length);

console.log('URL to parse: http://telerikacademy.com/Courses/Courses/Details/239');
console.log(result);