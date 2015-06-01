/*Write a function that extracts the content of a html page given as text.
The function should return anything that is in a tag, without the tags.
Example:

<html>
  <head>
    <title>Sample site</title>
  </head>
  <body>
    <div>text
      <div>more text</div>
      and more...
    </div>
    in body
  </body>
</html>
Result: Sample sitetextmore textand more...in body*/

console.log('==============================');
console.log('06. Extract text from HTML');
console.log('----------------------');

var htmlAsText = document.getElementsByTagName('html')[0].outerHTML,
    sampleHtml = '<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>';

function extractFromHTML(htmlCode) {
    var i,
        j,
        len = htmlCode.length,
        indexOfNextTag,
        result = '',
        shouldInclude = true;

    for (i = 0; i < len; i += 1) {
        if (htmlCode[i] === '<') {
            shouldInclude = false;
        }
        else if (htmlCode[i] === '>') {
            // Next lines for eliminating code formatting when between closing and opening tag
            //there is no actual text. If there is a text offsets and new lines are kept.
            indexOfNextTag = htmlCode.indexOf('<', i);
            for (j = i + 1; j < indexOfNextTag ; j+=1) { 
                if (htmlCode[j] !== '\t' && htmlCode[j] !== '\r' && htmlCode[j] !== '\n' && htmlCode[j] !== ' ') {
                    shouldInclude = true;
                    break;
                }
            }
            if (!shouldInclude && i < len - 1) {
                i = indexOfNextTag - 1;
            }
            continue;
        }
        if (shouldInclude) {
            result += htmlCode[i];
        }
    }
    return result;
}

console.log('Sample HTML: ');
console.log(sampleHtml);
console.log('----------------------');
console.log('extracted text from sample HTML: ');
console.log(extractFromHTML(sampleHtml));
console.log('----------------------');
console.log('initial formatted html from the web page: ');
console.log(htmlAsText);
console.log('----------------------');
console.log('extracted text from web page HTML: ');
console.log(extractFromHTML(htmlAsText));

