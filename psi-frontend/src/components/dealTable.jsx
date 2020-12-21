import React, { Component } from "react";
import Table from "./common/table";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTimes, faInfoCircle } from "@fortawesome/free-solid-svg-icons";
import { Link } from "react-router-dom";

class DealTable extends Component {
  columns = [
     {
      path: "name",  label: "Item",
    },
    { path: "shop", label: "Shop" },
    {
      path: "date",label: "Date",
    },
    {
      path: "price",label: "Change"
    },
    {
      label: "", key: "arrow", content: (price) => (
        <div class={getChange(price.price)}></div>
    )}
  ];

 
  
  render() {
    const { classes, receipts, onSort, sortColumn } = this.props;

    return (
      <Table 
        class="table-danger" 
        columns={this.columns}
        data={receipts}
        sortColumn={sortColumn}
        onSort={onSort}    
      />
    );
  }
}
function getChange(price) {
  if (price == 0)
    return ""
  else if (price > 0)
    return "GreenArrow"
  else
    return "RedArrow"
}

export default DealTable;
