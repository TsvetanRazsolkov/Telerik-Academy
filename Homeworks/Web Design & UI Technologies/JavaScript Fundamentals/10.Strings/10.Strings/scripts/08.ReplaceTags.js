/*Write a JavaScript function that replaces in a HTML document
given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].
Example:
input:	                                                  
<p>Please visit<a href="http://academy.telerik.com">our site</a>
to choose a training course. Alsovisit <a href="www.devbg.org">our forum</a>
to discuss the courses.</p>
output:
<p>Please visit [URL=http://academy.telerik.com]our site[/URL] 
to choose a training course. Also visit [URL=www.devbg.org]our forum[/URL]
to discuss the courses.</p>  */

console.log('==============================');
console.log('08. Replace tags');
console.log('----------------------');

var htmlAsText = '<p>Please visit<a href="http://academy.telerik.com">our site</a>to choose a training course. Alsovisit <a href="www.devbg.org">our forum</a>to discuss the courses.</p>';
    
function replaceAnchorTags(htmlDoc) {
    var startIndex = 0,
        endIndex = 0,
        substringBeforeTag,
        substringAfterTag,
        substringTag;

    while (true) {
        startIndex = htmlDoc.indexOf("<a href=\"", startIndex);
        endIndex = htmlDoc.indexOf("</a>", endIndex);

        if (startIndex === -1 || endIndex === -1) {
            break;
        }
        else if (startIndex >= 0 && endIndex >= 0) {
            substringBeforeTag = htmlDoc.substring(0, startIndex);
            substringAfterTag = htmlDoc.substring(endIndex + 4, htmlDoc.length);
            substringTag = htmlDoc.substr(startIndex, endIndex + 4 - startIndex);
            substringTag = substringTag.replace('<a href="', '[URL=');
            substringTag = substringTag.replace('">', ']');
            substringTag = substringTag.replace('</a>', '[/URL]');
            htmlDoc = substringBeforeTag + substringTag + substringAfterTag;
        }
        startIndex += 1;
        endIndex += 1;
    }

    return htmlDoc;
}

console.log('Initial HTML: ');
console.log(htmlAsText);
console.log('HTML with replaced tags: ');
console.log(replaceAnchorTags(htmlAsText));

