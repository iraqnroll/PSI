import React, { Component } from "react";
import Table from "./common/table";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTimes, faInfoCircle } from "@fortawesome/free-solid-svg-icons";
import { Link } from "react-router-dom";

class ShoppingCartTable extends Component {
  columns = [
     {
      path: "name",  label: "Item",
    },
    { path: "shop", label: "Shop" },
    {
      path: "price",label: "Price"}
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
export default ShoppingCartTable;
