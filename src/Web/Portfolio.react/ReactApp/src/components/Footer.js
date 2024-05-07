// Footer.js
import React, { Component } from 'react';
import {NavLink} from "react-router-dom";

class Footer extends Component {
    
    render() {

        return (
            <footer className="border-top footer text-muted">
                <div className="container">
                    &copy; 2024 - Ali - <NavLink className="nav-link" to="/" activeClassName='active' exact>Home</NavLink>
                </div>
            </footer>
        );
    }
}

export default Footer;