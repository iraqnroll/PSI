import React, { Component } from "react";
import ReceiptTable from "./receiptTable";
import { getReceipt } from "./../services/receiptService";
import ItemPriceTable from "./itemPriceTable";
class ReceiptDetails extends Component {
  state = { itemPrices: [], sortColumn: { path: "name", order: "asc" } };

  async componentDidMount() {
    const itemPrices = await getReceipt(this.props.match.params.id);
    this.setState({ itemPrices });
  }
  handleSort = (sortColumn) => {
    this.setState({ sortColumn });
  };

  render() {
    const { itemPrices, sortColumn } = this.state;
    return (
      <div>
        <h1>Receipt details {this.props.match.params.id}</h1>
        <ItemPriceTable
          itemPrices={itemPrices}
          onSort={this.handleSort}
          sortColumn={sortColumn}
        />
      </div>
    );
  }
}

export default ReceiptDetails;
