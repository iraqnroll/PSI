import React, { Component } from "react";
import {
  getReceipts,
  deleteReceipt,
  createReceipt,
} from "./../services/receiptService";
import ReceiptTable from "./receiptTable";
import ListGroup from "./common/listGroup";
import _ from "lodash";
import Pagination from "./common/pagination";
import Select from "./common/select";

class Receipts extends Component {
  state = {
    receipts: [],
    sortColumn: { path: "date", order: "asc" },
    shops: [],
    selectedShop: null,
    pageSize: 10,
    activePage: 1,
    receiptShop: 0,
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
    this.setState({ selectedShop: shop, activePage: 1 });
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

  handleShopChange = ({ currentTarget: input }) => {
    this.setState({ receiptShop: input.value });
  };

  paginate(items, pageNumber, pageSize) {
    const startIndex = (pageNumber - 1) * pageSize;
    return _(items).slice(startIndex).take(pageSize).value();
  }

  handleNewReceipt = async () => {
    const response = await createReceipt(parseInt(this.state.receiptShop));
    let receipt = response.data.data[response.data.data.length - 1];
    this.props.history.push("/receipts/edit/" + receipt.id);
    console.log(receipt);
  };

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
    let newShops = [...this.state.shops];
    newShops.shift();
    return (
      <div className="Box_content">
        <h1 className="m-2">Receipts</h1>
        <div className="row">
          <div className="col-3">
            <ListGroup
              items={this.state.shops}
              selectedItem={this.state.selectedShop}
              onItemSelect={this.handleShopSelect}
            />
            {this.state.receiptShop > 0 ? (
              <button
                style={{ display: "block", width: "100%" }}
                className="btn btn-success btn-lg mt-5"
                onClick={this.handleNewReceipt}
              >
                Create new receipt
              </button>
            ) : (
              <button
                style={{ display: "block", width: "100%" }}
                className="btn btn-success btn-lg mt-5"
                disabled
              >
                Create new receipt
              </button>
            )}

            <Select
              test={false}
              name="shops"
              value={this.state.receiptShop}
              label="Shops"
              options={newShops}
              onChange={this.handleShopChange}
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
