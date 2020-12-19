import React, { Component } from "react";
import { getReceipt } from "./../services/receiptService";
import ItemPriceTable from "./itemPriceTable";
import _ from "lodash";
import ListGroup from "./common/listGroup";
import Pagination from "./common/pagination";
class ReceiptDetails extends Component {
  state = {
    itemPrices: [],
    sortColumn: { path: "name", order: "asc" },
    types: [],
    selectedType: null,
    pageSize: 10,
    activePage: 1,
  };

  async componentDidMount() {
    try {
      const itemPrices = await getReceipt(this.props.match.params.id);
      const types = [
        { id: 0, name: "All types" },
        { id: 1, name: "Mesos gaminiai" },
        { id: 2, name: "Juros gerybes" },
        { id: 3, name: "Kepiniai" },
        { id: 4, name: "Darzoves" },
        { id: 5, name: "Vaisiai" },
        { id: 6, name: "Pieno produktai" },
        { id: 7, name: "Gerimai" },
        { id: 8, name: "Saldumynai" },
        { id: 9, name: "Uzkandziai" },
      ];
      this.setState({ itemPrices, types });
    } catch (ex) {
      //if (ex.response && ex.response.status === 404)
      this.props.history.replace("/not-found");
    }
  }

  handleSort = (sortColumn) => {
    this.setState({ sortColumn });
  };

  handleTypeSelect = (type) => {
    this.setState({ selectedType: type, activePage: 1 });
  };

  handlePageChange = (page) => {
    this.setState({ activePage: page });
  };

  paginate(items, pageNumber, pageSize) {
    const startIndex = (pageNumber - 1) * pageSize;
    return _(items).slice(startIndex).take(pageSize).value();
  }

  getPagedData() {
    const {
      itemPrices: allItemPrices,
      sortColumn,
      selectedType,
      activePage,
      pageSize,
    } = this.state;

    let filtered = allItemPrices;
    if (selectedType && selectedType.id !== 0)
      filtered = allItemPrices.filter(
        (itemPrice) => itemPrice.type === selectedType.name
      );
    const sorted = _.orderBy(filtered, [sortColumn.path], [sortColumn.order]);

    const itemPrices = this.paginate(sorted, activePage, pageSize);

    return { totalCount: filtered.length, data: itemPrices };
  }

  render() {
    const { sortColumn, pageSize, activePage } = this.state;
    const { totalCount, data: itemPrices } = this.getPagedData();
    return (
      <div>
        <h1 className="m-2">Receipt details Nr.{this.props.match.params.id}</h1>
        <div className="row">
          <div className="col-3">
            <ListGroup
              items={this.state.types}
              selectedItem={this.state.selectedType}
              onItemSelect={this.handleTypeSelect}
            />
          </div>
          <div className="col">
            <ItemPriceTable
              itemPrices={itemPrices}
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
      </div>
    );
  }
}

export default ReceiptDetails;
