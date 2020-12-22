import authService from "./authService";
import http from "./httpService";
import auth from "./authService";

const apiEndpoint = "https://localhost:5001/ShoppingCart";
const apiEndpointa = "https://localhost:5001/item/";
const shopCart = {Cart: [121, 131, 141]};
export async function getDeals() {
  
  const names = await http.get(apiEndpointa + "all", auth.config);

   
  const cart = await http.get(apiEndpoint + "/deals", auth.config);
  const mapped = cart.data.data.map( ((cart ) => ({
    id: cart.id + cart.shop,
    name: getItemName(cart.id, names.data.data),
    shop: mapShop(cart.shop),
    date: formatDate(new Date(cart.date)),
    price: cart.price
  })));

  return mapped;
}
export async function getShoppingCart(shopCart) {
  const names = await http.get(apiEndpointa + "all", auth.config);
  const cart = await http.post(apiEndpoint + "/best", { Cart: shopCart});
  const mapped = cart.data.data.map(((cart) => makeItem(cart, names)));

  return mapped;
}
export async function getShoppingCartC(selected,shopCart) {
  console.log(selected.length );
  if (selected.length != 0) 
  {
    var str;
    console.log(makeShoppingList(selected));
    str = makeShoppingList(selected);
    console.log(str);
    const names = await http.get(apiEndpointa + "all", auth.config);
    const cart = await http.post(apiEndpoint + "/bestC?" + str, { Cart: shopCart });
    const mapped = cart.data.data.map(((cart) => makeItem(cart, names)));

    return mapped;
  } else
    return getShoppingCart(shopCart);
}
function makeShoppingList(selected) {
  var line = "";
  for (var i = 0; i < selected.length; i++){
    line =line + "shops=" + selected[i] + "&";
  }
  return line;
}

function makeItem(cart, names) {
  if (cart != null) {
    return ({
      name: getItemName(cart.id, names.data.data),
      shop: mapShop(cart.shop),
      date: formatDate(new Date(cart.date)),
      price: cart.price
    });
  }
  return ({
      name: "Item not found in any of the selected stores.",
      shop: "",
      date: "",
      price: ""
    });
}



function getItemName(id, names) {
  const na = (names.filter(item => item.id === id))[0].name; 
  return na;
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