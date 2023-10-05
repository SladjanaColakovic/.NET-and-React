import useFetch from "./useFetch";

const Homepage = () => {

    const {data: users, error} = useFetch('https://localhost:44319/api/User');

    const handleDelete = (id) => {
        fetch('https://localhost:44319/api/User/' + id, {
            method: 'DELETE'
        }).then(() => {
            window.location.reload(true)
        })
    }

    return (
        <div className="home">
            <h1>Users</h1>
            {error && <div>{error}</div>}
            {users &&
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
                        </tr>
                    </thead>
                    <tbody>
                        {users.map((user) => (
                            <tr key={user.id}>
                                <td>{user.id}</td>
                                <td>{user.name}</td>
                                <td>{user.surname}</td>
                                <td>{user.username}</td>
                                <td>{user.email}</td>
                                <td>{user.role}</td>
                                <td>{user.address.street}, {user.address.city}, {user.address.country}</td>
                                <td><button onClick={() => {handleDelete(user.id)}} className="delete-btn">Obrisi</button></td>
                            </tr>
                        ))}
                    </tbody>
                </table>

            }
        </div>
    );
}

export default Homepage;