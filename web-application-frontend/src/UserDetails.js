import useFetch from "./useFetch";
import { useParams } from 'react-router-dom';
import { useHistory } from 'react-router-dom'

const UserDetails = () => {

    const { id } = useParams();
    const history = useHistory();

    const [user, setUser, error] = useFetch('https://localhost:44319/api/User/one/' + id);

    const handleChange = () => {
        let editedUser = {
            id: id,
            name: user.name,
            surname: user.surname,
            email: user.email,
            username: user.username,
            password: user.password,
            role: user.role
        }
        fetch('https://localhost:44319/api/User', {
            method: 'PUT',
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(editedUser)
            }).then((res) => {
            return res.json();
            })
            .then((data) => {
                console.log(data);
                history.push('/')
            })
    }


    return (
        <div>
            <h1>Detalji i izmjena</h1>
            <div className="form-div">
                <label htmlFor="fname">Ime</label>
                {user && <input type="text" id="fname" value={user.name} onChange={(e) => { setUser({ ...user, name: e.target.value }) }} />}

                <label htmlFor="lname">Prezime</label>
                {user && <input type="text" id="lname" value={user.surname} onChange={(e) => { setUser({ ...user, surname: e.target.value }) }} />}

                <label htmlFor="email">Email</label>
                {user && <input type="text" id="email" value={user.email} onChange={(e) => { setUser({ ...user, email: e.target.value }) }} />}

                <label htmlFor="username">Username</label>
                {user && <input type="text" id="username" value={user.username} onChange={(e) => { setUser({ ...user, username: e.target.value }) }} />}

                <label htmlFor="password">Password</label>
                {user && <input type="text" id="password" value={user.password} onChange={(e) => { setUser({ ...user, password: e.target.value }) }} />}

                <label htmlFor="role">Role</label>
                {user && <input type="text" id="role" value={user.role} onChange={(e) => { setUser({ ...user, role: e.target.value }) }} />}

                <label htmlFor="city">City</label>
                {user && <input type="text" id="city" value={user.address.city} onChange={(e) => { setUser({ ...user, address: { ...user.address, city: e.target.value } }) }} />}

                <label htmlFor="country">Country</label>
                {user && <input type="text" id="country" value={user.address.country} onChange={(e) => { setUser({ ...user, address: { ...user.address, country: e.target.value } }) }} />}

                <label htmlFor="street">Street</label>
                {user && <input type="text" id="street" value={user.address.street} onChange={(e) => { setUser({ ...user, address: { ...user.address, street: e.target.value } }) }} />}

                <button onClick={handleChange}>Izmijeni</button>

            </div>
        </div>
    );
}

export default UserDetails;