import useFetch from "./useFetch";
import {useHistory} from 'react-router-dom';

const Homepage = () => {

    const [data, setData, error] = useFetch('https://localhost:44319/api/User');
    const history = useHistory();

    const handleDelete = (id) => {
        fetch('https://localhost:44319/api/User/' + id, {
            method: 'DELETE'
        }).then(() => {
            window.location.reload(true)
        })
    }

    const showDetails = (id) => {
        history.push('/users/' + id);
    }

    return (
        <div className="home">
            <h1>Users</h1>
            {error && <div>{error}</div>}
            {data &&
                <table id="users">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Surname</th>
                            <th>Username</th>
                            <th>Email</th>
                            <th>Role</th>
                            <th>Address</th>
                            <th>&nbsp;</th>
                            <th>&nbsp;</th>
                        </tr>
                    </thead>
                    <tbody>
                        {data.map((user) => (
                            <tr key={user.id}>
                                <td>{user.id}</td>
                                <td>{user.name}</td>
                                <td>{user.surname}</td>
                                <td>{user.username}</td>
                                <td>{user.email}</td>
                                <td>{user.role}</td>
                                <td>{user.address.street}, {user.address.city}, {user.address.country}</td>
                                <td><button onClick={() => {handleDelete(user.id)}} className="delete-btn">Obrisi</button></td>
                                <td><button onClick={() => {showDetails(user.id)}}>Detalji</button></td>
                            </tr>
                        ))}
                    </tbody>
                </table>

            }
        </div>
    );
}

export default Homepage;