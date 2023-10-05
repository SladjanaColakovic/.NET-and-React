import { useState } from "react";
import { useHistory } from 'react-router-dom'


const NewUser = () => {
    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [email, setEmail] = useState('');
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [role, setRole] = useState('');
    const [city, setCity] = useState('');
    const [country, setCountry] = useState('');
    const [street, setStreet] = useState('');

    const history = useHistory();

    const handleClick = () => {
        let data = {
            name: name,
            surname: surname,
            email: email,
            username: username,
            password: password,
            role: role,
            city: city,
            country: country,
            street: street
        }

        fetch('https://localhost:44319/api/User/register', {
            method: 'POST',
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(data)
        }).then(res => {
            return res.json();
        }).then(data => {
            console.log(data);
        });

        history.push('/')

    }


    return (
        <div>
            <h1>Dodaj</h1>
            <div className="form-div">
                <label htmlFor="fname">Ime</label>
                <input type="text" id="fname" value={name} onChange={(e) => setName(e.target.value)} />

                <label htmlFor="lname">Prezime</label>
                <input type="text" id="lname" value={surname} onChange={(e) => setSurname(e.target.value)} />

                <label htmlFor="email">Email</label>
                <input type="text" id="email" value={email} onChange={(e) => setEmail(e.target.value)} />

                <label htmlFor="username">Username</label>
                <input type="text" id="username" value={username} onChange={(e) => setUsername(e.target.value)} />

                <label htmlFor="password">Password</label>
                <input type="text" id="password" value={password} onChange={(e) => setPassword(e.target.value)} />

                <label htmlFor="role">Role</label>
                <input type="text" id="role" value={role} onChange={(e) => setRole(e.target.value)} />

                <label htmlFor="city">City</label>
                <input type="text" id="city" value={city} onChange={(e) => setCity(e.target.value)} />

                <label htmlFor="country">Country</label>
                <input type="text" id="country" value={country} onChange={(e) => setCountry(e.target.value)} />

                <label htmlFor="street">Street</label>
                <input type="text" id="street" value={street} onChange={(e) => setStreet(e.target.value)} />

                <button onClick={handleClick}>Dodaj</button>

            </div>
        </div>
    );
}

export default NewUser;