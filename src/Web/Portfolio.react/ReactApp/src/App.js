import React from 'react';
import Navbar from "./components/Navbar";
import Footer from "./components/Footer";
import Carousel from "./components/Carousel";
function App() {
    return (
        <>
            <Navbar/>
            <div className="container">
                <main role="main" className="pb-3">
                    <Carousel />
                </main>
            </div>
            <Footer />
        </>
    );
}

export default App;