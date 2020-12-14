import http from "./httpService";

const apiEndpoint = "https://localhost:5001/auth/register";

export function register(user) {
    return http.post(apiEndpoint, {
        email: user.username,
        password: user.password,
        username: user.name
    });


}

export default {
    register
};