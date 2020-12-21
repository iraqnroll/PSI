import http from "./httpService";
import auth from "./authService";

const apiEndpoint = "https://localhost:5001/auth/register";
const apiEndpointDetails = "https://localhost:5001/auth/";

export function register(user) {
    return http.post(apiEndpoint, {
        email: user.username,
        password: user.password,
        username: user.name
    });

}

export function changeDetails(user) {
    return http.put(apiEndpointDetails, {
            email: user.username,
            password: user.password,
            username: user.name
    },
        auth.config
    );

}

export default {
    register, changeDetails
};