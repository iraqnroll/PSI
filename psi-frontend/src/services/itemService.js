import http from "./httpService";
import auth from "./authService";

const apiEndpoint = "https://localhost:5001/item";

export async function getItems() {
  const items = await http.get(apiEndpoint + "/all", auth.config);
  return items.data.data;
}
