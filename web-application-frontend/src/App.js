import './App.css';
import Navbar from './Navbar';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom'
import Homepage from './Homepage';
import NewUser from './NewUser';
import UserDetails from './UserDetails';

function App() {
  return (
    <Router>
      <div>
        <div className="navbar">
          <Navbar></Navbar>
        </div>
        <div className="content">
          <Switch>
            <Route exact path = "/">
              <Homepage></Homepage>
            </Route>
            <Route path = "/new">
              <NewUser></NewUser>
            </Route>
            <Route path = "/users/:id">
              <UserDetails></UserDetails>
            </Route>
          </Switch>
        </div>
      </div>
    </Router>
  );
}

export default App;
