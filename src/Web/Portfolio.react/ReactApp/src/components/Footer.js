// Footer.js
import React, { Component } from 'react';

class Footer extends Component {
    
    render() {

        return (
            <footer className="border-top footer text-muted">
                <div className="container">
                    &copy; 2024 - Ali - <a asp-area="" asp-controller="Home"
                                                       asp-action="Index">Home</a>
                </div>
            </footer>
        );
    }
}

export default Footer;