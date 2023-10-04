import './App.css';
import Navbar from './Navbar';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom'
import Homepage from './Homepage';

function App() {
  return (
    <Router>
      <div>
        <div className="navbar">
          <Navbar></Navbar>
        </div>
        <div className="content">
          <Switch>
            <Route path = "/">
              <Homepage></Homepage>
            </Route>
          </Switch>
        </div>
      </div>
    </Router>
  );
}

export default App;
