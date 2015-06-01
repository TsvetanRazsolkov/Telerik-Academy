/*Write a function for extracting all email addresses from given text.
All sub-strings that match the format @… should be recognized as emails.
Return the emails as array of strings.*/

console.log('==============================');
console.log('09. Extract e-mail');
console.log('----------------------');

var text = 'Not an email - @ / an email -  @gmail.com.MeetsCondition / also @... / This is an email: @.E-mail, / This also: @gmail.com';

function extractEmails(someText) {
    var result = [],
        regEx = /@./,
        textAsArray = someText.split(' '),
        i,
        len = textAsArray.length;

    for (i = 0; i < len; i+=1) {
        if (regEx.test(textAsArray[i])) {
            result.push(textAsArray[i]);
        }
    }

    return result;
}

console.log('Text: ');
console.log(text);
console.log('Extracted emails according to the condition of the task: ');
console.log(extractEmails(text));
