import axios from 'axios';

const API = axios.create({
    baseURL: 'https://localhost:7192/api', // Backend API URL
});

// Add token to request headers if needed
API.interceptors.request.use((config) => {
    const token = localStorage.getItem('token'); // Get token from local storage
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});

export default API;
