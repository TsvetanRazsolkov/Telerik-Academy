/*Write a function that puts the value of an object into the content/attributes of HTML tags.
Add the function to the String.prototype
Example 1:
input
    var str = '<div data-bind-content="name"></div>';
    str.bind(str, {name: 'Steven'});
output
    <div data-bind-content="name">Steven</div>
Example 2:
input
    var bindingString = '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></а>'
    str.bind(str, {name: 'Elena', link: 'http://telerikacademy.com'});
output
    <a data-bind-content="name" data-bind-href="link" data-bind-class="name" href="http://telerikacademy.com" class="Elena">Elena</а>*/

console.log('=================================');
console.log('02. HTML binding');
console.log('-------------------');

var str1 = '<div data-bind-content="name"></div>',
    str2 = '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></div>';

String.prototype.bind = function (object) {
    var regExpContent,
        regExpHref,
        regExpClass,
        prop;
        result = this;

    for (prop in object) {
        regExpContent = new RegExp('(<.*?data-bind-content="' + prop + '".*?>)(.*?)(<\\s*/.*?>)', 'g');
        regExpHref = new RegExp('(<.*?data-bind-href="' + prop + '".*?)>', 'g');
        regExpClass = new RegExp('(<.*?data-bind-class="(' + prop + ')".*?)>', 'g');

        // https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/replace#Specifying_a_function_as_a_parameter
        result = result.replace(regExpContent, function (match, openingTag, insideTag, closingTag) {
            return openingTag + insideTag + object[prop] + closingTag;
        })
                       .replace(regExpHref, function (match, contentOfOpeningTag) {
            return contentOfOpeningTag + ' href="' + object[prop] + '">';
        })
                       .replace(regExpClass, function (match, contentOfOpeningTag) {
            return contentOfOpeningTag + ' class="' + object[prop] + '">';
        });
    }

    return result;
};

console.log(str1.bind({ name: 'Steven' }));
console.log(str2.bind({ name: 'Elena', link: 'http://telerikacademy.com' }));
