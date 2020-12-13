import React, { Component } from "react";
import { getReceipts, deleteReceipt } from "./../services/receiptService";
import ReceiptTable from "./receiptTable";
import ListGroup from "./common/listGroup";
import _ from "lodash";
import Pagination from "./common/pagination";
import { withRouter } from "react-router-dom";

class Receipts extends Component {
  state = {
    receipts: [],
    sortColumn: { path: "date", order: "asc" },
    shops: [],
    selectedShop: null,
    pageSize: 10,
    activePage: 1,
  };

  async componentDidMount() {
    const receipts = await getReceipts();
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
  handleDelete = (receipt) => {
    const receipts = this.state.receipts.filter((x) => x.id !== receipt.id);
    this.setState({ receipts });
    deleteReceipt(receipt.id);
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

  render() {
    const { sortColumn, pageSize, activePage } = this.state;
    const { totalCount, data: receipts } = this.getPagedData();
    return (
      <div>
        <h1 className="m-2">Receipts</h1>
        <div className="row">
          <div className="col-3">
            <ListGroup
              items={this.state.shops}
              selectedItem={this.state.selectedShop}
              onItemSelect={this.handleShopSelect}
            />
          </div>
          <div className="col">
            <ReceiptTable
              onDelete={this.handleDelete}
              receipts={receipts}
              onSort={this.handleSort}
              sortColumn={sortColumn}
              onInfo={() => this.handleInfo(this.props)}
            />
            <Pagination
              itemsCount={totalCount}
              pageSize={pageSize}
              onPageChange={this.handlePageChange}
              activePage={activePage}
            />
          </div>
        </div>
      </div>
    );
  }
}

export default Receipts;
