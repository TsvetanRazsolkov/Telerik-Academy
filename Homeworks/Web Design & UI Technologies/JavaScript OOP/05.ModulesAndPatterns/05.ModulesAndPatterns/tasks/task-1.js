/* Task Description */
/* 
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {
    function validateTitle(title) {
        if (typeof title !== 'string' || title.trim() === '' || /^\s|\s{2,}|\s$/.test(title)) {
            throw {
                name: 'Type Error',
                message: 'Invalid title'
            };
        }
    }

    function validateStudentName(fullname) {
        // If needed check if fullname is string etc.
        var names = fullname.split(' '),
            nameValidationRegEx = /^[A-Z]{1}[a-z]*$/;

        if (names.length !== 2) {
            throw new Error('Student must be passed as parameter with two names.');
        }

        names.forEach(function (item) {
            if (!nameValidationRegEx.test(item)) {
                throw {
                    name: 'Type Error',
                    message: 'Invalid name' + item
                };
            }
        });
    }

    function checkIfIdIsNumber(id) {
        // Check if id is a value convertible to number:
        if (isNaN(parseInt(id))) {
            throw {
                name: 'Type Error',
                message: 'Invalid ID - not a number'
            };
        }
        //// The following will check if id is actually a number(not clear in the HW assignment):
        //if (id !== id * 1) {
        //    throw {
        //        name: 'Type Error',
        //        message: 'Invalid ID - not a number'
        //    };
        //}
    }

    function checkIfIdIsValid(id, maxValueOfId) {
        if (!Number.isInteger(id * 1) || id < 1 || id > maxValueOfId) {
            return false;
        }
        return true;
    }

    function validateExamResults(resultsCollection) {
        var i,
            len = resultsCollection.length,
            idsArray = [];

        if (!Array.isArray(resultsCollection)) {
            throw new Error('Results must be array of objects');
        }

        for (i = 0; i < len; i += 1) {
            // Check if studentID is a number:
            checkIfIdIsNumber(resultsCollection[i].StudentID);
            // Check if score is a number:
            if (resultsCollection[i].Score !== resultsCollection[i].Score * 1) {
                throw {
                    name: 'Type Error',
                    message: 'Score is not a number'
                };
            }
            // Fill all IDs in an array with indices the IDs and values the count of their occurrences:
            if (!idsArray[resultsCollection[i].StudentID * 1]) {
                idsArray[resultsCollection[i].StudentID * 1] = 1;
            }
            else {
                idsArray[resultsCollection[i].StudentID * 1] += 1;
            }
        }
        // Check if a student ID is given more than once;
        if (idsArray.some(function (idCount) {
            return idCount > 1;
        })) {
            throw {
                name: 'Type Error',
                message: 'StudentID is given more than once'
            };
        }
    }

    var Course = {
        init: function (title, presentations) {
            this.title = title;
            this.presentations = presentations;
            this.students = [];

            return this;
        },
        addStudent: function (name) {
            var studentToAdd,
                studentId = this.students.length + 1;

            validateStudentName(name);

            studentToAdd = {
                firstname: name.split(' ')[0],
                lastname: name.split(' ')[1],
                id: studentId
            };
            this.students.push(studentToAdd);

            return studentId;
        },
        getAllStudents: function () {
            return this.students;
        },
        submitHomework: function (studentID, homeworkID) {
            checkIfIdIsNumber(studentID);
            checkIfIdIsNumber(homeworkID);
            if (!checkIfIdIsValid(studentID, this.students.length) ||
                !checkIfIdIsValid(homeworkID, this.presentations.length)) {
                throw {
                    name: 'Type Error',
                    message: 'Invalid ID - no such student or presentation'
                };
            }

            // Make a property in student 'homeworks' and push in it the homeworkID
            // to enable calculating the total results of a student, if tests appear for that;
        },
        pushExamResults: function (results) {
            validateExamResults(results);

            // Do some logic maybe;
        },
        getTopStudents: function () {
            // TODO: eventually;
        }
    };

    Object.defineProperty(Course, 'title', {
        get: function () {
            return this._title;
        },
        set: function (value) {
            validateTitle(value);
            this._title = value;

            return this;
        }
    });

    Object.defineProperty(Course, 'presentations', {
        get: function () {
            return this._presentations.slice();
        },
        set: function (value) {
            if (!Array.isArray(value) || value.length === 0) {
                throw {
                    name: 'Type Error',
                    message: 'Presentations parameter must be a non-empty array.'
                };
            }
            value.forEach(validateTitle);
            this._presentations = value;

            return this;
        }
    });

    return Course;
}

module.exports = solve;
