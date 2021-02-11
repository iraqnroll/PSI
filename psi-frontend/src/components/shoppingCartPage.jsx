import React, { Component } from "react";
import { getDeals,getShoppingCart,getShoppingCartC } from "../services/shoppingCartService";
import ListGroup from "./common/listGroup";
import ShoppingCartTable from "./shoppingCartTable";
import _ from "lodash";
import Pagination from "./common/pagination";
import { withRouter } from "react-router-dom";

class ShoppingCartPage extends Component {
  state = {
    receipts: [],
    sortColumn: { path: "Shop", order: "asc" },
    shops: [],
    selectedShop: null,
    pageSize: 10,
    activePage: 1,
  };

  async componentDidMount() {
    const receipts = await getShoppingCart({Cart: [0]});
    const shops = [
      { id: 0, name: "All Shops" },
      { id: 1, name: "Iki" },
      { id: 2, name: "Norfa" },
      { id: 3, name: "Rimi" },
      { id: 4, name: "Lidl" },
      { id: 5, name: "Maxima" },
    ];
    this.setState({ receipts, shops });
  }

  handleShopSelect = (shop) => {
    this.setState({ selectedShop: shop });
  };

  handleSort = (sortColumn) => {
    this.setState({ sortColumn });
  };
   handleSort = (receipts) => {
    this.setState({ receipts });
  };
  

  handlePageChange = (page) => {
    this.setState({ activePage: page });
  };

  handleInfo(props) {
    props.history.push("/");
  }
  

  paginate(items, pageNumber, pageSize) {
    const startIndex = (pageNumber - 1) * pageSize;
    return _(items).slice(startIndex).take(pageSize).value();
  }
  getPagedData() {
    const {
      activePage,
      pageSize,
      receipts: allReceipts,
      selectedShop,
      sortColumn,
    } = this.state;

    let filtered = allReceipts;
    if (selectedShop && selectedShop.id !== 0)
      filtered = allReceipts.filter(
        (receipt) => receipt.shop === selectedShop.name
      );
    
    const sorted = _.orderBy(filtered, [sortColumn.path], [sortColumn.order]);

    const receipts = this.paginate(sorted, activePage, pageSize);
    return { totalCount: filtered.length, data: receipts };
  }

  getSelectedShops() {
    return [
      {shop: 1,selected: document.getElementById("CheckIki").checked},
      {shop: 2,selected: document.getElementById("CheckNorfa").checked},
      {shop: 3 ,selected: document.getElementById("CheckRimi").checked },
      {shop: 4,selected: document.getElementById("CheckLidl").checked},
      { shop: 5,selected: document.getElementById("CheckMaxima").checked }
    ];
  }
  async buttonClick(Datacart) {
    const shopCart = Datacart.itemPrices.map((x) => (
      x.item.id
    ));
    const stores = this.getSelectedShops();
    const filter = stores.filter((store) => store.selected == true);
    const selected = filter.map((cart) => (cart.shop));
    const cart = await getShoppingCartC(selected, shopCart);

    this.setState({ receipts: cart });
    
  }


  render() {
    const { sortColumn, pageSize, activePage } = this.state;
    const { totalCount, data: receipts } = this.getPagedData();
    const { cart } = this.props;
    return (
      <div>
        <button 
            className="btn btn-secondary btn-lg"
          onClick={() => this.buttonClick(cart)}
          style ={{borderColor : "rgb(255, 182, 26)",color : "rgb(36, 29, 21)" ,backgroundColor: "rgb(255, 223, 26)", marginTop :"5px",marginBottom :"5px"}}
        >
              Find Deals
        </button>     
        <div class="form-check form-check-inline" style={{float: 'right'}} >
          <input class="form-check-input" type="checkbox" id="CheckIki" value="option1" />
            <label class="form-check-label" for="CheckIki" style={{marginRight : "10px"}}>Iki   </label>
      
            <input class="form-check-input" type="checkbox" id="CheckNorfa" value="option1"/>
            <label class="form-check-label" for="CheckNorfa" style={{marginRight : "10px"}}>Norfa </label>
     
            <input class="form-check-input" type="checkbox" id="CheckRimi" value="option1"/>
            <label class="form-check-label" for="CheckRimi" style={{marginRight : "10px"}}>Rimi   </label>
        
            <input class="form-check-input" type="checkbox" id="CheckLidl" value="option1"/>
            <label class="form-check-label" for="CheckLidl" style={{marginRight : "10px"}}>Lidl   </label>
            <input class="form-check-input" type="checkbox" id="CheckMaxima" value="option1"/>
            <label class="form-check-label" for="CheckMaxima" style={{marginRight : "10px"}}>Maxima   </label>
        </div>
        <div className="col">
       
            <ShoppingCartTable 
              receipts={receipts}
              onSort={this.handleSort}
              sortColumn={sortColumn}
            />
            <Pagination
              itemsCount={totalCount}
              pageSize={pageSize}
              onPageChange={this.handlePageChange}
              activePage={activePage}
            />
          </div>
        </div>
    );
  }
}

export default ShoppingCartPage;