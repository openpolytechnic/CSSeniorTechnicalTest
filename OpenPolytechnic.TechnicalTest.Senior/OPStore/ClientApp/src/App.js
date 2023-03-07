
import React from "react";
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Navbar from './components/Navbar'
import './css/tailwind.css'
import Order from "./components/Order";
import Menu
    from "./components/Menu";
import Home from "./components/Home";

const App = () => {
    return (
        <Router>
            <div className="bg-gray-100 min-h-screen">
                <Navbar />
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/Menu" element={<Menu />} />
                    <Route path="/Order" element={<Order />} />
                </Routes>
            </div>
            
        </Router>
    );
};

export default App;
