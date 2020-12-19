import http from "./httpService";
import auth from "./authService";
import _ from "lodash";

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

export async function getPriceHistory(itemId) {
  const raw = await http.get(apiEndpoint + "/prices/" + itemId, auth.config);
  const filtered = _.orderBy(raw.data.data.prices, "date", "asc");
  let prices = filtered;
  let data = { Iki: [], Norfa: [], Lidl: [], Rimi: [], Maxima: [] };
  for (var i = 0; i < prices.length; i++) {
    data[mapShop(prices[i].shop)].push({
      t: convertDate(prices[i].date),
      y: prices[i].price,
    });
  }

  const result = {
    datasets: [
      {
        label: "iki",
        data: data.Iki,
        backgroundColor: "rgba(38, 70, 83, 0.2)",
        borderColor: "rgba(38, 70, 83, 1)",
      },
      {
        label: "maxima",
        data: data.Maxima,
        backgroundColor: "rgba(42, 157, 143, 0.2)",
        borderColor: "rgba(42, 157, 143, 1)",
      },
      {
        label: "lild",
        data: data.Lidl,
        backgroundColor: "rgba(233, 196, 106, 0.2)",
        borderColor: "rgba(233, 196, 106, 1)",
      },
      {
        label: "rimi",
        data: data.Rimi,
        backgroundColor: "rgba(244, 162, 97, 0.2)",
        borderColor: "rgba(244, 162, 97, 1)",
      },
      {
        label: "norfa",
        data: data.Norfa,
        backgroundColor: "rgba(231, 111, 81, 0.2)",
        borderColor: "rgba(231, 111, 81, 1)",
      },
    ],
  };
  return result;
}

export async function deleteItemPrice(itemId) {
  await http.delete(apiEndpoint + "/" + itemId, auth.config);
}

function convertDate(date) {
  const newDate = formatDate(new Date(date));
  return newDate;
}

export function formatDate(date) {
  var d = new Date(date),
    month = "" + (d.getMonth() + 1),
    day = "" + d.getDate(),
    year = d.getFullYear();

  if (month.length < 2) month = "0" + month;
  if (day.length < 2) day = "0" + day;

  return [year, month, day].join("-");
}

function mapShop(id) {
  switch (id) {
    case 1:
      id = "Iki";
      break;
    case 2:
      id = "Norfa";
      break;
    case 3:
      id = "Rimi";
      break;
    case 4:
      id = "Lidl";
      break;
    case 5:
      id = "Maxima";
      break;
    default:
      id = "Not Found";
  }
  return id;
}
