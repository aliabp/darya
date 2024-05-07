// Navbar.js
import React, { Component } from 'react';
import { NavLink } from 'react-router-dom';

class Navbar extends Component {
    render() {
        const menuItems = [{ name: 'Home', path: '/' }, { name: 'About', path: '/about' }];
        return (
            <header>
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <div className="container-fluid">
                    <a className="navbar-brand" href="#">Ali Babaei</a>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse"
                            data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false"
                            aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarNav">
                        <ul className="navbar-nav">
                            {menuItems.map((item, index) => (
                                <li className="nav-item" key={index}>
                                    <NavLink className="nav-link"
                                             to={item.path}
                                             activeClassName='active'
                                             exact>
                                        {item.name}
                                    </NavLink>
                                </li>
                        ))}
                        </ul>
                    </div>
                </div>
            </nav>
            </header>
        );
    }
}

export default Navbar;