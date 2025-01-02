import React from "react";
import "./App.css";

const App = () => {
  return (
    <div className="app-container">
      {/* Header */}
      <header className="app-header">
        <h1>Inventory Management System</h1>
        <div className="user-info">
          <span>Welcome, Adiba</span>
          <img
            src="https://via.placeholder.com/40"
            alt="User Avatar"
            className="avatar"
          />
        </div>
      </header>

      {/* Sidebar */}
      <aside className="app-sidebar">
        <nav>
          <ul>
            <li><a href="/dashboard">Dashboard</a></li>
            <li><a href="/users">Users</a></li>
            <li><a href="/transactions">Transactions</a></li>
            <li><a href="/settings">Settings</a></li>
          </ul>
        </nav>
      </aside>

      {/* Main Content */}
      <main className="app-content">
        <h2>Welcome to the Inventory Management System</h2>
        <p>Select a menu option from the sidebar.</p>
      </main>
    </div>
  );
};

export default App;
