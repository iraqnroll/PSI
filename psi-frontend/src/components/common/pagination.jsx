import React from "react";
import PropTypes from "prop-types";
import _ from "lodash";
const Pagination = ({ pageSize, itemsCount, activePage, onPageChange }) => {
  const pagesCount = Math.ceil(itemsCount / pageSize);
  if (pagesCount === 1) return null;
  const pages = _.range(1, pagesCount + 1);
  return (
    <nav>
      <ul className="pagination  group-mine" style={{color: "rgb(255, 223, 26)"}}>
        {pages.map((page) => (
          <li
            className={activePage === page ? "mySelected" : "page-item  group-mine"}
            key={page}
            style={{color: "rgb(255, 25, 26)"}}
          >
            <div  className="page-link group-mine" onClick={() => onPageChange(page)}>
              {page}
            </div>
          </li>
        ))}
      </ul>
    </nav>
  );
};
Pagination.propTypes = {
  pageSize: PropTypes.number.isRequired,
  itemsCount: PropTypes.number.isRequired,
  activePage: PropTypes.number.isRequired,
  onPageChange: PropTypes.func.isRequired,
};
export default Pagination;
