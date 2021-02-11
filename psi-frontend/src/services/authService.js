import jwtDecode from "jwt-decode";
import http from "./httpService";

const apiEndpoint = "https://localhost:5001/auth/login";
const tokenKey = "token";

//http.setJwt(getJwt());

export async function login(username, password) {
  const { data: jwt } = await http.post(apiEndpoint, { username, password });
  localStorage.setItem(tokenKey, jwt.data);
}

export function loginWithJwt(jwt) {
  localStorage.setItem(tokenKey, jwt);
}

export function logout() {
  localStorage.removeItem(tokenKey);
}

export function getCurrentUser() {
  try {
    const jwt = localStorage.getItem(tokenKey);
    return jwtDecode(jwt);
  } catch (ex) {
    return null;
  }
}

export function getJwt() {
  return localStorage.getItem(tokenKey);
}

export const config = {
  headers: { Authorization: `Bearer ${localStorage.getItem(tokenKey)}` },
};

export default {
  login,
  loginWithJwt,
  logout,
  getCurrentUser,
  getJwt,
  config,
};
