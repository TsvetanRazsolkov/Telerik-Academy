/* globals $ */

/* 

Create a function that takes an id or DOM element and an array of contents

* if an id is provided, select the element
* Add divs to the element
  * Each div's content must be one of the items from the contents array
* The function must remove all previous content from the DOM element provided
* Throws if:
  * The provided first parameter is neither string or existing DOM element
  * The provided id does not select anything (there is no element that has such an id)
  * Any of the function params is missing
  * Any of the function params is not as described
  * Any of the contents is neight `string` or `number`
    * In that case, the content of the element **must not be** changed   
*/

module.exports = function () {

    function validateInputParams(params) {
        var element = params[0],
            content = params[1];

        if (params.length !== 2) {
            throw new Error('invalid parameters - element and content must be passed to the function.');
        }

        if (!(element instanceof HTMLElement) && typeof element !== 'string') {
            throw new Error('element is neither a valid string ID nor a valid HTML element.');
        }

        if (typeof element === 'string' && document.getElementById(element) === null) {
            throw new Error('no element with such an ID in the DOM');
        }

        if (!Array.isArray(content)) {
            throw new Error('content should be an array of contents');
        }

        if (content.some(function (content) {
            return typeof content !== 'number' && typeof content !== 'string';
        })) {
            throw new Error('each content must be a number or a string');
        }  
    }

    return function (element, contents) {
        var elementToWork,
            firstChild,
            i,
            len,
            docFragment = document.createDocumentFragment(),
            divTemplate = document.createElement('div'),
            currentDiv;


        validateInputParams(arguments);

        elementToWork = element instanceof HTMLElement ? element : document.getElementById(element);

        firstChild = elementToWork.firstChild;
        while (firstChild) {
            elementToWork.removeChild(firstChild);
            firstChild = firstChild.nextSibling;
        }

        for (i = 0, len = contents.length; i < len; i+=1) {
            currentDiv = divTemplate.cloneNode(true);
            currentDiv.innerHTML = contents[i];
            docFragment.appendChild(currentDiv);
        }

        elementToWork.appendChild(docFragment);
  };
};
