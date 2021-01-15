import React, { useState } from 'react';
import "./style/style.scss"
import axios from 'axios'
import UserScreen from './Components/UserScreen';
import ChatRoomScreen from './Components/ChatRoomScreen';
function App() {
  const [message, setMessage] = useState('')
  axios.get(`https://localhost:5001/api/hello`)
    .then(p => setMessage(p.data));
  if (sessionStorage.getItem('name') && sessionStorage.getItem('name') !== '') {
    return (
      <ChatRoomScreen />
    );
  } else {
    return (

      <div className="App">
        <h1>{message}</h1>
        <UserScreen />
      </div>
    );
  }
}

export default App;
