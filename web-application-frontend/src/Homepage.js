import { useEffect, useState } from "react";

const Homepage = () => {

    const [users, setUsers] = useState(null);

    useEffect(() => {
        fetch('https://localhost:44319/api/User')
            .then(res => {
                return res.json();
            })
            .then(data => {
                console.log(data)
                setUsers(data);

            });

    }, []);

    return (
        <div className="home">
            <h1>Users</h1>
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
                            </tr>
                        ))}
                    </tbody>
                </table>

            }
        </div>
    );
}

export default Homepage;