import React, { useState, useEffect, useRef } from 'react'
import axios from 'axios'
import './ChatRoomScreen.css'
import * as signalR from '@microsoft/signalr'
function ChatRoomScreen() {
    const [room, setRoom] = useState([])
    const [messages, setMessages] = useState([])
    const [currentRoom, setcurrentRoom] = useState('')
    const [connectionSignalR, setConnectionSignalR] = useState({})

    const lastMessages = useRef(null);
    const lastRoom = useRef(null);
    lastMessages.current = messages;
    lastRoom.current = currentRoom;
    useEffect(() => {
        axios.get("http://localhost:5000/api/room")
            .then(p => {
                setRoom(p.data);
                setcurrentRoom(p.data[0]);
                getMessages(p.data[0].roomId)
            })
            .catch(e => console.error(e));

        // signalR
        let connection = new signalR.HubConnectionBuilder()
            .withUrl("http://localhost:5000/api/chat")
            .build();

        connection.on("RecievedMessage", data => {
            if (data.roomId === lastRoom.current.roomId) {
                setMessages([data, ...lastMessages.current]);
            }
            // console.log(data);
        });

        connection.start()
            .then(() => {
                // connection.invoke("sendMessage", "Hello")
            });
        setConnectionSignalR(connection);

    }, []);
    const getMessages = (roomId) => {
        axios.get(`http://localhost:5000/api/Message/ByRoom/${roomId}`)
            .then(p => setMessages(p.data))
            .catch(e => console.error(e));
    }
    const sendMessage = (event) => {
        if (event.key === 'Enter') {
            const name = sessionStorage.getItem('name');
            const message = { userName: name, content: event.target.value, roomId: currentRoom.roomId }

            axios.post("http://localhost:5000/api/Message", message)
                .then(() => {
                    setMessages([message, ...messages]);
                    connectionSignalR.invoke("SendMessage", message);
                    document.getElementsByClassName("chat-text")[0].value = '';
                })
                .catch(e => console.error(e));
        }
    }
    const changeRoom = (room) => {
        setcurrentRoom(room);
        getMessages(room.roomId);
    }
    return (
        <>
            <div><h1>Bienvenido a la sala de chat</h1></div>
            <div className="ed-container chat">
                <div className="s-10 chat-menu">
                    {room.map(item => {
                        return <button key={item.roomId} className={item.roomId === currentRoom.roomId ? "chat-menu__selected" : "chat-menu__option"} onClick={() => changeRoom(item)}># {item.name}</button>
                    })}
                </div>
                <div className="ed-item s-90">
                    <div className="chat-info">
                        {
                            messages.map(item => {
                                return <div key={item.messageId} className="chat-info__window">
                                    <span className="chat-info__user">{item.userName}:</span>
                                    <p className="chat-info_info">{item.content}</p>
                                </div>

                            })
                        }

                    </div>
                    <textarea className="chat-text" placeholder="Escriba un mensaje" onKeyUp={sendMessage}></textarea>
                </div>
            </div>
        </>
    )
}

export default ChatRoomScreen
