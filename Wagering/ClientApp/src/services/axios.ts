import axios, { AxiosResponse, AxiosRequestConfig, AxiosError } from "axios";
import store from "@/store";

axios.interceptors.request.use(
    (request: AxiosRequestConfig) => {
        if (process.env.NODE_ENV == "development") {
            console.log("REQUEST", request);
        }
        if (store.getters.isAuthenticated) {
            request.headers.Authorization = `Bearer ${store.getters.token}`;
        }
        return request;
    },
    (e: AxiosError): Promise<AxiosError> => {
        if (process.env.NODE_ENV == "development") {
            console.log("ERROR", e);
        }
        return Promise.reject(e);
    }
);

axios.interceptors.response.use(
    (response: AxiosResponse) => {
        if (process.env.NODE_ENV == "development") {
            console.log("RESPONSE", response);
        }
        return response;
    },
    (e: AxiosError): Promise<AxiosError> => {
        if (process.env.NODE_ENV == "development") {
            console.log("ERROR", e);
        }
        if (e.response?.status == 401) {
            if (!window.location.href.includes("authentication"))
                window.location.href = "/authentication/login";
        }
        return Promise.reject(e);
    }
);

export default axios;
