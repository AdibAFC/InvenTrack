import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Dashboard from './Pages/Dashboard';
import Users from './Pages/Users';
import Transactions from './pages/Transactions';

const AppRoutes = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Dashboard />} />
                <Route path="/users" element={<Users />} />
                <Route path="/transactions" element={<Transactions />} />
            </Routes>
        </Router>
    );
};

export default AppRoutes;
