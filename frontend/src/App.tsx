import { useState } from "react";
import "./App.css";

function App() {
  type Book = {
    title: string;
    authors: string[];
    pageCount: number | undefined;
    currentPage: number;
  };
  const [bookTitle, setBookTitle] = useState("");
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const [books, setBooks] = useState<any>();
  const [readingList, setReadingList] = useState<Book[]>([]);

  console.log(readingList);

  const queryBooks = async (title: string) => {
    const baseURL = "https://www.googleapis.com/books/v1/volumes?";
    const params = new URLSearchParams({
      q: title,
    });
    const fullURL = baseURL + params.toString();
    const response = await fetch(fullURL);
    const json = await response.json();
    setBooks(json);
  };

  return (
    <div>
      <label htmlFor="content">Book title: </label>
      <div>
        <input
          type="text"
          id="content"
          value={bookTitle}
          onChange={async (e) => {
            console.log(e.target.value);
            setBookTitle(e.target.value);
            if (e.target.value != "") {
              await queryBooks(e.target.value);
            }
          }}
        />
      </div>
      {books != undefined &&
        // eslint-disable-next-line @typescript-eslint/no-explicit-any
        books.items.slice(0, 5).map((b: any) => (
          <button
            onClick={() => {
              const book: Book = {
                title: b.volumeInfo.title,
                authors: b.volumeInfo.authors,
                pageCount: b.volumeInfo.pageCount,
                currentPage: 0,
              };
              readingList.push(book);
              setReadingList(readingList);
            }}
          >
            <b>{b.volumeInfo.title}</b>
            {b.volumeInfo.authors != undefined && (
              <> by {b.volumeInfo.authors.join(", ")}</>
            )}
          </button>
        ))}
    </div>
  );
}

export default App;
