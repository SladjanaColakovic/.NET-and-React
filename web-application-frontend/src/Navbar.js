const Navbar = () => {
    return (
        <div>
            <ul>
                <li><a className="active" href="/">Homepage</a></li>
                <li><a href="/new">Dodaj</a></li>
                <li><a href="#contact">Contact</a></li>
                <li><a href="#about">About</a></li>
            </ul>
        </div>
    );
}

export default Navbar;