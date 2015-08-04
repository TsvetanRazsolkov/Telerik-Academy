/* globals $ */

/* 

Create a function that takes an id or DOM element and:
  

*/

function solve(){
    return function (selector) {
        var element,
            buttons,
            i,
            len;

        function validateInputParameter(parameter) {
            if (parameter instanceof HTMLElement) {
                if (!document.contains(parameter)) {
                    throw new Error('The provided DOM element is non-existant.');
                } 
            }
            else if (typeof parameter === 'string') {
                if (document.getElementById(parameter) === null) {
                    throw new Error('No DOM element with ID like the one provided.');
                }
            }
            else {
                throw new Error('Inmput parameter is neither a string ID or a DOM element.');
            }
        }

        function onButtonClick(event) {
            var btn = event.target,
                currentElement = btn.nextSibling,
                contentElementToChange;

            while (currentElement) {
                if (currentElement.className === 'content' && contentElementToChange === undefined) {
                    contentElementToChange = currentElement;
                }
                if (currentElement.className === 'button' && contentElementToChange === undefined) {
                    return;
                }
                if (currentElement.className === 'button' && contentElementToChange !== undefined) {
                    if (contentElementToChange.style.display === 'none') {
                        contentElementToChange.style.display = '';
                        btn.innerHTML = 'hide';
                    }
                    else {
                        contentElementToChange.style.display = 'none';
                        btn.innerHTML = 'show';
                    }
                    return;
                }

                currentElement = currentElement.nextSibling;
            }
        }

        validateInputParameter(selector);
        
        element = selector instanceof HTMLElement ? selector : document.getElementById(selector);

        buttons = element.getElementsByClassName('button');
		Array.prototype.forEach.call(buttons, function (button) {
            button.innerHTML = 'hide';
		});
		
		element.addEventListener('click', onButtonClick);

  };
};

module.exports = solve;