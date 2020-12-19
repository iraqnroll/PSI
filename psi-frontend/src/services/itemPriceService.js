import http from "./httpService";
import auth from "./authService";

const apiEndpoint = "https://localhost:5001/itemPrice";

export async function updateItemPrice(id, itemId, price, receiptId) {
  await http.put(
    apiEndpoint,
    { id: id, itemId: itemId, price: price, receiptId: receiptId },
    auth.config
  );
}

export async function addItemPrice(itemId, price, receiptId) {
  await http.post(
    apiEndpoint,
    { itemId: itemId, price: price, receiptId: receiptId },
    auth.config
  );
}

export async function deleteItemPrice(itemId) {
  await http.delete(apiEndpoint + "/" + itemId, auth.config);
}
