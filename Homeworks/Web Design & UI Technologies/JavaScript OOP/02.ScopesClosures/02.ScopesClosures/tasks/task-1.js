/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/
function solve() {
    var library = (function () {
        var books = [];
        var categories = [];

        function listBooks(optionalParameter) {
            var booksList = [];

            if (optionalParameter && optionalParameter.author) {
                booksList = books.filter(function (item) {
                    return item.author === optionalParameter.author;
                }).sort(function (x, y) {
                    return x.ID - y.ID;
                });

                return booksList;
            }
            if (optionalParameter && optionalParameter.category) {
                booksList = books.filter(function (item) {
                    return item.category === optionalParameter.category;
                }).sort(function (x, y) {
                    return x.ID - y.ID;
                });

                return booksList;
            }

            booksList = books.slice();

            return booksList;
        }

        function validateBookOrCategoryName(name) {
            var i,
                len = name.length;
            if (typeof name !== 'string') {
                throw new Error('Name type is not string');
            }
            if (name.length < 2 || name.length > 100) {
                throw new Error('Invalid name length');
            }
        }

        function validateISBN(isbn) {
            var i,
                len = isbn.length,
                isbnStr = isbn.toString();

            if (len !== 10 && len !== 13) {
                throw new Error('ISBN length is not correct.');
            }

            for (i = 0; i < len; i += 1) {
                if (!(isbnStr.charCodeAt(i) >= 48 && isbnStr.charCodeAt(i) <= 57)) {
                    throw new Error('Invalid ISBN characters');
                }
            }
			
            if (books.some(function (item) {
                    return item.isbn === isbn;
            })) {
                throw new Error('Not unique ISBN');
            }
        }

        function validateBook(book) {

            validateBookOrCategoryName(book.title);

            if (books.some(function (item) {
                    return item.title === book.title;
            })) {
                throw new Error('Not unique book title');
            }

            if (typeof book.author !== 'string' || book.author.length < 1) {
                throw new Error('Invalid author name');
            }

            validateISBN(book.isbn);
        }

        function addCategory(newCategory) {
            categories.push({
                name: newCategory,
                ID: categories.length + 1
            });
        }

        function addBook(book) {

            validateBook(book);
            validateBookOrCategoryName(book.category);

            if (!categories.some(function (category) {
                    return category.name === book.category;
            })) {
                addCategory(book.category);
            }

            book.ID = books.length + 1;

            books.push(book);

            return book;
        }

        function listCategories() {
            var categoriesList = categories.slice()
                                           .map(function (item) {
                                               return item.name;
                                           });

            return categoriesList;
        }

        return {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };
    }());

    return library;
}

module.exports = solve;