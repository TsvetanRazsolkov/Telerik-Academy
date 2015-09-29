<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
>
  <xsl:template match="/students">
    <html>
      <body>
        <h1>Some Students</h1>
        <table bgcolor="#E0E0E0" cellspacing="1">
          <thead>
            <tr bgcolor="#EEEEEE">
              <th>Student name</th>
              <th>Gender</th>
              <th>Date of birth</th>
              <th>Phone</th>
              <th>Email</th>
              <th>Course</th>
              <th>Specialty</th>
              <th>Faculty number</th>
              <th>Exams</th>
              <th>Enrollment Information</th>
            </tr>
          </thead>
          <tbody>
            <xsl:for-each select="student">
              <tr bgcolor="white">
                <td>
                  <xsl:value-of select="name"/>
                </td>
                <td>
                  <xsl:value-of select="gender"/>
                </td>
                <td>
                  <xsl:value-of select="birthDate"/>
                </td>
                <td>
                  <xsl:value-of select="phone"/>
                </td>
                <td>
                  <xsl:value-of select="email"/>
                </td>
                <td>
                  <xsl:value-of select="course"/>
                </td>
                <td>
                  <xsl:value-of select="specialty"/>
                </td>
                <td>
                  <xsl:value-of select="facultyNumber"/>
                </td>
                <td>
                  <xsl:for-each select="exams/exam">
                    <div>
                      <p>
                        <xsl:value-of select="name"/>
                      </p>
                      <p>
                        <span>tutor: </span>
                        <xsl:value-of select="tutor"/> 
                      </p>
                      <p>
                        <span>score: </span>
                        <xsl:value-of select="examScore"/>
                      </p>                      
                    </div>
                  </xsl:for-each>
                </td>
                <td>
                    <div>
                      <p>
                        <span>Date of enrollment: </span>
                        <xsl:value-of select="enrollmentInfo/enrollmentDate"/>                        
                      </p>
                      <p>
                        <span>Exam score: </span>
                        <xsl:value-of select="enrollmentInfo/examScore"/>
                      </p>
                      <p>
                        <span>Teacher endorsement: </span>
                        <xsl:value-of select="enrollmentInfo/teacherEndorsement"/>
                      </p>
                    </div>
                </td>
              </tr>
            </xsl:for-each>
          </tbody>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
