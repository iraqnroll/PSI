import React, { Component } from "react";
import Table from "./common/table";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTimes, faInfoCircle } from "@fortawesome/free-solid-svg-icons";
import { Link } from "react-router-dom";
class ReceiptTable extends Component {
  columns = [
    {
      path: "date",
      label: "Date",
    },
    { path: "shop", label: "Shop" },
    { path: "sum", label: "Total" },
    {
      key: "delete",
      content: (receipt) => (
        <button
          className="btn btn-danger"
          onClick={() => this.props.onDelete({ id: receipt.id })}
        >
          <FontAwesomeIcon icon={faTimes} size="lg" />
        </button>
      ),
    },
    {
      key: "info",
      content: (receipt) => (
        <Link className="btn btn-info" to={"receipts/" + receipt.id}>
          <FontAwesomeIcon icon={faInfoCircle} size="lg" />
        </Link>
      ),
    },
  ];
  render() {
    const { receipts, onSort, sortColumn } = this.props;

    return (
      <Table
        columns={this.columns}
        data={receipts}
        sortColumn={sortColumn}
        onSort={onSort}
      />
    );
  }
}

export default ReceiptTable;
