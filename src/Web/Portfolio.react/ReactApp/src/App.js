import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navbar from "./components/Navbar";
import Footer from "./components/Footer";
import Carousel from "./components/Carousel";
import About from "./components/About";

function App() {
    return (
        <>
            <Router>
                <Navbar/>
                <div className="container">
                    <main role="main" className="pb-3">
                        <Routes>
                            <Route path="/" element={<Carousel />} />
                            <Route path="/about" element={<About />} />
                        </Routes>
                    </main>
                </div>
                <Footer />
            </Router>
        </>
    );
}

export default App;