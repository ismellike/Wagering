﻿import axios from "axios";
import store from "@/store";

axios.interceptors.request.use(request => {
    if (process.env.NODE_ENV == "development") {
        console.log("REQUEST", request);
    }
    if (store.state.account.isAuthenticated) {
        request.headers.Authorization = `Bearer ${store.state.account.token}`;
    }
    return request;
}, function (err) {
    if (process.env.NODE_ENV == "development") {
        console.log("ERROR", err);
    }
    return Promise.reject(err);
});

axios.interceptors.response.use(response => {
    if (process.env.NODE_ENV == "development") {
        console.log("RESPONSE", response);
    }
    return response;
}, function (err) {
    if (process.env.NODE_ENV == "development") {
        console.log("ERROR", err);
    }
    if (err.response.status == 401) {
        if (!window.location.href.includes("authentication"))
            window.location = "/authentication/login";
    }
    return Promise.reject(err);
});

export default axios;