import React, { Component } from "react";
import { getDeals } from "../services/shoppingCartService";
import ListGroup from "./common/listGroup";
import DealTable from "./dealTable";
import _ from "lodash";
import Pagination from "./common/pagination";
import { withRouter } from "react-router-dom";

class Deals extends Component {
  state = {
    receipts: [],
    sortColumn: { path: "Shop", order: "asc" },
    shops: [],
    selectedShop: null,
    pageSize: 10,
    activePage: 1,
  };

  async componentDidMount() {
    const receipts = await getDeals();
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
     console.log({ totalCount: filtered.length, data: receipts });
    return { totalCount: filtered.length, data: receipts };
  }
  

  render() {
    
    const { sortColumn, pageSize, activePage } = this.state;
    const { totalCount, data: receipts } = this.getPagedData();
    return (
      <div className="Box">
        <p className="Box_content">
        <h1 className="m-2">Best Deals</h1>
        <div className="row">
          <div className="col-3 ">
            <ListGroup
              items={this.state.shops}
              selectedItem={this.state.selectedShop}
              onItemSelect={this.handleShopSelect}
            />
          </div>
          <div className="col">
            <DealTable
              getTrProps={this.getTRPropsType}  
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
          </p>
      </div>
    );
  }
}

export default Deals;