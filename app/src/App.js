import React,{useState} from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios' 
function App() {
  const [message, setMessage] = useState('')
  axios.get(`https://localhost:5001/api/hello`)
  .then(p=> setMessage(p.data));
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <h1>{message}</h1>
      </header>
    </div>
  );
}

export default App;
