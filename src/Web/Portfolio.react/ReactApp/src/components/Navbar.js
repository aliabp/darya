// Navbar.js
import React, { Component } from 'react';

class Navbar extends Component {
    constructor(props) {
        super(props);
        this.state = {
            activeIndex: 0
        };
    }

    handleItemClick = (index) => {
        this.setState({ activeIndex: index });
    }

    render() {
        const menuItems = ['Home', 'Features', 'Pricing', 'Disabled'];

        return (
            <header>
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <div className="container-fluid">
                    <a className="navbar-brand" href="#">Navbar</a>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse"
                            data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false"
                            aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarNav">
                        <ul className="navbar-nav">
                            {menuItems.map((item, index) => (
                                <li className="nav-item" key={index}>
                                    <a className={`nav-link ${this.state.activeIndex === index ? 'active' : ''}`}
                                       onClick={() => this.handleItemClick(index)}
                                       href="#">
                                        {item}
                                    </a>
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