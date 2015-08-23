/* 
Create a function that:
*   Takes an array of students
    *   Each student has:
        *   `firstName`, `lastName` and `age` properties
        *   Array of decimal numbers representing the marks         
*   **finds** the student with highest average mark (there will be only one)
*   **prints** to the console  'FOUND_STUDENT_FULLNAME has an average score of MARK_OF_THE_STUDENT'
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/

function solve(){
  return function (students) {
      //var _ = require('underscore');

      var bestStudent = _.chain(students).map(function(student){
          student.fullName = student.firstName + ' ' + student.lastName;

          student.averageMark = _.reduce(student.marks, function(memo, num){
              return memo + num;
          }, 0)/ student.marks.length;
          return student;
      })
          .max(function(student){
              return student.averageMark;
          })
          .value();

      console.log(bestStudent.fullName + ' has an average score of ' + bestStudent.averageMark);
  };
}

module.exports = solve;
