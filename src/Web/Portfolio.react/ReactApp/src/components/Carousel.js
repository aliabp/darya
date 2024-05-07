// Carousel.js
import React, { Component } from 'react';
import axios from "axios";
import Config from 'config';

class Carousel extends Component {

    constructor(props) {
        super(props);
        this.state = {
            images: [],
            activeIndex: 0
        };
    }

    componentDidMount() {
        axios.get(Config.API_URL)
            .then(response => {
                const sortedImages = response.data;
                console.log(sortedImages);
                this.setState({ images: sortedImages });
            })
            .catch(error => {
                console.error('Error fetching data: ', error);
            });
    }

    render() {

        return (
            <div id="carouselExampleIndicators" className="carousel slide" data-bs-ride="carousel">
                <div className="carousel-indicators">
                    {this.state.images.map((image, index) => {
                        return (
                            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to={index}
                                    className={index === 0 ? 'active' : ''}  aria-current={index === 0 ? 'true' : ''} 
                                    aria-label={`Slide ${index}`} key={index}></button>
                        )
                    })}
                </div>
                <div className="carousel-inner">
                    {this.state.images.map((image, index) => {console.log("images:  " + image); console.log("images path:  " + image.path); console.log("images caption:  " + image.caption);
                        return (
                            <div className={`carousel-item ${index === 0 ? 'active' : ''}`} key={index}>
                                <img src={image.path} className="d-block w-100" alt={image.title}/>
                            </div>
                        )
                    })}
                </div>
                <button className="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                    <span className="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span className="visually-hidden">Previous</span>
                </button>
                <button className="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                    <span className="carousel-control-next-icon" aria-hidden="true"></span>
                    <span className="visually-hidden">Next</span>
                </button>
            </div>
        );
    }
}

export default Carousel;