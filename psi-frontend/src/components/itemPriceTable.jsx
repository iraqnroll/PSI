import React, { Component } from "react";
import Table from "./common/table";
class ItemPriceTable extends Component {
  columns = [
    { path: "name", label: "Name" },
    { path: "type", label: "Type" },
    { path: "price", label: "Price" },
  ];
  render() {
    const { itemPrices, onSort, sortColumn } = this.props;

    return (
      <Table
        columns={this.columns}
        data={itemPrices}
        sortColumn={sortColumn}
        onSort={onSort}
      />
    );
  }
}

export default ItemPriceTable;
