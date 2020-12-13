import authService from "./authService";
import http from "./httpService";
import auth from "./authService";

const apiEndpoint = "https://localhost:5001/receipt";

export async function getReceipts() {
  const receipts = await http.get(apiEndpoint + "/all", auth.config);
  const mapped = receipts.data.data.map((receipt) => ({
    id: receipt.id,
    shop: mapShop(receipt.shop),
    date: formatDate(new Date(receipt.date)),
    sum: totalSum(receipt.itemPrices),
  }));
  return mapped;
}

export function deleteReceipt(id) {
  return http.delete(apiEndpoint + "/" + id, auth.config);
}

export async function getReceipt(id) {
  const receipt = await http.get(apiEndpoint + "/" + id, auth.config);
  const mapped = receipt.data.data.itemPrices.map((itemPrice) => ({
    id: itemPrice.id,
    name: itemPrice.item.name,
    type: mapType(itemPrice.item.type),
    price: itemPrice.price,
  }));
  return mapped;
}

function mapShop(id) {
  let name = "Not Found";
  switch (id) {
    case 1:
      name = "Iki";
      break;
    case 2:
      name = "Norfa";
      break;
    case 3:
      name = "Rimi";
      break;
    case 4:
      name = "Lidl";
      break;
    case 5:
      name = "Maxima";
      break;
  }
  return name;
}

function mapType(id) {
  let type = "Not Found";
  switch (id) {
    case 1:
      type = "Mesos gaminiai";
      break;
    case 2:
      type = "Juros gerybes";
      break;
    case 3:
      type = "Kepiniai";
      break;
    case 4:
      type = "Darzoves";
      break;
    case 5:
      type = "Vaisiai";
      break;
    case 6:
      type = "Pieno produktai";
      break;
    case 7:
      type = "Gerimai";
      break;
    case 8:
      type = "Saldumynai";
      break;
    case 9:
      type = "Uzkandziai";
      break;
  }
  return type;
}

function totalSum(prices) {
  return prices.map((a) => a.price).reduce((a, b) => a + b, 0);
}

function formatDate(date) {
  var d = new Date(date),
    month = "" + (d.getMonth() + 1),
    day = "" + d.getDate(),
    year = d.getFullYear();

  if (month.length < 2) month = "0" + month;
  if (day.length < 2) day = "0" + day;

  return [year, month, day].join("-");
}
