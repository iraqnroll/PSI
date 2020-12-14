import React, { Component } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSortUp, faSortDown } from "@fortawesome/free-solid-svg-icons";
class TableHeader extends Component {
  raiseSort = (path) => {
    if (path) {
      const sortColumn = { ...this.props.sortColumn };
      if (sortColumn.path === path) {
        sortColumn.order = sortColumn.order === "asc" ? "desc" : "asc";
      } else {
        sortColumn.path = path;
        sortColumn.order = "asc";
      }
      this.props.onSort(sortColumn);
    }
  };

  sortIcon = (column) => {
    const { sortColumn } = this.props;
    if (sortColumn.path !== column.path) return null;
    if (sortColumn.order === "asc") return <FontAwesomeIcon icon={faSortUp} />;
    return <FontAwesomeIcon icon={faSortDown} />;
  };

  render() {
    const { columns } = this.props;
    return (
      <thead>
        <tr>
          {columns.map((column) => (
            <th
              style={{ cursor: "pointer" }}
              key={column.path || column.key}
              onClick={() => this.raiseSort(column.path)}
            >
              {column.label}
              {this.sortIcon(column)}
            </th>
          ))}
        </tr>
      </thead>
    );
  }
}

export default TableHeader;
