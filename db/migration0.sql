CREATE TABLE users (
    user_id serial PRIMARY KEY,
    username VARCHAR(30) NOT NULL
);

CREATE TABLE books (
    book_id serial PRIMARY KEY,
    page_count INT,
    title TEXT NOT NULL, 
    authors TEXT[]
);

CREATE TABLE user_books (
    user_id INT NOT NULL,
    book_id INT NOT NULL,
    page_no INT NOT NULL,
    PRIMARY KEY (user_id, book_id),
    FOREIGN KEY (user_id)
        REFERENCES users (user_id),
    FOREIGN KEY (book_id)
        REFERENCES books (book_id)
);