import React, { useState} from 'react';
import axios from 'axios'

function UserScreen() {
    const [userName, setUserName] = useState('');
    const saveUser = () => {
        sessionStorage.setItem("name", userName);

        axios.post("http://localhost:5000/api/LogBook", { userName: userName })
            .then(() => window.location.reload())
            .catch(e => console.error(e));
    }
    return (
        <div className="lg-50 lg-to-center s-border s-radius">
            <p className="s-pxy-2 s-mb-0">Welcome</p>
            <div className="s-bg-grey s-pxy-2">
                <input value={userName} onChange={e => { setUserName(e.target.value) }} className="s-pxy-1 s-cols-2" type="text"
                    placeholder="Ingrese nombre" />
                <button className="button" onClick={saveUser}>Ingresar</button>
            </div>
        </div>
    )
}

export default UserScreen;
