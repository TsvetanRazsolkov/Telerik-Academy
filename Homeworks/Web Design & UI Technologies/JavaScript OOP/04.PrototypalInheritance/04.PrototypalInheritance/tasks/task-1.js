/* Task Description */
/*
* Create an object domElement, that has the following properties and methods:
  * use prototypal inheritance, without function constructors
  * method init() that gets the domElement type
    * i.e. `Object.create(domElement).init('div')`
  * property type that is the type of the domElement
    * a valid type is any non-empty string that contains only Latin letters and digits
  * property innerHTML of type string
    * gets the domElement, parsed as valid HTML
	  * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
  * property content of type string
    * sets the content of the element
    * works only if there are no children
  * property attributes
    * each attribute has name and value
    * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
  * property children
    * each child is a domElement or a string
  * property parent
    * parent is a domElement
  * method appendChild(domElement / string)
    * appends to the end of children list
  * method addAttribute(name, value)
    * throw Error if type is not valid
  * // method removeAttribute(attribute)
*/

/* Example

var meta = Object.create(domElement)
	.init('meta')
	.addAttribute('charset', 'utf-8');

var head = Object.create(domElement)
	.init('head')
	.appendChild(meta)

var div = Object.create(domElement)
	.init('div')
	.addAttribute('style', 'font-size: 42px');

div.content = 'Hello, world!';

var body = Object.create(domElement)
	.init('body')
	.appendChild(div)
	.addAttribute('id', 'cuki')
	.addAttribute('bgcolor', '#012345');

var root = Object.create(domElement)
	.init('html')
	.appendChild(head)
	.appendChild(body);

console.log(root.innerHTML);
Outputs:
<html><head><meta charset="utf-8"></meta></head><body bgcolor="#012345" id="cuki"><div style="font-size: 42px">Hello, world!</div></body></html>
*/


function solve() {
    var domElement = (function () {
        var indexOfExistingAttribute;

        function validateTypeOrAttributeName(parameter, isType) {
            var parameterAsCharArray;
            if (typeof parameter !== 'string' || parameter.length === 0) {
                throw new Error('Type or attribute name must be a non empty string.');
            }
            parameterAsCharArray = parameter.split('');

            if (!parameterAsCharArray.every(function (char) {
                var charCode = char.charCodeAt(0);

                return isType ? (charCode >= 65 && charCode <= 90) ||
                                (charCode >= 97 && charCode <= 122) ||
                                (charCode >= 48 && charCode <= 57)
                              : (charCode >= 65 && charCode <= 90) ||
                                (charCode >= 97 && charCode <= 122) ||
                                (charCode >= 48 && charCode <= 57) ||
                                charCode === 45;
            })) {
                throw new Error('Type or attribute name string must contain only latin letters or digits(and dashes for attribute name).');
            }
        }

        function validateChild(childObj) {
            if (typeof childObj !== 'string' && !childObj.parent) {
                throw new Error('Child must be a domElement or a string');
            }
        }

        function attributeExists(attributeName, attributesCollection) {
            return attributesCollection.some(function (attribute, index) {
                indexOfExistingAttribute = index;
                return attribute.name === attributeName;
            });
        }

        var domElement = {
            init: function (type) {
                this.type = type;
                this.attributes = [];
                this.children = [];

                return this;
            },
            appendChild: function (child) {
                child.parent = this;
                validateChild(child);
                this.children.push(child);

                return this;
            },
            addAttribute: function (name, value) {

                validateTypeOrAttributeName(name, false);

                if (attributeExists(name, this.attributes)) {
                    this.attributes[indexOfExistingAttribute].value = value;
                }
                else {
                    this.attributes.push({ name: name, value: value });
                }

                return this;
            },
            removeAttribute: function (attributeToDelete) {
                if (attributeExists(attributeToDelete.name, this.attributes)) {
                    this.attributes.splice(indexOfExistingAttribute, 1);
                }
                /*
                 else {
                    throw new Error('No such attribute to remove'); // Or don't throw an error - see if there are tests;
                 }
                 */
            },
            get innerHTML() {
                var result = '',
                i,
                len;

                if (typeof this === 'string') {
                    result += this;
                }
                else if (domElement.isPrototypeOf(this)) {
                    result += ('<' + this.type);

                    if (this.attributes.length) {
                        len = this.attributes.length;

                        this.attributes.sort(function (x, y) {
                            return x.name < y.name ? -1 : 1;
                        });

                        for (i = 0; i < len; i += 1) {
                            result += (' ' + this.attributes[i].name + '="' + this.attributes[i].value + '"');
                        }
                    }
                    result += '>';

                    if (this.children.length) {
                        len = this.children.length;

                        for (i = 0; i < len; i += 1) {
                            if (typeof this.children[i] === 'string') {
                                result += this.children[i];
                            }
                            else {
                                result += this.children[i].innerHTML;
                            }
                        }
                    }
                    else {
                        if (this.content) {
                            result += this.content;
                        }
                    }
                    result += ('</' + this.type + '>');
                }

                return result;
            },
            get content() {
                return this._content;
            },
            set content(value) {
                if (this.children.length === 0 && typeof value === 'string') {
                    this._content = value;
                }
            },
            get type() {
                return this._type;
            },
            set type(value) {
                validateTypeOrAttributeName(value, true);
                this._type = value;
            },
            get parent() {
                return this._parent;
            },
            set parent(value) {
                if (!domElement.isPrototypeOf(value)) {
                    throw new Error('Parent must be a domElement');
                }
                this._parent = value;
            }, get attributes() {
                return this._attributes;
            },
            set attributes(value) {
                this._attributes = value;
            },
            get children() {
                return this._children;
            },
            set children(value) {
                this._children = value;
            }
        };
        return domElement;
    }());
    return domElement;
}

module.exports = solve;
