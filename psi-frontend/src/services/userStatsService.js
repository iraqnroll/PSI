import http from "./httpService";
import auth from "./authService";
import _, { filter } from "lodash";

const apiEndpoint = "https://localhost:5001/userstat";

export async function getShopFrequency() {
  let shops = await http.get(apiEndpoint + "/shops", auth.config);
  const newShops = shops.data.data.map((x) => mapShop(x));
  return newShops;
}

export async function getItemsFrequency() {
  let items = await http.get(apiEndpoint + "/items", auth.config);
  let data = _.orderBy(items.data.data, "itemFrequency", "desc");
  return data.slice(0, 5);
}

export async function getDates() {
  const datesRaw = await http.get(apiEndpoint + "/dates", auth.config);
  const filtered = _.orderBy(datesRaw.data.data, "date", "asc");

  let from = new Date(filtered[0].date);
  let to = new Date(filtered[filtered.length - 1].date);
  let mixed = [];
  let obj;
  let test;

  for (var d = from; d <= to; d.setDate(d.getDate() + 1)) {
    obj = filtered.find(
      (x) => new Date(x.date).getTime() === new Date(d).getTime()
    );

    if (obj) {
      for (var k = 1; k < 6; k++) {
        if (!obj.shopsVisited.find((x) => x.shop === k))
          obj.shopsVisited.push({ shop: k, amount: 0 });
      }
      mixed.push(obj);
    } else {
      mixed.push({
        date: new Date(d),
        shopsVisited: [
          { shop: 1, amount: 0 },
          { shop: 2, amount: 0 },
          { shop: 3, amount: 0 },
          { shop: 4, amount: 0 },
          { shop: 5, amount: 0 },
        ],
      });
    }
  }
  let dates = { Iki: [], Norfa: [], Lidl: [], Rimi: [], Maxima: [] };
  for (var i = 0; i < mixed.length; i++) {
    for (var j = 0; j < mixed[i].shopsVisited.length; j++) {
      dates[mapShop({ frequentShop: mixed[i].shopsVisited[j].shop }).name].push(
        {
          t: convertDate(mixed[i].date),
          y: mixed[i].shopsVisited[j].amount,
        }
      );
    }
  }
  const data = {
    datasets: [
      {
        label: "iki",
        data: dates.Iki,
        backgroundColor: "rgba(38, 70, 83, 0.2)",
        borderColor: "rgba(38, 70, 83, 1)",
      },
      {
        label: "maxima",
        data: dates.Maxima,
        backgroundColor: "rgba(42, 157, 143, 0.2)",
        borderColor: "rgba(42, 157, 143, 1)",
      },
      {
        label: "lild",
        data: dates.Lidl,
        backgroundColor: "rgba(233, 196, 106, 0.2)",
        borderColor: "rgba(233, 196, 106, 1)",
      },
      {
        label: "rimi",
        data: dates.Rimi,
        backgroundColor: "rgba(244, 162, 97, 0.2)",
        borderColor: "rgba(244, 162, 97, 1)",
      },
      {
        label: "norfa",
        data: dates.Norfa,
        backgroundColor: "rgba(231, 111, 81, 0.2)",
        borderColor: "rgba(231, 111, 81, 1)",
      },
    ],
  };

  return data;
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

function mapShop(item) {
  switch (item.frequentShop) {
    case 1:
      item["name"] = "Iki";
      break;
    case 2:
      item["name"] = "Norfa";
      break;
    case 3:
      item["name"] = "Rimi";
      break;
    case 4:
      item["name"] = "Lidl";
      break;
    case 5:
      item["name"] = "Maxima";
      break;
    default:
      item["name"] = "Not Found";
  }
  return item;
}
