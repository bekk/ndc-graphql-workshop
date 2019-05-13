import React from 'react';
import './App.css';

const fetchCharacters = async () => {
  const query = `query Query { characters { name } }`;

  try {
    await fetch('http://localhost:4000/', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
      },
      body: JSON.stringify({ query })
    })
  } catch (e) {
    console.log(e);
  }
};

function App() {

  return (
    <div>
      <button onClick={() => fetchCharacters()}>
        Fetch characters
      </button>
    </div>
  );
}

export default App;
