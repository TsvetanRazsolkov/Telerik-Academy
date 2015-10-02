## Database Systems - Overview
### _Homework_

#### Answer following questions in Markdown format (`.md` file)

 

 1. - What database models do you know?

 
 A database model is a type of data model that determines the logical structure of a database and fundamentally determines in which manner data can be stored, organized, and manipulated. 
 - Hierarchical database model - A hierarchical database model is a data model in which the data is organized into a tree-like structure. The data is stored as records which are connected to one another through links. A record is a collection of fields, with each field containing only one value. The entity type of a record defines which fields the record contains. The hierarchical database model mandates that each child record has only one parent, whereas each parent record can have one or more child records. In order to retrieve data from a hierarchical database the whole tree needs to be traversed starting from the root node. 
 - Network model - The network model is a database model conceived as a flexible way of representing objects and their relationships. While the hierarchical database model structures data as a tree of records, with each record having one parent record and many children, the network model allows each record to have multiple parent and child records, forming a generalized graph structure.
 - Relational model - In the relational model of a database, all data is represented in terms of tuples, grouped into relations.
 - Entity–relationship model - An entity–relationship model is the result of using a systematic process to describe and define a subject area of business data. It does not define business process; only visualize business data. The data is represented as components (entities) that are linked with each other by relationships that express the dependencies and requirements between them, such as: one building may be divided into zero or more apartments, but one apartment can only be located in one building. Entities may have various properties (attributes) that characterize them. An ER model is typically implemented as a database. In the case of a relational database, which stores data in tables, every row of each table represents one instance of an entity. Some data fields in these tables point to indexes in other tables; such pointers are the physical implementation of the relationships.
 - Object database - An object database is a database management system in which information is represented in the form of objects as used in object-oriented programming. Object databases are different from relational databases which are table-oriented.
 - Document-oriented database - A document-oriented database or document store is a computer program designed for storing, retrieving, and managing document-oriented information, also known as semi-structured data. Document-oriented databases are one of the main categories of NoSQL databases
 - Entity–attribute–value model - Entity–attribute–value model (EAV) is a data model to describe entities where the number of attributes (properties, parameters) that can be used to describe them is potentially vast, but the number that will actually apply to a given entity is relatively modest.
 - Object-relational database - An object-relational database (ORD) is a database management system (DBMS) similar to a relational database, but with an object-oriented database model: objects, classes and inheritance are directly supported in database schemas and in the query language.



2.-  Which are the main functions performed by a 
Relational Database Management System (RDBMS)?

  The main functions performed by a RDBMS are management of the data. This includes Creating / altering / deleting tables and relationships between them (database schema), adding, hanging, deleting, searching and retrieving of data stored in the tables. It also supports the SQL language and manages transactions (or most of them).
  

3.- Define what is "table" in database terms.

 Database tables consist of data, arranged in rows and columns. All rows have the same structure. Columns have name and type (number, string, date, image, or other). Each row is identified by one or more values appearing in a particular column subset.

4.-  Explain the difference between a primary and a foreign key.

Primary key is a column of the table that uniquely identifies its rows (usually it is a number). The foreign key is an identifier of a record located in another table (usually its primary key).
Primary keys can not have value null, while foreign keys can.

5.- Explain the different kinds of relationships between tables in relational databases.

 - One-to-many (or many-to-one) - a single record in the first table has many corresponding records in the second table.
 - Many-to-many - records in the first table have many corresponding records in the second one and vice versa. Implemented through additional table.
 - One-to-one - a single record in a table corresponds to a single record in the other table. Used to model inheritance between tables

6.- When is a certain database schema normalized? What are the advantages of normalized databases?

Normalization of the relational schema removes repeating data. The advantages are that by having less data repeated the overall storage space consumed by the database is less and the better performance.

7.- What are database integrity constraints and when are they used?

Database integrity constraints are rules that ensure that the data entered in the database is valid (by setting those validations rules in advance). For example we can constrain a name to not be more than 50 symbols or to be valid only if it is "Pesho". When we try to save incorrect data into the DB we will get an error instead of invalid data.

8.- Point out the pros and cons of using indexes in a database.

- pros: 
Fast search
- cons:
Potentially slower writing, due to the necessity of the indexing structure to rearrange from time to time as new data is inserted.
More disk space.

9.- What's the main purpose of the SQL language?

SQL is used for manipulation of relational databases. It supports creating, altering, deleting tables and other objects in the database as well as searching, retrieving, inserting, modifying and deleting table data (rows) and many others.

10.-   What are transactions used for? Give an example.

Transactions are used to execute several actions as one. We want to execute all the actions and not only half of them. If any of them fails we want to roll-back the effects of the previously executed actions – in other words if 2 of 3 actions execute and the 3rd throws an error, we don’t want to save the changes done by actions 1 and 2. For example when we draw money, we want to change our balance, get the money physically and keep a log for the transactions. If any of these actions fails, we don’t want to lose this money, as the new balance is saved in step 1.

11.- What is a NoSQL database?

NoSQL database uses document-based model. It’s main idea is to be non-relational. It still supports CRUD operations but holds all the relevant information for an entity in a single document, instead of joining several tables to extract this information.

12.-  Explain the classical non-relational data models.

Non-relational data models store all the information regarding an entity in a single file – imagine all the details for a person (name, age,  address, town, country etc.) in a single file. This way no joins or lookups in different files are required. In comparison in the relational data model you will have to extract information from each table (names, addresses, towns, countries etc.) and join them, to acquire all the information for that person.

13.- Give few examples of NoSQL databases and their pros and cons.

 - MongoDB
+ pros
-Sharding and Load-Balancing - sharding is the process of storing data records across multiple machines and is MongoDB's approach to meeting the demands of data growth.
-Speed - this advantage only exists when your data is truly a document. When your data is essentially emulating a relational model, your code ends up performing many independent queries in order to retrieve a single document and can become much slower than a classic RDBMS.
-Flexibility - MongoDB doesn't require a unified data structure across all objects, so when it is not possible to ensure that your data will all be structured consistently, MongoDB can be much simpler to use than an RDBMS.
+ cons
-No Joins - In MongoDB there exists no possibility for joins like in a relational database. This means that when you need this type of functionality, you need to make multiple queries and join the data manually within your code (which can lead to slow, ugly code, and reduced flexibility when the structure changes).
-Memory Usage - MongoDB has the natural tendency to use up more memory because it has to store the key names within each document. Additionally you're stuck with duplicate data since there is no possibility for joins, or slow queries due to the need to perform the join within your code.
-Concurrency Issues - When you perform a write operation in MongoDB, it creates a lock on the entire database, not just the affected entries, and not just for a particular connection. This lock blocks not only other write operations, but also read operations.
-Transactions - MongoDB doesn't automatically treat operations as transactions. In order to ensure data integrity upon create/update you have to manually choose to create a transaction, manually verify it, and then manually commit or rollback.
-Young Software: Inexperienced User-Base; Still Under Construction; Little Documentation

 - Redis
+ pros
-Speed - Redis is a high performance persistence key value In-memory data store, typically used for  applications where performance and flexibility are more critical than persistence and absolute data integrity .
+ cons
-Memory limitation -  Redis is an in memory datastore, so you can't store more data than the RAM of the system, where it is being deployed.
-Risk of loosing data - Redis does persist to disk, but it doesn't synchronously store data to disk as you write it. For persistence, Redis gives two options:
1) The RDB persistence performs point-in-time snapshots of your dataset at specified intervals. Configured in conf file at setup.
2) the AOF persistence logs every write operation received by the server, that will be played again at server startup, reconstructing the original dataset.
 - CouchDB
+ pros: 
-Simplicity - You can store any JSON data, and each document can have any number of binary attachments.
-Thanks to map/reduce, querying data is somewhat separated from the data itself. This means that you can index deeply within your data, and on whether or not something exists, and across types, without paying a significant penalty. You just need to write your view functions to handle them.
 + cons:
-Arbitrary queries are expensive. To do a query that you haven't created a view for, you need to create a temporary view. 
-Space usage.


